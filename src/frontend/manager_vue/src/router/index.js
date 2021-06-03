import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect:'/project'
  },
  {
    path: '/:projectId/:moduleId/api',
    component: () => import('../views/api/List.vue')
  },
  {
    path: '/:projectId/:moduleId/addApi',
    component: ()=> import('../views/api/Add.vue')
  },
  {
    path: '/app',
    component: () => import('../views/app/List.vue')
  },
  {
    path: '/addApp',
    component: ()=> import('../views/app/Add.vue')
  },
  {
    path: '/:projectId/module',
    component: () => import('../views/module/List.vue')
  },
  {
    path: '/:projectId/addModule',
    component: ()=> import('../views/module/Add.vue')
  },
  {
    path: '/project',
    component: () => import('../views/project/List.vue')
  },
  {
    path: '/addProject',
    component: ()=> import('../views/project/Add.vue')
  },
  {
    path: '/:projectId/proxy',
    component: () => import('../views/proxy/List.vue')
  },
  {
    path: '/:projectId/addProxy',
    component: ()=> import('../views/proxy/Add.vue')
  },
  {
    path: '/version',
    component: () => import('../views/version/List.vue')
  },
  {
    path: '/addVersion',
    component: ()=> import('../views/version/Add.vue')
  },
  {
    path: '/:projectId/:moduleId/:apiId/parameter',
    component: ()=> import('../views/parameter/Index.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
