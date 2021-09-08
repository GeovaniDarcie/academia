<template>
        <div class="containar login bg-dark">
                <label for="" style="margin-top: 55px">Username: </label>
                <input v-model="username" type="text">

                <label for="" style="margin-top: 40px">Password: </label>
                <input v-model="password" type="password">

                <b-button @click="logar" style="margin-top: 55px">Entrar</b-button>
                <vue-loading v-show="loading" type="spin" color="#d9544e" :size="{ width: '50px', height: '50px' }"></vue-loading>    
        </div>
</template>

<script>
import { login } from '../../Service/api';

 import { VueLoading } from 'vue-loading-template'

export default {
    data() {
        return {
            username: '',
            password: '',
        }
    },
    computed: {
        loading() {
            console.log(this.$store.state.loading);
           return this.$store.state.loading;
        }
    },
    methods: {
        async logar() {
           const validou = await login(this.username, this.password)
           if(validou) {
               this.$store.state.autenticado = validou;
               this.$router.push({ name: 'alunos' })
           } else {
               this.username = '';
               this.password = '';
           }
        }
    },
    components: {
        VueLoading
    }
}
</script>

<style>
    .containar {
        width: 100vh;
        margin: 0 auto;
        display: flex;
        align-items: center;
        justify-content: space-around;
        flex-direction: column;
    }

    .login {
        width: 840px;
        height: 60vh;
        margin-top: 100px;
        border-radius: 10px;
        display: flex;
        align-items: center;
        color: white;
    }
</style>