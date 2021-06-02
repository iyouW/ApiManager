export class ApiGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'api'
        return this._http.get(url)
    }

    addAsync({name,description,isSupported,isParameterStandard,mapName,projectId,moduleId,proxyId}){
        const url = 'api'
        return this._http.post(url, {name,description,isSupported,isParameterStandard,mapName,projectId,moduleId,proxyId})
    }
}