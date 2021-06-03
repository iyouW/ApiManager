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

    constructor(){
        this.name = ''
        this.description = ''
        this.type = ParameterNode.String
        this.category = -1
        this.apiId = ''

        this.parent = null
        this.children = []
    }
}