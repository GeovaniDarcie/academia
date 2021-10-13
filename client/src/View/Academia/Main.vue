<template>
  <div class="main">
    <div class="right">
      <b-button @click="novaAcademia" class="ml-2 mr-4 mb-2" variant="dark">
        Cadastrar Academia
        <b-icon icon="plus-circle-fill" />
      </b-button>
    </div>

    <b-modal
      v-model="showModal"
      :title="this.editAcademia ? 'Editar academia' : 'Cadastrar academia'"
      :header-bg-variant="backgroundModal"
      :header-text-variant="textModal"
      :footer-bg-variant="backgroundModal"
      :footer-text-variant="textModal"
      @ok="handleOk"
    >
      <ModalAcademia />

      <template #modal-footer="{ ok, cancel }">
        <b>Academia</b>
        <b-button variant="success" @click="ok()"> Salvar </b-button>
        <b-button variant="danger" @click="cancel()"> Cancelar </b-button>
      </template>
    </b-modal>

    <b-table
      :table-variant="'dark'"
      :items="academias"
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
        <b-button size="sm" @click="editarAcademia(row.item)" class="mr-1">
          <b-icon icon="pencil-square"></b-icon>
        </b-button>
        <b-button size="sm" @click="deletarAcademia(row.item)" class="mr-1">
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
import { getAll, criaAcademia, atualizaAcademia, deletaAcademia } from "../../Service/api.js";
import ModalAcademia from "../../Components/ModalAcademia";

export default {
  name: "Main",
  components: {
    ModalAcademia,
  },
  data() {
    return {
      academias: [],
      show: false,
      edit: false,
      idAcademia: 0,
      showModal: false,
      backgroundModal: "dark",
      editAcademia: false,
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
        { key: "endereco", sortable: true },
        { key: "email", sortable: true },
        { key: "opcoes", label: "Opções" },
      ],
      currentPage: 1,
      totalRows: 0,
      perPage: 5,
    };
  },

  mounted() {
    this.buscaAcademias();
  },

  watch: {
    currentPage: {
      handler() {
        this.buscaAcademias();
      }
    }
  },

  computed: {
    items() {
      return this.academias;
    },

    ...mapState(["academia", "errors"]),
  },

  methods: {
    ...mapActions(["changeAcademia"]),
    
    countDownChanged(dismissCountDown) {
        this.dismissCountDown = dismissCountDown
    },
    showAlert() {
      this.dismissCountDown = this.dismissSecs
    },
    async buscaAcademias() {
      const response = await getAll({}, './academiaentity');
      this.totalRows = 10;
      this.academias = response;
    },

    novaAcademia() {
      // limpa a store (state Academia)
      this.changeAcademia({});

      this.editAcademia = false;
      this.showModal = true;
    },

    editarAcademia(academia) {
      this.editAcademia = true;
      this.showModal = true;

      //seta o state com o objeto Academia
      this.changeAcademia(academia);
    },

    async deletarAcademia(academia) {
      const deletado = await deletaAcademia(academia.id);

      if (deletado) {
        const response = await getAll({}, './academiaentity');
        this.academias = response.items;
      }
    },

    async handleOk() {
      if (this.editAcademia) {
        const academia = await atualizaAcademia(this.academia.id, this.academia);
        const index = this.academias.findIndex((a) => a.id === academia.id);
        this.$set(this.academias, index, academia);
      } else {
        const academia = await criaAcademia(this.academia);
        
        if (!academia) {
          this.mensagensDeErro = [];
          Object.entries(this.errors).forEach(([ , value]) => {
            this.mensagensDeErro.push(value[0])
          });
          console.log(this.mensagensDeErro);
          this.showAlert();
        }
        await this.buscaAcademias();
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