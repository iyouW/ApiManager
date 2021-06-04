export class ParameterNode {

    static RootName = 'root'

    static ArrayItemName = 'items'

    static Type = {
        'String': 1,
        'Number' : 2,
        'Boolean' : 3,
        'Array' : 4,
        'Object' : 5
    }

    static Category = {
        'Input' : 1,
        'Output' : 2,
        'Exception' : 3
    }

    static None = new ParameterNode()

    static IsRoot(parameterNode){
        return parameterNode.name === ParameterNode.RootName
    }

    static IsArrayItems(parameterNode){
        return parameterNode.name === ParameterNode.ArrayItemName
    }

    static IsObject(parameterNode){
        return parameterNode.type === ParameterNode.Type.Object
    }

    static CreateRoot(category, apiId){
        const node = new ParameterNode()
        node.name = ParameterNode.RootName
        node.type = ParameterNode.Type.Object
        node.category = category
        node.apiId = apiId
        return node
    }

    static CreateArrayItem(parent,category,apiId){
        const node = new ParameterNode()
        node.name = ParameterNode.ArrayItemName
        node.parent = parent
        node.category = category
        node.apiId = apiId
        return node
    }

    static CreateEmptyNode(parent, category, apiId){
        const node = new ParameterNode()
        node.parent = parent
        node.category = category
        node.apiId = apiId
        return node
    }

    static FromParameter(node){
        const res = new ParameterNode()
        res.name = node.name
        res.description = node.description
        res.comment = node.comment
        res.type = node.type
        res.category = node.category
        res.apiId = node.apiId
        return res
    }

    constructor(){
        this.name = ''
        this.description = ''
        this.comment = ''
        this.type = ParameterNode.Type.String
        this.category = -1
        this.apiId = ''

        this.parent = null
        this.children = []
    }

    remove(){
        if(this.parent){
            const container = this.parent.children
            container.splice(container.findIndex(x => x === this ),1)
        }
    }
}