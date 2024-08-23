import axios from "axios";
import store from '../store/store'
import { getJwtClaim } from './usuarioService';

const api = axios.create({
    baseURL: 'https://localhost:44391/api/'
});

api.interceptors.request.use(
  function(config) {
    const token = localStorage.getItem("token"); 
    if (token) {
      config.headers["Authorization"] = 'Bearer ' + token;
    }
    return config;
  },
  function(error) {
    return Promise.reject(error);
  }
);

export async function post(json, recurso) {
    try {   
        const response = await api.post(recurso, {
            ...json,
        });

        return response.data;
    } 
    catch(err)
    {
        if (err.response.data.errors) {
            store.commit('ADD_ERRORS', err.response.data.errors);
        } else {
            store.commit('ADD_ERRORS', [err.response.data]);
        }
    }
}

export async function getAll(json, recurso) {
    const response = await api.get(recurso, {
        params: {
            ...json,
        }
    })

    return response.data;
}

export async function getById(id) {
    const response = await api.get(`/alunos/${id}`);
    return response.data;
}

export async function updated(id, json, recurso) {
    delete json.id
    const response = await api.put(`${recurso}/${id}`, json)
    return response.data;
}

export async function deleteId(id, recurso) {
    const response = await api.delete(`${recurso}/${id}`);

    return response.data;
}

export async function login(username, password) {
    try {
        store.state.loading = true;
        const response =  await api.post('/Authenticate/login', { username, password })
        store.state.usuario = response.data.user;

        const roleClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        var role = getJwtClaim(response.data.token, roleClaim);

        store.state.usuario.role = role;

        localStorage.setItem("token", response.data.token);
        localStorage.setItem("role", role);
        
    } catch (e) {
        alert('Nome de usuário ou senha inválidos!');
        store.state.loading = false;
        return false;
    }

    store.state.loading = false;
    return true;
}

