import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import iView from 'iview'
import 'iview/dist/styles/iview.css'

import './styles/index.less'

Vue.config.productionTip = false

Vue.config.errorHandler = (err,vm)=>{
  vm.$Notice.error({title:err.message})
}

Vue.use(iView)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
