import { apiGateway } from '../../app/services'

export class ApiBuilder {

    static Create(){
        return new ApiBuilder(apiGateway)
    }

    constructor(gateway){
        this._gateway = gateway
        
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
        await apiGateway.addAsync({name, description, isSupported, isParameterStandard,mapName,proxyId,projectId,moduleId, author, supportedApp})
    }
}