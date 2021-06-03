import { proxyGateway } from '../../app/services'

export class ProxyBuilder {

    static Create(){
        return new ProxyBuilder(proxyGateway)
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
        if(!this.projectId){
            throw new Error('参数错误,projectId不允许为空')
        }
        await this._gateway.addAsync({name, description, projectId})
    }
}