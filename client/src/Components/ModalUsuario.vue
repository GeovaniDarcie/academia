<template>
    <b-container fluid>
      <b-row class="mb-1">
        <b-col>
          Username:
          <b-form-input v-model="usuario.username" placeholder="Username"></b-form-input>
        </b-col>
      </b-row>
      <b-row class="mb-1">
        <b-col>
          E-mail:
          <b-form-input  v-model="usuario.email" placeholder="Email"></b-form-input>
        </b-col>
      </b-row>
      <b-row class="mb-1">
        <b-col>
          Função:
          <b-form-select v-model="usuario.role" :options="options" size="sm" class="mt-1"></b-form-select>
        </b-col>
      </b-row>
      <b-row class="mb-1">
        <b-col>
          Senha:
          <b-form-input  v-model="usuario.password" type="password" placeholder="Senha"></b-form-input>
        </b-col>
      </b-row>
    </b-container>
  </template>
  
  <script>
  import { mapState } from 'vuex';
  
  export default {
    name: "ModalUsuario",
    data() {
      return {
        backgroundModal: "dark",
        textModal: "light",
        options: [
          { value: 'Completo', text: 'Completo' },
          { value: 'Professor', text: 'Professor' }
        ]
      };
    },
    computed: {
    ...mapState(['usuario']),
  },
  };
  </script>
  