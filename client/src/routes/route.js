import Vue from 'vue'
import VueRouter from 'vue-router';

Vue.use(VueRouter)

import Login from '../View/Login/Login'
import Alunos from '../View/Alunos/Alunos'
import Avaliacao from '../View/Avaliacao/Avaliacao'
import Treino from '../View/Treinos/Treino'

import store from '../store/store'

const routes = [
    { path: '/', name: 'login', component: Login },
    { path: '/alunos', name: 'alunos', component: Alunos },
    { path: '/avaliacao', name: 'avaliacao', component: Avaliacao },
    { path: '/treino', name: 'treino', component: Treino }
]

const router = new VueRouter({
    mode: 'history',
    routes 
})

router.beforeEach((to, from, next) => {
    if (to.name !== 'login' && !store.state.autenticado) {
        next({ name: 'login'})
    } else {
        next()
    }
})

export default router;