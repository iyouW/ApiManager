export class ProjectGateway{
    constructor(http){
        this._http = http;
    }

    listAsync(){
        const url = 'project'
        return this._http.get(url)
    }

    addAsync({name,description}){
        const url = 'project'
        return this._http.post(url, {name, description})
    }

    async generateCodeAsync({projectId}){
        const url ='codeGenerator/bridge'
        const res = await this._http.post(url,{projectId},{responseType:'arraybuffer'})
        const link = document.createElement('a')
        const file = new Blob([res.data])
        const downloadUrl = window.URL.createObjectURL(file)
        const fileName = '下载.zip'
        link.href = downloadUrl
        link.download = fileName
        link.click()
        window.URL.revokeObjectURL(downloadUrl)
    }

    async generateExampleAsync({projectId}){
        const url ='codeGenerator/example'
        const res = await this._http.post(url,{projectId},{responseType:'arraybuffer'})
        const link = document.createElement('a')
        const file = new Blob([res.data])
        const downloadUrl = window.URL.createObjectURL(file)
        const fileName = '下载.zip'
        link.href = downloadUrl
        link.download = fileName
        link.click()
        window.URL.revokeObjectURL(downloadUrl)
    }
} 