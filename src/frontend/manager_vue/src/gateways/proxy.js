export class ProxyGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'proxy'
        return this._http.get(url)
    }

    addAsync({name,description,projectId} = payload){
        const url = 'proxy'
        return this._http.post(url, payload);
    }
}