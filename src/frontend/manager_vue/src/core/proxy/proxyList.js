import { proxyGateway } from '../../app/services'

export class ProxyList {

    static Create(){
        return new ProxyList(proxyGateway)
    }

    constructor(gateway){
        this._gateway = gateway

        this.list = []

        this.projectId = ''
    }

    async initAsync(){
        if(!this.projectId){
            throw new Error('参数错误,projectId不允许为空')
        }
        this.list = await this._gateway.listByProjectIdAsync(this.projectId)
    }

    async deleteAsync(row){
        this.list = this.list.filter(x => x.id !== row.id)
        await this._gateway.deleteAsync(row.id)
    }
}