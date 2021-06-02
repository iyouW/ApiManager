import { projectGateway } from '../../app/services'

export class ProjectBuilder {

    static Create(){
        return new ProjectBuilder(projectGateway);
    }

    constructor(gateway){
        this._gateway = gateway

        this.name = ''
        this.description = ''
    }

    async saveAsync(){
        const name = this.name
        const description = this.description
        await this._gateway.addAsync({name, description})
        this.clear()
    }


    clear(){
        this.name = ''
        this.description = ''
    }
}