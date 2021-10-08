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


export async function post(aluno) {
    try {   
        const response = await api.post('./alunos', {
            nome: aluno.nome,
            sobrenome: aluno.sobrenome,
            email: aluno.email,
            celular: aluno.celular,
            cpf: aluno.cpf,
            dataDeNascimento: aluno.dataDeNascimento,
            genero: aluno.genero,
            inicioDeMatricula: aluno.inicioDeMatricula,
            academiaId: 1
        });

        return response.data;

    } catch(err)
    {
        store.state.errors = err.response.data.errors;
    }
    
}

export async function getAll(limit, page) {
    const response = await api.get('/alunos', {
        params: {
            limit: limit,
            page: page
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

export async function criarTreino (dia, alunoId) {
    try {
        const response = await api.post('/treino', {
            Dia: dia,
            alunoId: alunoId
        });

        return response.data;
    } catch (e) {
        console.log('Treino inválido')
    }
}

export async function criarAtividade (atividade) {
    try {
        const response = await api.post('/atividade', {
            descricao: atividade.descricao,
            series: atividade.series,
            repeticoes: atividade.repeticoes,
            treinoId: atividade.treinoId,
        });

        return response.data;

    } catch (e) {
        console.log('Atividade inválida')
    }
}

export async function buscarTreinos(dia, id ) {
    try {
        const response = await api.get('/treino/atividades', {
            params: {
                dia: dia,
                alunoId: id
            }
        })

        return response.data;
    } catch (e) {
        console.log(e);
    }
}

export async function criaAcademia(academia) {
    try {   
        const response = await api.post('./academiaentity', {
            nome: academia.nome,
            endereco: academia.sobrenome,
            email: academia.email,
        });

        return response.data;

    } catch(err)
    {
        store.state.errors = err.response.data.errors;
    }
    
}

export async function buscaAcademias() {
    const response = await api.get('/academiaentity')

    return response.data;
}

