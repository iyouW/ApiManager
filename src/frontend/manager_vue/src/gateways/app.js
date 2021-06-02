export class AppGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'app'
        return this._http.get(url)
    }

    addAsync({name,description} = payload){
        const url = 'app'
        return this._http.post(url, payload);
    }
}