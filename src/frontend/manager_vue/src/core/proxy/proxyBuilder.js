import { proxyGateway } from '../../app/services'

export class ProxyBuilder {

    static Create(){
        return new ProxyBuilder(proxyGateway)
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
        if(!this.projectId){
            throw new Error('参数错误,projectId不允许为空')
        }
        if(this.id){
            const id = this.id
            await this._gateway.updateAsync({id, name, description, projectId})
        }else{
            await this._gateway.addAsync({name, description, projectId})
        }
    }

    async getAsync(){
        if(this.id){
            var res = await this._gateway.getAsync(this.id)
            this.name = res.name
            this.description = res.description
            this.projectId = res.projectId
        }
    }

    clear(){
        this.id = ''
        this.name = ''
        this.description = ''
        this.projectId = ''
    }
}