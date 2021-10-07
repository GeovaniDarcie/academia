<template>
  <div>
    <b-card no-body class="avaliacao bg-dark">
      <b-tabs card>
        <b-tab title="Anamnese" :title-link-class="'text-info'" class="active table">
          <div>
            <b-form-group class="input-size campos">
              Hábitos gerais:
              <b-form-textarea
                class="mt-2 campos"
                v-model="habitos"
                placeholder="Digite os hábitos..."
                rows="2"
                max-rows="6"
              ></b-form-textarea>
            </b-form-group>

            <b-form-group class="input-size">
              Sedentarismo:
              <b-form-select
                class="mt-2 campos"
                v-model="sedentarismo"
                :options="options"
              ></b-form-select>
            </b-form-group>

            <b-form-group class="input-size">
              Cirurgias:
              <b-form-textarea
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Digite as cirugias realizadas..."
                rows="2"
                max-rows="6"
              ></b-form-textarea>
            </b-form-group>

          </div>
          <b-form-group class="">
            <b-button
              @click="salvar"
              class="mr-4 mb-4 final campos"
            >
              Salvar
            </b-button>
          </b-form-group>
          <div class="coluna2">
            <template>
              <model-viewer src="scene.gltf" alt="A 3D model of a car" shadow-intensity="1" camera-controls auto-rotate ar ></model-viewer>
              <script
                type="application/javascript" defer
                src="https://unpkg.com/@google/model-viewer/dist/model-viewer.min.js"
              ></script>
              <script
               type="application/javascript" defer
                nomodule
                src="https://unpkg.com/@google/model-viewer/dist/model-viewer-legacy.js"
              ></script>
            </template>
          </div>
        </b-tab>
        <b-tab title="Antropometria" :title-link-class="'text-info'" class="active table">
          <div>
            <b-form-group class="">
              Peso:
              <b-form-input
                class="mt-2 campos"
                v-model="peso"
                placeholder="Digite o peso..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Altura:
              <b-form-input
                class="mt-2 campos"
                v-model="sedentarismo"
                :options="options"
                placeholder="Digite a altura"
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Percentual de gordura:
              <b-form-input
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Digite o percentual de gordura..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Massa muscular:
              <b-form-input
                class="mt-2 campos"
                v-model="massa"
                placeholder="Digite a massa muscular..."
              ></b-form-input>
            </b-form-group>
          </div>
          <b-form-group class="">
            <b-button
              @click="salvar"
              class="mr-4 mb-4 final campos"
            >
              Salvar
            </b-button>
          </b-form-group>
          <div class="coluna2">
            <img width="300px" height="300px" src="../../../corpo.png" alt="" />
          </div>
        </b-tab>
        <b-tab title="Dobras Cutâneas" :title-link-class="'text-info'" class="active table">
          <div class="grid">
            <b-form-group class="ml-4">
              Triciptal:
              <b-form-input
                class="mt-2 campos"
                v-model="habitos"
                placeholder="Triciptal..."
              ></b-form-input>
            </b-form-group>

            <b-form-group>
              Subescapular:
              <b-form-input
                class="mt-2 campos"
                v-model="sedentarismo"
                :options="options"
                placeholder="Subescapular"
              ></b-form-input>
            </b-form-group>

            <b-form-group class="ml-4">
              Biciptal:
              <b-form-input
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Digite o percentual de gordura..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Axilar Média:
              <b-form-input
                v-model="cirurgias"
                class="mt-2 campos"
                placeholder="Axilar Média..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="ml-4">
              Supra Iliaca:
              <b-form-input
                v-model="cirurgias"
                class="mt-2 campos"
                placeholder="Supra Iliaca..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Torácica:
              <b-form-input
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Toracica..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="ml-4">
              Abdominal:
              <b-form-input
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Abdominal..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="">
              Panturrilha Medial:
              <b-form-input
                class="mt-2 campos"
                v-model="cirurgias"
                placeholder="Panturrilha Medial..."
              ></b-form-input>
            </b-form-group>
          </div>
          <b-form-group class="">
            <b-button
              @click="salvar"
              class="mr-4 mb-4 final campos"
            >
              Salvar
            </b-button>
          </b-form-group>
        </b-tab>
      </b-tabs>
    </b-card>
  </div>
</template>

<script>
import { post } from "../../Service/AvaliacaoService";

export default {
  name: "Main",
  data() {
    return {
      options: [
        { value: null, text: "Selecione uma opção" },
        { value: "1", text: "Nenhuma atividade realmente intensa é realizada" },
        {
          value: "2",
          text: "Dificilmente pensa em separar um tempo exclusivamente para mexer seu corpo",
        },
        {
          value: "3",
          text: "Prefere fazer tudo de carro e detesta carregar peso",
        },
        { value: "2", text: "Passa o dia todo sentado ou deitado" },
      ],
      habitos: "",
      sedentarismo: "",
      cirurgias: "",
      alunoId: "",
    };
  },
  methods: {
    salvar() {
      const anamnese = {
        habitosGerais: this.habitos,
        sedentarismo: this.sedentarismo,
        cirurgias: this.cirurgias,
        alunoId: this.alunoId,
      };

      post(anamnese);
    },
  },
};
</script>

<style scoped>
.avaliacao {
  margin: 0 auto;
  margin-top: 120px;
  color: white;
  width: 600px;
  height: 75vh;
  font-size: 1.1rem;
}

/* .coluna1 {
  display: inline;
  width: 300px;
} */

.coluna2 {
  float: right;
  width: 300px;
}

.table {
  color: white;
  display: flex;
  justify-content: space-between;
  margin: 5px;
}

img {
  display: inline;
}

.grid {
  display: grid;
  grid-template-columns: 3fr 3fr;
  column-gap: 60px;
}

.campos {
  border-radius: 10px;
}

.input-size {
  width: 400px;
}

.final {
  position: absolute;
  width: 100px;
  height: 50px;
  bottom: 0;
  right: 0;
}
</style>