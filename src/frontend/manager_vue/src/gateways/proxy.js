export class ProxyGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'proxy'
        return this._http.get(url)
    }

    getAsync(id){
        const url = `proxy/${id}`
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

    updateAsync({id,name, description}){
        const url = `proxy`
        return this._http.put(url, {id, name, description})
    }

    deleteAsync(id){
        const url = `proxy/${id}`
        return this._http.delete(url)
    }
}