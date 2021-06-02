export class VersionGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'version'
        return this._http.get(url)
    }

    addAsync({name,description}){
        const url = 'version'
        return this._http.post(url, {name,description})
    }
}