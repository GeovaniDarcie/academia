import axios from "axios";
import store from '../store/store'

const api = axios.create({
    baseURL: 'https://localhost:5001/api/'
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
    console.log(json)
    try {   
        const response = await api.post(recurso, {
            ...json,
        });

        return response.data;

    } catch(err)
    {
        store.state.errors = err.response.data.errors;
    }
}

export async function getAll(json, recurso) {
    console.log(json)
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
    console.log(id)
    console.log(json)
    console.log(recurso)
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
        const response =  await api.post('/account/login', { username, password })
        store.state.usuario = response.data.usuario;
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("academiaId", response.data.usuario.academiaId);
    } catch (e) {
        alert('Nome de usuário ou senha inválidos!');
        store.state.loading = false;
        return false;
    }

    store.state.loading = false;
    return true;
}

