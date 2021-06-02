export class VersionGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'version'
        return this._http.get(url)
    }

    addAsync({name,description} = payload){
        const url = 'version'
        return this._http.post(url, payload);
    }
}