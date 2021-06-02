export class ProjectGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'project'
        return this._http.get(url)
    }

    addAsync({name,description} = payload){
        const url = 'project'
        return this._http.post(url, payload);
    }
}