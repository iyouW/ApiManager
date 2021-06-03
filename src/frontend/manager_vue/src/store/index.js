import Vue from 'vue'
import Vuex from 'vuex'

import api from './modules/api'
import app from './modules/app'
import module from './modules/module'
import parameter from './modules/parameter'
import project from './modules/project'
import proxy from './modules/proxy'
import version from './modules/version'

Vue.use(Vuex)

export default new Vuex.Store({
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
