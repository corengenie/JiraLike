import { createApp } from 'vue'
import App from './App.vue'

import { createRouter, createWebHistory } from 'vue-router'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import HelloWorld from './components/HelloWorld.vue'
import DashBoard from './components/DashBoard/DashBoard.vue'


const routes = [
    { path: '/', name: 'main', component: HelloWorld, default: true },
    { path: '/dashboard', name: 'dashboard', component: DashBoard },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
    linkActiveClass: 'active'
  })
  
  const app = createApp(App)
  app.use(router)
  app.mount('#app')
