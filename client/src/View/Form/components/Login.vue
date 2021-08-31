<template>
  <div class="containar">
      <div class="login">
          <label for="">Username: </label>
          <input v-model="username" type="text">

          <label for="">Password: </label>
          <input v-model="password" type="text">

          <button @click="logar">Logar</button>
      </div>
  </div>
</template>

<script>
import { login } from '../../../Service/SalvarDados';

export default {
    data() {
        return {
            username: '',
            password: '',
        }
    },
    methods: {
        async logar() {
           const teste = await login(this.username, this.password)
           console.log(teste);
           this.$router.push({ name: 'home' })
        }
    }
}
</script>

<style>
    .containar {
        width: 100vh;
        height: 100vh;
        margin: 0 auto;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .login {
        width: 840px;
        height: 90vh;
        background: rgb(26, 24, 24);
        border-radius: 10px;
        display: flex;
        align-items: center;
        justify-content: center;
        color: white;
    }
</style>