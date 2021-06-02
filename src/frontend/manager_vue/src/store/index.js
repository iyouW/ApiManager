import Vue from 'vue'
import Vuex from 'vuex'

import parameterType from '../core/enums/parameterType'
import parameterCategory from '../core/enums/parameterCategory'

import api from './modules/api'
import app from './modules/app'
import module from './modules/module'
import parameter from './modules/parameter'
import project from './modules/project'
import proxy from './modules/proxy'
import version from './modules/version'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    parameterType,
    parameterCategory
  },
  getters:{
    parameterType(state){
      return state.parameterType
    },
    parameterCategory(state){
      return state.parameterCategory
    }
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    api,
    app,
    module,
    parameter,
    project,
    proxy,
    version
  }
})
