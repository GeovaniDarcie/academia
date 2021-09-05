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
import { getById } from "../Service/api";

export default {
  name: "ModalCadastro",
  props: {
    mostrarModal: Boolean,
    editAluno: Boolean,
  },

  data() {
    return {
      backgroundModal: "dark",
      textModal: "light",
      /* aluno: {
        nome: "",
        sobrenome: "",
        email: "",
        celular: "",
        cpf: "",
        dataDeNascimento: "",
        genero: "",
        inicioDeMatricula: "",
      }, */
      options: [
        { item: "A", name: "Masculino" },
        { item: "B", name: "Feminino" },
      ],
    };
  },
  methods: {
    limpaCamposAlunos() {
      this.aluno = {};
    },

    handleOk() {
      console.log('oitro')
    },

    async buscarPorId(id) {
      console.log("aa");
      const alunoDb = await getById(id);
      this.aluno = { ...alunoDb };
      this.aluno.dataDeNascimento = new Date(this.aluno.dataDeNascimento)
        .toISOString()
        .split("T")[0];
      this.aluno.inicioDeMatricula = new Date(this.aluno.inicioDeMatricula)
        .toISOString()
        .split("T")[0];
    },
  },
  computed: {
    ...mapState(['aluno']),
  },

  watch: {
    idAluno() {
      this.buscarPorId(this.idAluno);
    },
  },
};
</script>
