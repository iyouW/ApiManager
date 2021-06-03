import { parameterGateway } from '../../app/services'

export class ParameterList {

    static Create(){
        return new ParameterList(parameterGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []

        this.inputParameters = []
        this.outputParameters = []
        this.exceptionParameters = []

        this.projectId = ''
        this.moduleId = ''
        this.apiId = ''
    }

    async initAsync(){
        const apiId = this.apiId
        this.list = await this._gateway.listWithinApiAsync(apiId)
    }
}