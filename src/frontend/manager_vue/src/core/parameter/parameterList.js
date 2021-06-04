import { parameterGateway } from '../../app/services'
import { ParameterNode } from './parameterNode'

export class ParameterList {

    static Create(){
        return new ParameterList(parameterGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this._list = []

        this.inputParameters = ParameterNode.CreateRoot(ParameterNode.Category.Input)
        this.outputParameters = ParameterNode.CreateRoot(ParameterNode.Category.Output)
        this.exceptionParameters = ParameterNode.CreateRoot(ParameterNode.Category.Exception)

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
        this.buildParameterTree(inputs, ParameterNode.Category.Input)
        this.buildParameterTree(outputs, ParameterNode.Category.Output)
        this.buildParameterTree(exceptions, ParameterNode.Category.Exception)
    }

    buildParameterTree(nodes, type){
        const roots = nodes.filter(x => !x.parentId)
        return this.compositeTree(nodes,roots,type)
    }

    compositeTree(nodes,parents,type){
        // const res = []
        // for (const root of roots) {
        //     const treeNode = ParameterNode.CreateEmptyNode(null)
        // }

        console.log(nodes)
        console.log(parents)
        console.log(type)

    }
}