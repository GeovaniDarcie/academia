<template>
  <div class="main">
    <div class="right">
      <b-button
        pill
        @click="novoAluno"
        class="ml-2 mr-4 mb-2 altura"
        variant="dark"
      >
       Cadastrar Aluno
       <b-icon icon="plus-circle-fill" />
      </b-button
      >
    </div>

    <b-modal
      v-model="showModal"
      :title="this.editAluno ? 'Editar aluno' : 'Cadastrar aluno'"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
      class="modal"
      @ok="handleOk"
    >
      <ModalCadastro
        :aluno="aluno"
        :idAluno="idAluno"
        :mostrarModal="show"
        @mudaValorModal="mudaModal"
        @buscarAluno="buscarAluno"
      />
    </b-modal>  
    <b-table
      id="table-transition-example"
      :table-variant="'dark'"
      :items="items"
      :fields="fields"
      primary-key="a"
      hover
      fixed
      selectable
      :select-mode="'single'"
      :current-page="currentPage"
      @row-selected="onRowSelected"
      :tbody-transition-props="transProps"
    >
      <template #cell(opcoes)="row">
        <b-button
          size="sm"
          @click="editarAluno(row.item)"
          class="mr-1"
        >
          <b-icon icon="pencil-square"></b-icon>
        </b-button>
        <b-button
          size="sm"
          @click="deletarAluno(row.item)"
          class="mr-1"
        >
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
    <p>{{ aluno }}</p>
  </div>
</template>

<script>
import { mapState, mapMutations  } from 'vuex';
import ModalCadastro from "../../Components/ModalCadastro";
import { getAll, remover } from "../../Service/SalvarDados.js";

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
      totalRows: 1,
      perPage: 5,
    };
  },
  created() {
    this.buscarAluno();
  },

  mounted() {
    // Set the initial number of items
    this.totalRows = this.items.length;
  },
  computed: {
    items() {
      return this.alunos;
    },
    ...mapState(['aluno'])
  },

  methods: {
    ...mapMutations(['changeAluno']),
  
    onRowSelected(items) {
      this.selected = items;
    },
    mudaModal(payload) {
      this.show = payload;
    },

    novoAluno() {
      this.edit = false;
      this.show = true;
    },

    async buscarAluno() {
      this.alunos = await getAll();
    },

    async editarAluno(aluno) {
      this.editAluno = true;
      this.showModal = true;
      this.changeAluno(aluno);
    },

    async deletarAluno(aluno) {
      const deletado = await remover(aluno.id);
      if (deletado) {
        this.buscarAluno();
      }
    },

    handleOk() {
      console.log('oi')
    }
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
</style>