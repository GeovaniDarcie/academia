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
    try {   
        console.log(json);
        const response = await api.post(recurso, {
            ...json,
            academiaId: 1
        });

        return response.data;

    } catch(err)
    {
        store.state.errors = err.response.data.errors;
    }
}

export async function getAll(json, recurso) {
    const response = await api.get(recurso, {
        params: {
            ...json,
            academiaId: 1
        }
    })

    return response.data;
}

export async function getById(id) {
    const response = await api.get(`/alunos/${id}`);
    return response.data;
}

export async function updated(id, aluno) {
    delete aluno.id
    const response = await api.put(`/alunos/${id}`, aluno)
    return response.data;
}

export async function deleteById(id) {
    const response = await api.delete(`/alunos/${id}`);

    return response.data;
}

export async function login(username, password) {
    try {
        store.state.loading = true;
        const response =  await api.post('/account/login', { username, password })
        store.state.usuario = response.data.usuario;
        localStorage.setItem("token", response.data.token);
    } catch (e) {
        alert('Nome de usuário ou senha inválidos!');
        store.state.loading = false;
        return false;
    }

    store.state.loading = false;
    return true;
}

export async function atualizaAcademia(id, academia) {
    delete academia.id
    const response = await api.put(`/academiaentity/${id}`, academia)
    return response.data;
}

export async function deletaAcademia(id) {
    const response = await api.delete(`/academiaentity/${id}`);

    return response.data;
}

