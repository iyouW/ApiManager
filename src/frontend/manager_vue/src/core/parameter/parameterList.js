import { parameterGateway } from '../../app/services'
import { ParameterNode } from './parameterNode'

export class ParameterList {

    static Create(){
        return new ParameterList(parameterGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this._list = []

        this.input = ParameterNode.None
        this.output = ParameterNode.None
        this.exception = ParameterNode.None

        this.projectId = ''
        this.moduleId = ''
        this.apiId = ''
    }

    async initAsync(){
        const apiId = this.apiId
        this._list = await this._gateway.listWithinApiAsync(apiId)
        this.prepareParameterForView()
    }

    prepareParameterForView(){
        const inputs = this._list.filter(x => x.category === ParameterNode.Category.Input)
        const outputs = this._list.filter(x => x.category === ParameterNode.Category.Output)
        const exceptions = this._list.filter(x => x.category === ParameterNode.Category.Exception)
        this.prepareInput(inputs)
        this.prepareOutput(outputs)
        this.prepareException(exceptions)
    }

    prepareInput(inputs){
        if(inputs.length === 0){
            this.input = ParameterNode.CreateRoot(ParameterNode.Category.Input, this.apiId)
            return
        }
        const root = inputs.find(x => !x.parentId)
        this.input = this.buildTree(inputs, root)
    }

    prepareOutput(outputs){
        if(outputs.length === 0){
            this.output = ParameterNode.CreateRoot(ParameterNode.Category.Output, this.apiId)
            return
        }
        const root = outputs.find(x => !x.parentId)
        this.output = this.buildTree(outputs, root)
    }

    prepareException(exceptions){
        if(exceptions.length === 0){
            this.exception = ParameterNode.CreateRoot(ParameterNode.Category.Exception, this.apiId)
            return
        }
        const root = exceptions.find(x => !x.parentId)
        this.exception = this.buildTree(exceptions, root)
    }

    buildTree(parameters, parent){
        const parentNode = ParameterNode.FromParameter(parent)
        const children = parameters.filter(x => x.parentId === parent.id)
        if(children.length > 0){
            for (const child of children) {
                const childNode = this.buildTree(parameters, child)
                childNode.parent = parentNode
                parentNode.children.push(childNode)
            }
        }
        return parentNode
    }

    async saveAsync(){
        const input = this.prepareInputPayload()
        const output = this.prepareOutputPayload()
        const exception = this.prepareExceptionPayload()
        if(!input&&!output&&!exception){
            return
        }
        await this._gateway.saveAsync({input, output, exception})
        await this.initAsync()
    }

    prepareInputPayload(){
        if(this.input.children.length === 0){
            return null
        }
        this.preparePayload(this.input)
        return this.input
    }

    prepareOutputPayload(){
        if(this.output.children.length === 0){
            return null
        }
        this.preparePayload(this.output)
        return this.output
    }

    prepareExceptionPayload(){
        if(this.exception.children.length === 0){
            return null
        }
        this.preparePayload(this.exception)
        return this.exception
    }

    preparePayload(node){
        delete node.parent
        if(node.children.length > 0){
            for (const child of node.children) {
                this.preparePayload(child)
            }
        }
    }
}