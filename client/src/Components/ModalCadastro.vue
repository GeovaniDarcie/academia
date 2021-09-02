<template>
  <div>
    <b-modal
      v-model="showModal"
      :title="this.editAluno ? 'Editar aluno' : 'Cadastrar aluno'"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
      class="modal"
    >
      <b-container fluid>
        <b-row class="mb-1">
          <b-col>
            Nome:
            <b-form-input
              v-model="aluno.nome"
              placeholder="Nome"
            ></b-form-input>
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
            <b-form-input
              v-model="aluno.email"
              placeholder="Email"
            ></b-form-input>
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
import { cadastrar, getById, updated } from "../Service/SalvarDados";

export default {
  name: "ModalCadastro",
  props: {
    mostrarModal: Boolean,
    idAluno: Number,
    editAluno: Boolean,
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
    limpaCamposAlunos() {
      this.aluno = {}
    },

    async salvar() {
      this.showModal = false;
      if (this.editAluno) {
        const value = await updated(this.idAluno, this.aluno)
        if (value) {
          this.$emit("buscarAluno");
        }
      } else {
        const value = await cadastrar(this.aluno);
        if (value) {
          this.$emit("buscarAluno");
        }
      }
    },

    async buscarPorId(id) {
      console.log('aa')
      const alunoDb = await getById(id);
      this.aluno = { ...alunoDb }
      this.aluno.dataDeNascimento = new Date(this.aluno.dataDeNascimento).toISOString().split('T')[0];
      this.aluno.inicioDeMatricula = new Date(this.aluno.inicioDeMatricula).toISOString().split('T')[0];
    }
  },
  computed: {
    showModal: {
      get() {
        if(!this.mostrarModal) {
          this.limpaCamposAlunos()
        }
          
        return this.mostrarModal;
      },
      set(newValue) {
        this.$emit("mudaValorModal", newValue);
      },
    },
  },

  watch: {
    idAluno() {
      this.buscarPorId(this.idAluno);
    }
  }

};
</script>
