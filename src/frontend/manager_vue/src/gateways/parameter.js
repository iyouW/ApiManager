export class ParameterGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'parameter'
        return this._http.get(url)
    }

    addAsync({name,description,comment,type,category,apiId,parentId} = payload){
        const url = 'parameter'
        return this._http.post(url, payload);
    }
}