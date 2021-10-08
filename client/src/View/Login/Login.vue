<template>
        <div class="containar login bg-dark" style="opacity: 0.9">
                <template v-if="!loading">
                    <label for="" style="margin-top: 55px">Usuário: </label>
                    <input style="border-radius: 10px" v-model="username" type="text">

                    <label for="" style="margin-top: 5px">Senha: </label>
                    <input style="border-radius: 10px" v-model="password" type="password">
                    <b-button @click="logar" style="margin-top: 50px">Entrar</b-button>
                </template>
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
           return this.$store.state.loading;
        }
    },
    methods: {
        async logar() {
           const validou = await login(this.username, this.password)
           if(validou) {
               this.$store.state.autenticado = validou;
               
               console.log(this.$store.state.usuario);
               if (this.$store.state.usuario.role == 'Mestre') {
                   this.$router.push({ name: 'academias' })
               } 
            
               if (this.$store.state.usuario.role == 'Completo' ||
                this.$store.state.usuario.role == 'Professor') {
                    this.$router.push({ name: 'alunos' })
                }
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