import { projectGateway } from '../../app/services'

export class ProjectBuilder {

    static Create(){
        return new ProjectBuilder(projectGateway);
    }

    constructor(gateway){
        this._gateway = gateway

        this.id = ''
        this.name = ''
        this.description = ''
    }

    async saveAsync(){
        const name = this.name
        const description = this.description
        if(this.id){
            const id = this.id
            await this._gateway.updateAsync({id, name, description})
        }else{
            await this._gateway.addAsync({name, description})
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
    }
}