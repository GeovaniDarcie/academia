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

import Teste from './View/Form/components/Teste'
import Form from './View/Form/Form'
import Login from './View/Form/components/Login'

const routes = [
  { path: '/', name: 'login', component: Login },
  { path: '/Home', name: 'home', component: Form },
  { path: '/teste', name: 'teste', component: Teste }
]

const router = new VueRouter({
  mode: 'history',
  routes // short for `routes: routes`
})


new Vue({
  render: h => h(App),
  router
}).$mount('#app')
