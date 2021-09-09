<template>
  <div class="treino-container">
    <div class="treino bg-dark" style="opacity: 0.9;">
      <div>
        <h2 class="ml-3 titulo-treino font-treino">Treino</h2>
      </div>
      <hr class="mt-2" style="border: 1px solid white" />
      <b-row class="mb-1 ml-3">
        <b-col>
          Dia da semana:
          <b-form-select 
            @change="onChange()" placeholder="Nome"
            :options="options"
            v-model="selected"
          >
          </b-form-select>
        </b-col>
        <b-col>
          Treino:
          <b-form-input
            placeholder="Treino"
            v-model="descricao"
            :disabled="!selected"
          ></b-form-input>
        </b-col>
        <b-col>
          Séries:
          <b-form-input
            type="number"
            placeholder="Séries"
            v-model="series"
            :disabled="!selected"
          ></b-form-input>
        </b-col>
        <b-col>
          Repetições:
          <b-form-input
            type="number"
            placeholder="Repetições"
            v-model="repeticoes"
            :disabled="!selected"
          ></b-form-input>
        </b-col>
        <b-button class="adicionar" @click="adicionar()">Adicionar</b-button>
      </b-row> 
      <table class="table atividades mt-4">
        <tr>
          <th>Treino</th>
          <th>Séries</th>
          <th>Repetições</th>
        </tr>
        <tr v-for="a in atividades" :key="a.descricao">
          <td>
            {{ a.descricao }}
          </td>
          <td>
            {{ a.series }}
          </td>
          <td>
            {{ a.repeticoes }}
          </td>
        </tr>
      </table>
      <h5 class="mr-3 final">
            <span class="font-treino">Aluno: </span>
            <b class="text-info">{{ nomeCompleto }}</b>
      </h5>
    </div>
  </div>
</template>

<script>
import { criarTreino, criarAtividade } from "../../Service/api";

export default {
  data() {
    return {
      treinoId: 0,
      descricao: "",
      series: 0,
      repeticoes: 0,
      atividades: [],
      options: [
        { value: 0, text: "Não informado" },
        { value: 1, text: "Domingo" },
        { value: 2, text: "Segunda-feira" },
        { value: 3, text: "Terça-feira" },
        { value: 4, text: "Quarta-feira" },
        { value: 5, text: "Quinta-feira" },
        { value: 6, text: "Sexta-feira" },
        { value: 7, text: "Sábado" },
      ],
      selected: null,
    };
  },
  computed: {
    nomeCompleto() {
      return `${this.$route.params.aluno.nome} ${this.$route.params.aluno.sobrenome}`;
    },
    alunoId() {
      return this.$route.params.aluno.id
    }
  },
  methods: {
    async onChange() {
      console.log(this.selected)
      if (this.selected) {
        const data = await criarTreino(this.selected);
        this.treinoId = data.id;
      }
    },

    async adicionar() {
      const atividade = {
        descricao: this.descricao,
        series: this.series,
        repeticoes: this.repeticoes,
      }
  
      this.atividades.push(atividade);

      const response = await criarAtividade({
        ...atividade, 
        treinoId: this.treinoId,
        alunoId: this.alunoId
      });

      console.log(response);

      this.descricao = "";
      this.series = "";
      this.repeticoes = "";
    },
  },
};
</script>

<style scoped>
.treino-container {
  display: flex;
  justify-content: center;
  width: 100%;
  height: 100vh;
  align-items: center;
  color: white;
}
.treino {
  position: relative;
  margin-top: 90px;
  width: 1000px;
  height: 510px;
}

.atividades {
  color: white;
}

.titulo-treino {
  font-size: 3rem;
  display: inline;
}

.font-treino {
  font-family: "Text Me One", sans-serif;
}

.adicionar{
  width: 90px;
  height: 40px;
  margin-right: 50px;
  margin-top: 20px;
}

.final {
  position: absolute;
  bottom: 0;
  right: 0;
}

</style>