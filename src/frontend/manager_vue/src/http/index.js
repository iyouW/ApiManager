import axios from 'axios'

const instance = axios.create({
    baseURL:"http://172.31.87.120:5000/api",
    timeout: 10*60*1000
});

instance.interceptors.response.use(res=>{
    if(res.config.responseType){
        return res
    }
    return res.data
},err=>{
    console.log(err)
})

export const http = instance