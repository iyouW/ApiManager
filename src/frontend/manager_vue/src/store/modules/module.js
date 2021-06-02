import { ModuleBuilder } from "../../core/module/moduleBuilder"
import { ModuleList } from "../../core/module/moduleList"

export default {
    namespaced:true,
    state:{
        moduleList: ModuleList.Create(),
        moduleBuilder: ModuleBuilder.Create()
    },
    getters:{
        moduleList(state){
            return state.moduleList
        },
        moduleBuilder(state){
            return state.moduleBuilder
        }
    }
}