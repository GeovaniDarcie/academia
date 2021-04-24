<template>
  <div>
    <b-modal
      v-model="showModal"
      title="Cadastro"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
    >
      <b-container fluid>
        <b-row class="mb-1">
          <b-col>
            <b-form-input
              v-model="aluno.nome"
              placeholder="Nome"
            ></b-form-input>
          </b-col>
          <b-col>
            <b-form-input
              v-model="aluno.sobrenome"
              placeholder="Sobrenome"
            ></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1">
          <b-col>
            <b-form-input
              v-model="aluno.email"
              placeholder="Email"
            ></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1">
          <b-col>
            <b-form-input
              v-model="aluno.celular"
              placeholder="Celular"
            ></b-form-input>
          </b-col>
          <b-col>
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

      <template #modal-footer>
        <div class="w-100">
          <p class="float-left">Nome da Academia</p>
          <b-button
            variant="secondary"
            size="sm"
            class="float-right"
            @click="salvar"
          >
            Salvar
          </b-button>
        </div>
      </template>
    </b-modal>
  </div>
</template>

<script>
import { cadastrar, buscar } from "../../../Service/SalvarDados.js";

export default {
  name: "ModalCadastro",
  props: {
    mostrarModal: Boolean,
    edicaoUsuario: Boolean,
    idAluno: Number,
  },
  data() {
    return {
      backgroundModal: "dark",
      textModal: "light",
      aluno: {
        nome: "",
        sobrenome: "",
        email: "",
        celular: "",
        cpf: "",
        dataDeNascimento: "",
        genero: "",
        inicioDeMatricula: "",
      },

      options: [
        { item: "A", name: "Masculino" },
        { item: "B", name: "Feminino" },
      ],
    };
  },
  methods: {
    async salvar() {
      this.showModal = false;
      const value = await cadastrar(this.aluno);
      if (value) {
        this.$emit("buscarAluno");
      }
    },
  },
  computed: {
    showModal: {
      get() {
        return this.mostrarModal;
      },
      set(newValue) {
        this.$emit("mudaValorModal", newValue);
      },
    },
  },

  watch: {
    async edicaoUsuario() {
      this.aluno = await buscar();
      console.log(this.aluno);
    },
  },
};
</script>