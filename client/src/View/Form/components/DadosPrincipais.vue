<template>
  <div>
    <b-form inline class="mt-3 ml-3">
      <b-form-group id="input-group-1" label="Nome: " label-for="input-1">
         <b-form-input
          id="input-1"
          v-model="nome"
          class="mr-2 ml-2"
          placeholder="Digite seu nome"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Sobrenome: " label-for="input-2">
         <b-form-input
          id="input-2"
          v-model="sobrenome"
          class="mr-2 ml-2"
          placeholder="Digite seu sobrenome"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Data de Nascimento: " label-for="input-3">
         <b-form-input
          id="input-3"
          v-model="dataDeNascimento"
          class="mr-2 ml-2"
          placeholder="Digite sua data de nascimento"
        ></b-form-input>
      </b-form-group>
      
      <b-form-group id="input-group-4" label="Sexo: " label-for="input-4">
         <b-form-group
          id="input-4"
          v-model="sexo"
          class="mr-2 ml-2"
        ></b-form-group>
      </b-form-group>

      <b-form-group id="input-group-5" label="Cpf: " label-for="input-5">
         <b-form-group
          id="input-5"
          v-model="cpf"
          class="mr-2 ml-2"
        ></b-form-group>
      </b-form-group>


       
        <b-button variant="primary" @click="cadastrar">Salvar</b-button>
    
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
    </b-form>  
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

/* .lista {
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
} */
</style>