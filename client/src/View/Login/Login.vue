<template>
        <div class="containar login bg-dark" style="opacity: 0.9">
                <label v-show="!loading" for="" style="margin-top: 55px">Username: </label>
                <input v-show="!loading" style="border-radius: 10px" v-model="username" type="text">

                <label v-show="!loading" for="" style="margin-top: 5px">Password: </label>
                <input v-show="!loading" style="border-radius: 10px" v-model="password" type="password">

                <b-button v-show="!loading" @click="logar" style="margin-top: 50px">Entrar</b-button>
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
        justify-content: center;
        flex-direction: column;
    }

    .login {
        width: 600px;
        height: 60vh;
        margin-top: 100px;
        border-radius: 10px;
        display: flex;
        align-items: center;
        color: white;
    }
</style>