import { apiGateway } from '../../app/services'

export class ApiBuilder {

    static Create(){
        return new ApiBuilder(apiGateway)
    }

    constructor(gateway){
        this._gateway = gateway
        this.id = ''
        this.name = ''
        this.description = ''
        this.isSupported = false
        this.isParameterStandard = false
        this.author = ''
        this.supportedApp = ''
        this.mapName = ''
        this.proxyId = ''

        this.projectId = ''
        this.moduleId = ''
        
    }

    async saveAsync(){
        const name = this.name
        const description = this.description
        const isSupported = this.isSupported
        const isParameterStandard = this.isParameterStandard
        const mapName = this.mapName
        const proxyId = this.proxyId
        const projectId = this.projectId
        const moduleId = this.moduleId
        const author = this.author
        const supportedApp = this.supportedApp
        if(this.id){
            const id = this.id
            await this._gateway.UpdateAsync({id,name, description, isSupported, isParameterStandard,mapName,proxyId,author, supportedApp})
        }else{
            await this._gateway.addAsync({name, description, isSupported, isParameterStandard,mapName,proxyId,projectId,moduleId, author, supportedApp})
        }
        
    }

    async getAsync(){
        if(this.id){
            var res = await this._gateway.getAsync(this.id)
            this.name = res.name
            this.description = res.description
            this.isSupported = res.isSupported
            this.isParameterStandard = res.isParameterStandard
            this.mapName = res.mapName
            this.projectId = res.projectId
            this.moduleId = res.moduleId
            this.proxyId = res.proxyId
            this.author = res.author
            this.supportedApp = res.supportedApp
        }
    }

    clear(){
        this.id = ''
        this.name = ''
        this.description = ''
        this.isSupported = false
        this.isParameterStandard = false
        this.author = ''
        this.supportedApp = ''
        this.mapName = ''
        this.proxyId = ''

        this.projectId = ''
        this.moduleId = ''
    }
}