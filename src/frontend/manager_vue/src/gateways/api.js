export class ApiGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'api'
        return this._http.get(url)
    }

    listWithinModuleAsync(projectId, moduleId){
        const url = `${projectId}/${moduleId}/api`
        return this._http.get(url)
    }

    getAsync(id){
        const url = `api/${id}`
        return this._http.get(url)
    }

    addAsync({name,description,isSupported,isParameterStandard,mapName,projectId,moduleId,proxyId, author, supportedApp}){
        const url = 'api'
        return this._http.post(url, {name,description,isSupported,isParameterStandard,mapName,projectId,moduleId,proxyId,author, supportedApp})
    }

    updateAsync({id,name, description,isSupported,isParameterStandard,mapName, proxyId, author, supportedApp}){
        const url = `api`
        return this._http.put(url, {id, name, description,isSupported,isParameterStandard,mapName, proxyId, author, supportedApp})
    }

    deleteAsync(id){
        const url = `api/${id}`
        return this._http.delete(url)
    }
}