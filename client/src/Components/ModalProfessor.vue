<template>
  <b-container fluid>
    <b-row class="mb-1">
      <b-col>
        Nome:
        <b-form-input v-model="professor.nome" placeholder="Nome"></b-form-input>
      </b-col>
      <b-col>
        Sobrenome:
        <b-form-input
          v-model="professor.sobrenome"
          placeholder="Sobrenome"
        ></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        E-mail:
        <b-form-input v-model="professor.email" type="email" placeholder="Email"></b-form-input>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: "ModalProfessor",
  data() {
    return {
      backgroundModal: "dark",
      textModal: "light",
    };
  },
  computed: {
    ...mapState(['professor']),
  },
};
</script>
