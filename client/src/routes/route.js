import Vue from 'vue'
import VueRouter from 'vue-router';

Vue.use(VueRouter)

import Login from '../View/Login/Login'
import Alunos from '../View/Alunos/Alunos'
import Professores from '../View/Professores/Professores'
import Avaliacao from '../View/Avaliacao/Avaliacao'
import Treino from '../View/Treinos/Treino'
import Academia from '../View/Academia/Academia'

const routes = [
    { path: '/', name: 'login', component: Login },
    { path: '/alunos', name: 'alunos', component: Alunos },
    { path: '/professores', name: 'professores', component: Professores },
    { path: '/academias', name: 'academias', component: Academia },
    { path: '/avaliacao', name: 'avaliacao', component: Avaliacao },
    { path: '/treino/:id', name: 'treino', component: Treino }
]

const router = new VueRouter({
    mode: 'history',
    routes 
})

router.beforeEach((to, from, next) => {
    const token = localStorage.getItem("token");
    if (to.name !== 'login' && token == null) {
        next({ name: 'login'})
    } else {
        next()
    }
})

export default router;