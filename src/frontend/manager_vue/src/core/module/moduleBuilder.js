import { moduleGateway } from '../../app/services'

export class ModuleBuilder {

    static Create(){
        return new ModuleBuilder(moduleGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this.name = ''
        this.description = ''

        this.projectId = ''
    }

    async saveAsync(){
        const name = this.name
        const description = this.description
        const projectId = this.projectId
        await this._gateway.addAsync({name,description, projectId})
        this.clear()
    }

    clear(){
        this.name = ''
        this.description = ''
    }
}