import { projectGateway } from '../../app/services'

export class ProjectList {

    static Create(){
        return new ProjectList(projectGateway);
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []
    }

    async initAsync(){
        this.list = await this._gateway.listAsync()
    }
}