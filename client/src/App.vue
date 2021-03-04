<template>
  <div id="app">
    <h2>Usuários Cadastrados:</h2>
    <div id="app">{{ info }}</div>
    <h2>Cadastre um novo:</h2>
    nome: <input type="text" v-model="nome" />
    <button @click="cadastrar">Cadastrar</button>
    <input type="text" />
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "App",
  data() {
    return {
      info: null,
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
        .then((response) => (this.info = response.data));
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
</style>
