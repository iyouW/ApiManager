import { moduleGateway } from '../../app/services'

export class ModuleBuilder {

    static Create(){
        return new ModuleBuilder(moduleGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this.id = ''
        this.name = ''
        this.description = ''

        this.projectId = ''
    }

    async saveAsync(){
        const name = this.name
        const description = this.description
        const projectId = this.projectId
        if(this.id){
            const id = this.id
            this._gateway.updateAsync({id,name,description})
        }else{
            await this._gateway.addAsync({name,description, projectId})
        }
        
        this.clear()
    }

    async getAsync(){
        if(this.id){
            var res = await this._gateway.getAsync(this.id)
            this.name = res.name
            this.description = res.description
        }
    }

    clear(){
        this.id = ''
        this.name = ''
        this.description = ''
        this.projectId = ''
    }
}