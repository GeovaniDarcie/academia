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
      <b-button @click="novoProfessor" class="ml-2 mr-4 mb-2" variant="dark">
        Cadastrar professor
        <b-icon icon="plus-circle-fill" />
      </b-button>
    </div>

    <b-modal
      v-model="showModal"
      :title="this.editprofessor ? 'Editar professor' : 'Cadastrar professor'"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
      @ok="handleOk"
    >
      <ModalProfessor />

      <template #modal-footer="{ ok, cancel }">
        <b>Academia</b>
        <b-button variant="success" @click="ok()"> Salvar </b-button>
        <b-button variant="danger" @click="cancel()"> Cancelar </b-button>
      </template>
    </b-modal>

    <b-table
      :table-variant="'dark'"
      :items="professores"
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
        <b-button size="sm" @click="editarprofessor(row.item)" class="mr-1">
          <b-icon icon="pencil-square"></b-icon>
        </b-button>
        <b-button size="sm" @click="deletarProfessor(row.item)" class="mr-1">
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
import ModalProfessor from "../../Components/ModalProfessor";

export default {
  name: "Main",
  components: {
    ModalProfessor,
  },
  data() {
    return {
      professores: [],
      show: false,
      edit: false,
      idprofessor: 0,
      showModal: false,
      backgroundModal: "dark",
      editprofessor: false,
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
        { key: "email", sortable: true },
        { key: "opcoes", label: "Opções" },
      ],
      currentPage: 1,
      totalRows: 0,
      perPage: 5,
    };
  },

  mounted() {
    this.buscaprofessores();
  },

  watch: {
    currentPage: {
      handler() {
        this.buscaprofessores();
      }
    }
  },

  computed: {
    items() {
      return this.professores;
    },

    ...mapState(["professor", "errors"]),
  },

  methods: {
    ...mapActions(["changeProfessor"]),
    
    countDownChanged(dismissCountDown) {
        this.dismissCountDown = dismissCountDown
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs
    },
    async buscaprofessores() {
      const academiaId = localStorage.getItem("academiaId");
      const dadosPagina = { limit: this.perPage, page: this.currentPage, academiaId};
      const response = await getAll(dadosPagina, './professores');
      this.totalRows = response.totalItems
      this.professores = response.items;
    },

    novoProfessor() {
      // limpa a store (state professor)
      this.changeProfessor({});

      this.editprofessor = false;
      this.showModal = true;
    },

    editarprofessor(professor) {
      this.editprofessor = true;
      this.showModal = true;

      //seta o state com o objeto professor
      this.changeProfessor(professor);
    },

    async deletarProfessor(professor) {
      const deletado = await deleteId(professor.id, './professores');

      if (deletado) {
        const academiaId = localStorage.getItem("academiaId");
        const dadosPagina = { limit: this.perPage, page: this.currentPage, academiaId };
        const response = await getAll(dadosPagina, './professores');
        this.professores = response.items;
      }
    },

    async handleOk() {
      if (this.editprofessor) {
        const professor = await updated(this.professor.id, this.professor, './professores');
        const index = this.professores.findIndex((a) => a.id === professor.id);
        this.$set(this.professores, index, professor);
      } else {
        const academiaId = localStorage.getItem("academiaId");
        const professor = await post({ ...this.professor, academiaId } , './professores');
        
        if (!professor) {
          this.mensagensDeErro = [];
          Object.entries(this.errors).forEach(([ , value]) => {
            this.mensagensDeErro.push(value[0])
          });
          console.log(this.mensagensDeErro);
          this.showAlert();
        }
        await this.buscaprofessores();
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