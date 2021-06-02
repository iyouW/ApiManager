import { VersionBuilder } from "../../core/version/versionBuilder"
import { VersionList } from "../../core/version/versionList"


export default {
    namespaced:true,
    state:{
        versionList: VersionList.Create(),
        versionBuilder: VersionBuilder.Create()
    },
    getters:{
        versionList(state){
            return state.versionList
        },
        versionBuilder(state){
            return state.versionBuilder
        }
    }
}