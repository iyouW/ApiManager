import { AppBuilder } from "../../core/app/appBuilder"
import { AppList } from "../../core/app/appList"

export default {
    namespaced:true,
    state:{
        appList: AppList.Create() ,
        appBuilder: AppBuilder.Create()
    },
    getters:{
        appList(state){
            return state.appList
        },
        appBuilder(state){
            return state.appBuilder
        }
    }
}