import { ParameterList } from "../../core/parameter/parameterList"

export default {
    namespaced:true,
    state:{
        parameterList: ParameterList.Create()
    },
    getters:{
        parameterList(state){
            return state.parameterList
        }
    }
}