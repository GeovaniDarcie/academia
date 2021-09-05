import Vue from 'vue'
import Vuex from 'vuex';

Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
      aluno: {}
    },
    mutations: {
      changeAluno(state, payload) {
        state.aluno = { ...payload }
      }
    },
    actions: {
      changeAluno (context, payload) {
        context.commit('changeAluno', payload)
      }
    }
})

export default store;