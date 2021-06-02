import { ParameterBuilder } from "../../core/parameter/parameterBuilder"
import { ParameterList } from "../../core/parameter/parameterList"

export default {
    namespaced:true,
    state:{
        parameterList: ParameterList.Create(),
        parameterBuilder: ParameterBuilder.Create()
    },
    getters:{
        parameterList(state){
            return state.parameterList
        },
        parameterBuilder(state){
            return state.parameterBuilder
        }
    }
}