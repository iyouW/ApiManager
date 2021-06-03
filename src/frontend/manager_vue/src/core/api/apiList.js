import { apiGateway } from '../../app/services'

export class ApiList {

    static Create(){
        return new ApiList(apiGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []

        this.projectId = ''
        this.moduleId = ''
    }

    async initAsync(){
        const projectId = this.projectId
        const moduleId = this.moduleId
        this.list = await this._gateway.listWithinModuleAsync(projectId, moduleId)
    }
}