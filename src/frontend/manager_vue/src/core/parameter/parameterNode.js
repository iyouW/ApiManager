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

    static IsRoot(parameterNode){
        return parameterNode.name === ParameterNode.RootName
    }

    static IsArrayItems(parameterNode){
        return parameterNode.name === ParameterNode.ArrayItemName
    }

    static IsObject(parameterNode){
        return parameterNode.type === ParameterNode.Type.Object
    }

    static CreateRoot(category){
        const node = new ParameterNode()
        node.name = ParameterNode.RootName
        node.type = ParameterNode.Object
        node.category = category
        return node
    }

    static CreateArrayItem(parent,category){
        const node = new ParameterNode()
        node.name = ParameterNode.ArrayItemName
        node.parent = parent
        node.category = category
        return node
    }

    static CreateEmptyNode(parent, category){
        const node = new ParameterNode()
        node.parent = parent
        node.category = category
        return node
    }

    constructor(){
        this.name = ''
        this.description = ''
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