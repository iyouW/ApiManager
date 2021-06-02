import { ApiBuilder } from "../../core/api/apiBuilder"
import { ApiList } from "../../core/api/apiList"


export default {
    namespaced:true,
    state:{
        apiList: ApiList.Create(),
        apiBuilder: ApiBuilder.Create()
    },
    getters:{
        apiList(state){
            return state.apiList
        },
        apiBuilder(state){
            return state.apiBuilder
        }
    }
}