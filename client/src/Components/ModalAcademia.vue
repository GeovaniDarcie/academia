<template>
  <b-container fluid>
    <b-row class="mb-1">
      <b-col>
        Nome:
        <b-form-input v-model="academia.nome" placeholder="Nome"></b-form-input>
      </b-col>
      <b-col>
        Endeço:
        <b-form-input
          v-model="academia.endereco"
          placeholder="Endereço"
        ></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        E-mail:
        <b-form-input v-model="academia.email" type="email" placeholder="Email"></b-form-input>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: "ModalCadastro",
  data() {
    return {
      backgroundModal: "dark",
      textModal: "light",
    };
  },
  computed: {
    ...mapState(['academia']),
  },
};
</script>
