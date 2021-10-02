import Vue from 'vue'
import Vuex from 'vuex';

Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
      aluno: {},
      autenticado: false,
      loading: false,
      errors: {}
    },
    mutations: {
      changeAluno(state, payload) {
        state.aluno = { ...payload }
      },
      alunoAutorizado(state, payload) {
        state.autenticado = payload;
      },
      iniciaLoading(state, payload) {
        state.loading = payload;
      },
    },
    actions: {
      changeAluno (context, payload) {
        context.commit('changeAluno', payload)
      },
      alunoAutorizado (context, payload) {
        context.commit('alunoAutorizado', payload)
      },
      iniciaLoading (context, payload) {
        context.commit('alunoAutorizado', payload)
      },
    }
})

export default store;