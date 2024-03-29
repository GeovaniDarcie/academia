<template>
  <div class="main">
      <b-alert
        v-for="(mensagem, index) in mensagensDeErro"
        :key="index"
        class="error"
        :show="dismissCountDown"
        dismissible
        variant="danger"
        @dismissed="dismissCountDown=0"
        @dismiss-count-down="countDownChanged"
      >
      {{ mensagem }}
    </b-alert>
    <div class="right">
      <b-button @click="novoAluno" class="ml-2 mr-4 mb-2" variant="dark">
        Cadastrar Aluno
        <b-icon icon="plus-circle-fill" />
      </b-button>
    </div>

    <b-modal
      v-model="showModal"
      :title="this.editAluno ? 'Editar aluno' : 'Cadastrar aluno'"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
      @ok="handleOk"
    >
      <ModalCadastro />

      <template #modal-footer="{ ok, cancel }">
        <b>Academia</b>
        <b-button variant="success" @click="ok()"> Salvar </b-button>
        <b-button variant="danger" @click="cancel()"> Cancelar </b-button>
      </template>
    </b-modal>

    <b-table
      :table-variant="'dark'"
      :items="alunos"
      :fields="fields"
      primary-key="a"
      hover
      fixed
      selectable
      :select-mode="'single'"
      :current-page="0"
      :tbody-transition-props="transProps"
    >
      <template #cell(opcoes)="row">
        <b-dropdown class="mr-1 menu-suspenso" size="sm" no-caret>
          <template #button-content>
            <b-icon icon="arrow-down-circle-fill"></b-icon>
          </template>
          <b-dropdown-item :to="{ name: 'avaliacao', params: { aluno: row.item }}">Avaliação Física</b-dropdown-item>
          <b-dropdown-item :to="{ path: `treino/${row.item.id}`, params: { aluno: row.item }}">Treinos</b-dropdown-item>
        </b-dropdown>
        <b-button size="sm" @click="editarAluno(row.item)" class="mr-1">
          <b-icon icon="pencil-square"></b-icon>
        </b-button>
        <b-button size="sm" @click="deletarAluno(row.item)" class="mr-1">
          <b-icon icon="trash-fill"></b-icon>
        </b-button>
      </template>
    </b-table>

    <b-col sm="7" md="6" class="my-1">
      <b-pagination
        v-model="currentPage"
        :total-rows="totalRows"
        :per-page="perPage"
        align="fill"
        size="sm"
        class="my-0"
      ></b-pagination>
    </b-col>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";
import { getAll, post, updated, deleteId } from "../../Service/api.js";
import ModalCadastro from "../../Components/ModalCadastro";

export default {
  name: "Main",
  components: {
    ModalCadastro,
  },
  data() {
    return {
      alunos: [],
      show: false,
      edit: false,
      idAluno: 0,
      showModal: false,
      backgroundModal: "dark",
      editAluno: false,
      textModal: "light",
      dismissSecs: 5,
      dismissCountDown: 0,
      mensagensDeErro: [],
      transProps: {
        name: "flip-list",
      },
      fields: [
        { key: "id", sortable: true },
        { key: "nome", sortable: true },
        { key: "sobrenome", sortable: true },
        { key: "cpf", sortable: true },
        { key: "celular", sortable: true },
        { key: "opcoes", label: "Opções" },
      ],
      currentPage: 1,
      totalRows: 0,
      perPage: 5,
    };
  },

  mounted() {
    this.buscaAlunos();
  },

  watch: {
    currentPage: {
      handler() {
        this.buscaAlunos();
      }
    }
  },

  computed: {
    items() {
      return this.alunos;
    },

    ...mapState(["aluno", "errors"]),
  },

  methods: {
    ...mapActions(["changeAluno"]),
    
    countDownChanged(dismissCountDown) {
        this.dismissCountDown = dismissCountDown
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs
    },
    async buscaAlunos() {
      const academiaId = localStorage.getItem("academiaId");
      const dadosPagina = { limit: this.perPage, page: this.currentPage, academiaId};
      const response = await getAll(dadosPagina, './alunos');
      this.totalRows = response.totalItems
      this.alunos = response.items;
    },

    novoAluno() {
      // limpa a store (state aluno)
      this.changeAluno({});

      this.editAluno = false;
      this.showModal = true;
    },

    editarAluno(aluno) {
      this.editAluno = true;
      this.showModal = true;

      //seta o state com o objeto aluno
      this.changeAluno(aluno);
    },

    async deletarAluno(aluno) {
      const deletado = await deleteId(aluno.id, './alunos');

      if (deletado) {
        const academiaId = localStorage.getItem("academiaId");
        const dadosPagina = { limit: this.perPage, page: this.currentPage, academiaId };
        const response = await getAll(dadosPagina, './alunos');
        this.alunos = response.items;
      }
    },

    async handleOk() {
      if (this.editAluno) {
        const aluno = await updated(this.aluno.id, this.aluno, './alunos');
        const index = this.alunos.findIndex((a) => a.id === aluno.id);
        this.$set(this.alunos, index, aluno);
      } else {
        const academiaId = localStorage.getItem("academiaId");
        const aluno = await post({ ...this.aluno, academiaId } , './alunos');
        
        if (!aluno) {
          this.mensagensDeErro = [];
          Object.entries(this.errors).forEach(([ , value]) => {
            this.mensagensDeErro.push(value[0])
          });
          this.showAlert();
        }
        await this.buscaAlunos();
      }
    },
  },
};
</script>

<style>
.main {
  margin: 0 auto;
  padding: 110px;
}
.lista {
  opacity: 1;
}

.right {
  display: flex;
  justify-content: flex-end;
}

/* .menu-suspenso{
  width: 31;
  height: 35.5;
  margin: 0px 4px 0px 0px;
  padding: 4px 8px;
} */

.error {
  width: 400px; 
  height: 50px; 
/*   margin-right: 5px; 
  position: fixed;
  z-index: 1050;
  justify-content: center;
  align-content: center; */
}
</style>