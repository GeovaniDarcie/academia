import Vue from 'vue'
import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VueRouter from 'vue-router';

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.use(VueRouter)

import Login from './View/Login/Login'
import Alunos from './View/Alunos/Alunos'
import Avaliacao from './View/Avaliacao/Avaliacao'

const routes = [
  { path: '/', name: 'login', component: Login },
  { path: '/alunos', name: 'alunos', component: Alunos },
  { path: '/avaliacao', name: 'avaliacao', component: Avaliacao }
]

const router = new VueRouter({
  mode: 'history',
  routes // short for `routes: routes`
})


new Vue({
  render: h => h(App),
  router
}).$mount('#app')
