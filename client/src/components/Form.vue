<template>
  <div>
    <b-form inline class="mt-3 ml-3">
      <label>Nome: </label>
      <b-form-input
        v-model="nome"
        class="mr-2 ml-2"
        placeholder="Digite seu nome"
      ></b-form-input>
      <b-button variant="primary" @click="cadastrar">Salvar</b-button>
    </b-form>
    <b-list-group class="lista mt-3 ml-3">
      <b-list-group-item v-for="aluno in alunos" :key="aluno">
        {{ aluno }}
      </b-list-group-item>
    </b-list-group>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Form",
  data() {
    return {
      alunos: null,
      nome: "",
    };
  },
  methods: {
    cadastrar() {
      axios
        .post("https://localhost:5001/Aluno", { nome: this.nome })
        .then((response) => {
          if (response.status == 200) {
            this.buscar();
          }
        });
    },

    buscar() {
      axios
        .get("https://localhost:5001/Aluno")
        .then((response) => (this.alunos = response.data));
    },

    remover() {
      axios.delete("https://localhost:5001/Aluno");
    },
  },
  mounted() {
    this.buscar();
  },
};
</script>

<style>
.lista {
  max-width: 400px;
}
</style>