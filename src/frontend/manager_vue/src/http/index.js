import axios from 'axios'

const instance = axios.create({
    baseURL:"http://localhost:5000/api",
    timeout: 10*60*1000
});

instance.interceptors.response.use(res=>{
    return res.data
},err=>{
    console.log(err)
})

export const http = instance