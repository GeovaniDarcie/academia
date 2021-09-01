<template>
  <div class="main">
    <ModalCadastro
      :idAluno="idAluno"
      :mostrarModal="show"
      @mudaValorModal="mudaModal"
      @buscarAluno="buscarAluno"
    />
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
      @row-selected="onRowSelected"
      :tbody-transition-props="transProps"
    >
      <template #cell(opcoes)="row">
        <b-button
          size="sm"
          @click="info(row.item, row.index, $event.target)"
          class="mr-1"
        >
          <b-icon icon="pencil-square"></b-icon>
        </b-button>
        <b-button
          size="sm"
          @click="info(row.item, row.index, $event.target)"
          class="mr-1"
        >
          <b-icon icon="trash-fill"></b-icon>
        </b-button>
      </template>
    </b-table>
  </div>
</template>

<script>
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
      transProps: {
        name: "flip-list",
      },
      fields: [
        { key: "id", sortable: true },
        { key: "nome", sortable: true },
        { key: "sobrenome", sortable: true },
        { key: "email", sortable: true },
        { key: "celular", sortable: true },
        { key: 'opcoes', label: 'Opções' }
      ],
    };
  },
  created() {
    this.buscarAluno();
  },

  computed: {
    items() {
      return this.alunos;
    },
  },

  methods: {
    onRowSelected(items) {
      this.selected = items;
      console.log(this.selected);
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

    async editarAluno(id) {
      this.mudaModal(true);
      this.idAluno = id;
    },

    async deletarAluno(id) {
      const deletado = await remover(id);
      if (deletado) {
        this.buscarAluno();
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
</style>