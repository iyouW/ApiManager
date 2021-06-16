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

    async deleteAsync(row){
        this.list = this.list.filter(x => x.id !== row.id)
        await this._gateway.deleteAsync(row.id)
    }
}