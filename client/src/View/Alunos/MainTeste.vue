<template>
  <div class="main">
    <div class="right">
      <b-button
        pill
        @click="novoAluno"
        class="ml-2 mr-4 mb-2 altura"
        variant="info"
        >Novo Aluno</b-button
      >
    </div>

    <ModalCadastro
      :idAluno="idAluno"
      :mostrarModal="show"
      @mudaValorModal="mudaModal"
      @buscarAluno="buscarAluno"
    />
    
    <b-list-group class="lista">
      
      <b-list-group-item
        variant="secondary"
        button
        class="elementosDaLista"
      >
        <b>Nome completo</b>
        <b>Email</b>
        <b>Cel</b>
        <b>CPF</b>
        <b>Data da Matrícula</b> 
        <b>Editar</b> 
        <b>Opções</b> 
        <b>Excluir</b> 
      </b-list-group-item>
      <b-list-group-item
        v-for="aluno in alunos"
        :key="aluno.id"
        variant="secondary"
        button
        class="elementosDaLista"
      >
        <span> 
          {{ `${aluno.nome} ${aluno.sobrenome}` }}
        </span>
        <span> {{ aluno.email }}</span>
        <span> {{ aluno.celular }}</span>
        <span>{{ aluno.cpf }}</span>
        <span>
          {{
            new Date(aluno.inicioDeMatricula).toLocaleDateString("pt-BR", {
              timeZone: "UTC",
            })
          }}</span
        >
        <b-icon
          class="icones"
          icon="pencil-square"
          variant="info"
          aria-hidden="true"
          @click="editarAluno(aluno.id)"
        ></b-icon>

        <b-icon
          class="icones"
          icon="list-ul"
          variant="info"
          aria-hidden="true"
          @click="editarAluno(aluno.id)"
        ></b-icon>

        <b-icon
          class="icones"
          icon="trash-fill"
          variant="danger"
          aria-hidden="true"
          @click="deletarAluno(aluno.id)"
        ></b-icon>
      </b-list-group-item>
    </b-list-group>
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
    };
  },
  created() {
    this.buscarAluno();
  },
  methods: {
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
      this.idAluno = id
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

<style scoped>
.titulo {
  font-size: 2em;
  text-align: flex-start;
  color: rgb(95, 91, 91);
}

.right {
  display: flex;
  justify-content: flex-end;
}

.altura {
  margin-top: 100px;
}

.lista {
  opacity: 0.9;
}
.elementosDaLista {
  display: flex;
  justify-content: space-around;
}

@media (max-width: 900px) {
  body {
    background-image: none;
    background-color: rgb(85, 81, 81);
  }

  .elementosDaLista {
    display: flex;
    flex-direction: column;
  }

  .icones {
    align-self: flex-end;
    margin: 5px;
  }
}
</style>