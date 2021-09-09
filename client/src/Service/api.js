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
}

export async function getAll(limit, page) {
    console.log(page)
    const response = await api.get('/alunos', {
        params: {
            limit: limit,
            page: page
        }
    })

    return response.data;
}

export async function getById(id) {
    console.log('oi')
    const response = await api.get(`/alunos/${id}`);
    console.log(response.data);
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
        const response =  await axios
            .post('https://localhost:5001/Authenticate/login', { username, password })
        localStorage.setItem("token", response.data.token);
    } catch (e) {
        alert('Nome de usuário ou senha inválidos!');
        store.state.loading = false;
        return false;
    }

    store.state.loading = false;
    return true;
}

export async function criarTreino (dia) {
    try {
        const response = await api.post('/treino', {Dia: dia});
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
            alunoId: atividade.alunoId
        });

        return response.data;
    } catch (e) {
        console.log('Atividade inválida')
    }
}

