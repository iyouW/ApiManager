export class ModuleGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'module'
        return this._http.get(url)
    }

    listByProjectIdAsync(projectId){
        const url = `${projectId}/module`
        return this._http.get(url)
    }

    getAsync(id){
        const url = `module/${id}`
        return this._http.get(url)
    }

    addAsync({name,description,projectId}){
        const url = 'module'
        return this._http.post(url, {name,description,projectId})
    }

    updateAsync({id,name, description}){
        const url = `module`
        return this._http.put(url, {id, name, description})
    }

    deleteAsync(id){
        const url = `module/${id}`
        return this._http.delete(url)
    }
}