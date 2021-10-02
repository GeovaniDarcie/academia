<template>
  <div>
    <b-card no-body class="avaliacao bg-dark">
      <b-tabs card>
        <b-tab title="Anamnese" class="active table">
          <div>
            <b-form-group class="input-size">
              Habitos Gerais:
              <b-form-textarea
                id="textarea"
                v-model="habitos"
                placeholder="Digite os hábitos..."
                rows="3"
                max-rows="6"
              ></b-form-textarea>
            </b-form-group>

            <b-form-group class="input-size">
              Sedentarismo:
              <b-form-select
                v-model="sedentarismo"
                :options="options"
              ></b-form-select>
            </b-form-group>

            <b-form-group class="input-size">
              Cirurgias:
              <b-form-textarea
                id="textarea"
                v-model="cirurgias"
                placeholder="Digite as cirugias realizadas..."
                rows="3"
                max-rows="6"
              ></b-form-textarea>
            </b-form-group>

            <b-form-group class="input-size">
              Aluno Id:
              <b-form-input
                v-model="alunoId"
                style="width: 200px; display: inline; margin: 5px; height: 40px"
              />
              <b-button
                @click="salvar"
                style="height: 40px; margin-left: 100px"
              >
                Salvar
              </b-button>
            </b-form-group>
          </div>
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
        <b-tab title="Antropometria" class="active table">
          <div>
            <b-form-group class="input-size">
              Peso:
              <b-form-input
                id="textarea"
                v-model="habitos"
                placeholder="Digite o peso..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Altura:
              <b-form-input
                v-model="sedentarismo"
                :options="options"
                placeholder="Digite a altura"
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Percentual de gordura:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Digite o percentual de gordura..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Massa muscular:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Digite a massa muscular..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Aluno Id:
              <b-form-input
                v-model="alunoId"
                style="width: 200px; display: inline; margin: 5px; height: 40px"
              />
              <b-button
                @click="salvar"
                style="height: 40px; margin-left: 100px"
              >
                Salvar
              </b-button>
            </b-form-group>
          </div>
          <div class="coluna2">
            <img width="300px" height="300px" src="../../../corpo.png" alt="" />
          </div>
        </b-tab>
        <b-tab title="Dobras Cutâneas" class="active table">
          <div class="grid">
            <b-form-group class="input-size mr-2">
              Triciptal:
              <b-form-input
                id="textarea"
                v-model="habitos"
                placeholder="Triciptal..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Subescapular:
              <b-form-input
                v-model="sedentarismo"
                :options="options"
                placeholder="Subescapular"
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size mr-2">
              Biciptal:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Digite o percentual de gordura..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Axilar Média:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Axilar Média..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size mr-2">
              Supra Iliaca:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Supra Iliaca..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Torácica:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Toracica..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size mr-2">
              Abdominal:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Abdominal..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Panturrilha Medial:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Panturrilha Medial..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size">
              Aluno Id:
              <b-form-input
                id="textarea"
                v-model="cirurgias"
                placeholder="Panturrilha Medial..."
              ></b-form-input>
            </b-form-group>

            <b-form-group class="input-size mt-50">
              <b-button
                @click="salvar"
                style="height: 40px; margin-left: 100px; margin-top: 24px"
              >
                Salvar
              </b-button>
            </b-form-group>
          </div>
          <div class="coluna2">
            <img width="300px" height="300px" src="../../../corpo.png" alt="" />
          </div>
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
  width: 80vw;
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
}
</style>