import axios from 'axios'

const http = axios.create({
    baseURL:"http://localhost:5000/api",
    timeout: 10*60*1000
});

http.interceptors.response.use(res=>{
    return res.data;
},err=>{
    console.log(err);
})

export default  http;