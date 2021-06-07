import { projectGateway } from '../../app/services'

export class ProjectList {

    static Create(){
        return new ProjectList(projectGateway);
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []

        this.selectedProject = null
    }

    async initAsync(){
        this.list = await this._gateway.listAsync()
    }

    async generateCodeAsync(){
        await this._gateway.generateCodeAsync({projectId: this.selectedProject.id});
    }

    async generateExampleAsync(){
        await this._gateway.generateExampleAsync({projectId: this.selectedProject.id});
    }
}