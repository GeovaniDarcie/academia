import Vue from 'vue'
import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import VueMask from 'v-mask';


Vue.use(VueMask);
Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

import store from './store/store';
import router from './routes/route';

new Vue({
  render: h => h(App),
  store: store,
  router
}).$mount('#app')
