import { moduleGateway } from '../../app/services'

export class ModuleList {

    static Create(){
        return new ModuleList(moduleGateway)    
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []

        this.projectId = ''
    }

    async initAsync(){
        const projectId = this.projectId
        this.list = await this._gateway.listByProjectIdAsync(projectId)
    }

    async deleteAsync(row){
        this.list = this.list.filter(x => x.id !== row.id)
        await this._gateway.deleteAsync(row.id)
    }
}