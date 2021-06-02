import { ProxyBuilder } from "../../core/proxy/proxyBuilder"
import { ProxyList } from "../../core/proxy/proxyList"

export default {
    namespaced:true,
    state:{
        proxyList: ProxyList.Create(),
        proxyBuilder: ProxyBuilder.Create()
    },
    getters:{
        proxyList(state){
            return state.proxyList
        },
        proxyBuilder(state){
            return state.proxyBuilder
        }
    }
}