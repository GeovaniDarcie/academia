<template>
  <div class="form">
      <Header />
      <Main />
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Main from "./components/Main.vue";

export default {
  name: "Form",
  components: {
    Header,
    Main,
  },
};
</script>

<style scoped>
 .form {
    height: 100vh;
    background-image: url(https://boaforma.abril.com.br/wp-content/uploads/sites/2/2017/01/thinkstockphotos-530414728.jpg);
    background-size: cover;
    background-repeat: no-repeat;
  }

  @media (max-width: 900px) {
    .form {
      background-image: none;
      background-color: rgb(85, 81, 81);
    }
  }
</style>