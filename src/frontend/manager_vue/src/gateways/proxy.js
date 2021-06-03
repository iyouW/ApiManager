export class ProxyGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'proxy'
        return this._http.get(url)
    }

    listByProjectIdAsync(projectId){
        const url = `${projectId}/proxy`
        return this._http.get(url)
    }

    addAsync({name,description,projectId}){
        const url = 'proxy'
        return this._http.post(url, {name,description,projectId})
    }
}