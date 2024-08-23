import Vue from 'vue'
import Vuex from 'vuex';

Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
      aluno: {},
      autenticado: false,
      loading: false,
      errors: [],
      usuario: {},
      academia: {},
      professor: {},
      dismissCountDownTeste: 0
    },
    mutations: {
      ADD_ERRORS(state, errors) {
        state.errors.push(...errors);
      },
      CLEAR_ERROR(state, index) {
        state.errors.splice(index, 1);
      },
      CLEAR_ALL_ERRORS(state) {
        state.errors = [];
      },
      changeAluno(state, payload) {
        state.aluno = { ...payload }
      },
      changeProfessor(state, payload) {
        state.professor = { ...payload }
      },
      changeAcademia(state, payload) {
        state.academia = { ...payload }
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
      changeProfessor (context, payload) {
        context.commit('changeProfessor', payload)
      },
      changeAcademia (context, payload) {
        context.commit('changeAcademia', payload)
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