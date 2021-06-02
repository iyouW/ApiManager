import { ProjectBuilder } from "../../core/project/projectBuilder"
import { ProjectList } from "../../core/project/projectList"

ProjectList
export default {
    namespaced:true,
    state:{
        projectList: ProjectList.Create(),
        projectBuilder: ProjectBuilder.Create()
    },
    getters:{
        projectList(state){
            return state.projectList
        },
        projectBuilder(state){
            return state.projectBuilder
        }
    }
}