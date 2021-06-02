export class ModuleGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'module'
        return this._http.get(url)
    }

    addAsync({name,description,projectId}){
        const url = 'module'
        return this._http.post(url, {name,description,projectId})
    }
}