<template>
  <div>
    <b-cardy>
      <b-row> AAAA </b-row>
    </b-cardy>
    <b-form inline class="mt-3 ml-3">
      <label>Nome: </label>
      <b-form-input
        v-model="nome"
        class="mr-2 ml-2"
        placeholder="Digite seu nome"
      ></b-form-input>
      <b-button variant="primary" @click="cadastrar">Salvar</b-button>
    </b-form>
    <b-list-group
      inline
      class="lista mt-3 ml-3"
      v-for="aluno in alunos"
      :key="aluno.id"
    >
      <b-list-group-item>
        <input
          class="elementoLista"
          v-model="aluno.nome"
          :disabled="desabilita"
        />
      </b-list-group-item>
      <div>
        <b-button variant="info" class="botao mr-2" @click="desabilita = false"
          >Editar</b-button
        >
        <b-button variant="success" class="botao mr-2" @click="atualizar(aluno)"
          >Atualizar</b-button
        >
        <b-button variant="danger" class="botao" @click="remover(aluno.id)"
          >Excluir</b-button
        >
      </div>
    </b-list-group>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "DadosPrincipais",
  data() {
    return {
      alunos: null,
      nome: "",
      desabilita: true,
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
      this.nome = "";
    },

    buscar() {
      axios
        .get("https://localhost:5001/Aluno")
        .then((response) => (this.alunos = response.data));
    },

    atualizar(aluno) {
      this.desabilita = true;
      axios.put("https://localhost:5001/Aluno", {
        nome: aluno.nome,
        id: aluno.id,
      });
    },

    remover(id) {
      console.log(id);
      axios.delete(`https://localhost:5001/Aluno/${id}`).then((response) => {
        if (response.status == 200) {
          this.buscar();
        }
      });
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

.botao {
  max-width: 100px;
  display: inline;
}

.elementoLista {
  width: 300px;
  background-color: white;
  border: none;
}

.elementoLista:focus {
  box-shadow: 0 0 0 0;
  outline: 0;
}
</style>