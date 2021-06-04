export class ParameterGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'parameter'
        return this._http.get(url)
    }

    listWithinApiAsync(apiId){
        const url = `${apiId}/parameter`
        return this._http.get(url)
    }

    addAsync({name,description,comment,type,category,apiId,parentId}){
        const url = 'parameter'
        return this._http.post(url, {name,description,comment,type,category,apiId,parentId})
    }

    saveAsync({input, output, exception}){
        console.log(input)
        console.log(output)
        console.log(exception)
        const url = 'parameter/save'
        return this._http.post(url, {input, output, exception})
    }
}