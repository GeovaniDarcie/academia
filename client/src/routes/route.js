import Vue from 'vue'
import VueRouter from 'vue-router';

Vue.use(VueRouter)

import Login from '../View/Login/Login'
import Alunos from '../View/Alunos/Alunos'
import Avaliacao from '../View/Avaliacao/Avaliacao'
import Teste from '../View/Teste'

const routes = [
    { path: '/', name: 'login', component: Login },
    { path: '/alunos', name: 'alunos', component: Alunos },
    { path: '/avaliacao', name: 'avaliacao', component: Avaliacao },
    { path: '/teste', name: 'Teste', component: Teste }
]

const router = new VueRouter({
    mode: 'history',
    routes 
})

export default router;