<template>
  <b-container fluid>
    <b-row class="mb-1">
      <b-col>
        Nome:
        <b-form-input v-model="aluno.nome" placeholder="Nome"></b-form-input>
      </b-col>
      <b-col>
        Sobrenome:
        <b-form-input
          v-model="aluno.sobrenome"
          placeholder="Sobrenome"
        ></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        E-mail:
        <b-form-input v-model="aluno.email" placeholder="Email"></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        Celular:
        <b-form-input
          v-model="aluno.celular"
          placeholder="Celular"
        ></b-form-input>
      </b-col>
      <b-col>
        CPF:
        <b-form-input v-model="aluno.cpf" placeholder="CPF"></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        Data de nascimento:
        <b-form-input
          v-model="aluno.dataDeNascimento"
          type="date"
        ></b-form-input>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        Gênero:
        <b-form-radio-group
          :options="options"
          class="mb-3"
          v-model="aluno.genero"
          value-field="item"
          text-field="name"
          disabled-field="notEnabled"
        ></b-form-radio-group>
      </b-col>
    </b-row>
    <b-row class="mb-1">
      <b-col>
        Início da Matrícula:
        <b-form-input
          v-model="aluno.inicioDeMatricula"
          type="date"
        ></b-form-input>
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
      options: [
        { item: "A", name: "Masculino" },
        { item: "B", name: "Feminino" },
      ],
    };
  },
  computed: {
    ...mapState(['aluno']),
  },
};
</script>
