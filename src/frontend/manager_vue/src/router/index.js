import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    redirect:'/project'
  },
  {
    path: '/project/:projectId/module/:moduleId/api',
    component: () => import('../views/api/List.vue')
  },
  {
    path: '/project/:projectId/module/:moduleId/addApi',
    component: ()=> import('../views/project/Add.vue')
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
    path: '/project/:projectId/module',
    component: () => import('../views/module/List.vue')
  },
  {
    path: '/project/:projectId/addModule',
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
    path: '/project/:projectId/proxy',
    component: () => import('../views/proxy/List.vue')
  },
  {
    path: '/project/:projectId/addProxy',
    component: ()=> import('../views/proxy/Add.vue')
  },
  {
    path: '/version',
    component: () => import('../views/version/List.vue')
  },
  {
    path: '/addVersion',
    component: ()=> import('../views/version/Add.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
