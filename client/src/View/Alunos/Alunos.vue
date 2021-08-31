<template>
  <div class="alunos">
      <Header />
      <Main />
  </div>
</template>

<script>
import Header from "../../Components/Header";
import Main from "./Main";

export default {
  name: "Alunos",
  components: {
    Header,
    Main,
  },
};
</script>

<style scoped>
 .alunos {
    height: 100vh;
    background-image: url(https://boaforma.abril.com.br/wp-content/uploads/sites/2/2017/01/thinkstockphotos-530414728.jpg);
    background-size: cover;
    background-repeat: no-repeat;
  }

  @media (max-width: 900px) {
    .alunos {
      background-image: none;
      background-color: rgb(85, 81, 81);
    }
  }
</style>