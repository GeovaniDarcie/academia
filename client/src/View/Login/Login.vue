<template>
    <div class="containar login bg-dark" style="opacity: 0.9">
        <ModalError :errosTeste="$store.state.errors"/>
        <template v-if="!loading">
            <label for="" style="margin-top: 55px">Usuário: </label>
            <input style="border-radius: 10px" v-model="username" type="text">

            <label for="" style="margin-top: 5px">Senha: </label>
            <input style="border-radius: 10px" v-model="password" type="password">
            <b-button @click="logar" style="margin-top: 50px">Entrar</b-button>

            <b-navbar-brand style="margin-top: 10px; font-size: medium;" href="#" @click="newAccount">Criar nova Conta</b-navbar-brand>
        </template>
        <vue-loading v-show="loading" type="spin" color="#d9544e"
            :size="{ width: '50px', height: '50px' }"></vue-loading>
   
        <b-modal v-model="showModalAcademia" :title="'Cadastrar academia'">
            <ModalAcademia />
            <template #modal-footer="{ ok, cancel }">
                <b>Academia</b>
                <b-button variant="success" @click="SalvarAcademia()"> Salvar </b-button>
                <b-button variant="danger" @click="cancel()"> Cancelar </b-button>
            </template>
        </b-modal>
     
        <b-modal v-model="showModalUsuario" :title="'Cadastrar Usuário'">
            <ModalUsuario />
            <template #modal-footer="{ ok, cancel }">
                <b>Usuário</b>
                <b-button variant="success" @click="salvarUsuario()"> Salvar </b-button>
                <b-button variant="danger" @click="cancel()"> Cancelar </b-button>
            </template>
        </b-modal>
    </div>
</template>

<script>
import { login } from '../../Service/api';
import ModalAcademia from "../../Components/ModalAcademia";

import { VueLoading } from 'vue-loading-template'
import ModalUsuario from '../../Components/ModalUsuario';
import { post } from "../../Service/api.js";
import { mapState } from 'vuex';
import ModalError from '../../Components/ModalError';

export default {
    data() {
        return {
            username: '',
            password: '',
            showModalAcademia: false,
            showModalUsuario: false,
            backgroundModal: 'dark'
        }
    },
    mounted() {
        this.checkToken();
    },
    computed: {
        loading() {
            return this.$store.state.loading;
        },
        ...mapState(['usuario', 'errors', 'academia'])
    },
    methods: {
        async logar() {
            const validou = await login(this.username, this.password)

            if (validou) {
                this.academia.idUser = this.usuario.id;

                await post(this.academia, './academiaentity');

                this.$store.state.autenticado = validou;

                if (this.usuario.role == 'Mestre') {
                    this.$router.push({ name: 'academias' })
                }

                if (this.usuario.role == 'Completo' ||
                    this.usuario.role == 'Professor') {
                     this.$router.push({ name: 'alunos' })
                }
            } else {
                this.username = '';
                this.password = '';
            }
        },
        checkToken() {
            const token = localStorage.getItem("token");
            const role = localStorage.getItem("role");
            if (token != '' && token != null) {
                if (role == 'Mestre') {
                    this.$router.push({ name: 'academias' })
                }

                if (role == 'Completo' ||
                    role == 'Professor') {
                    this.$router.push({ name: 'alunos' })
                }
            }
        },
        newAccount(){
            this.showModalUsuario = this.showModalUsuario ? false : true;
        },
        async SalvarAcademia(){
            this.username = this.usuario.username;
            this.password = this.usuario.password;

            await this.logar();
            this.showModal = false;
            this.showModalUsuario = false;
        },

        async salvarUsuario(){
            await post(this.usuario, './Authenticate/register');
            await post(this.usuario, './Roles/assign')

            if (this.errors.length == 0)
            {
                this.showModalAcademia = true;
            }
            
            this.showModalUsuario = false;
        }


    },
    components: {
        VueLoading,
        ModalAcademia,
        ModalUsuario,
        ModalError
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