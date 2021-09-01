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
 
</style>