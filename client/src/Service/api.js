import axios from "axios";

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

export async function getAll() {
    const response = await api.get('/alunos');
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
    console.log(aluno)
    console.log(id)
    const response = await api.put(`/alunos/${id}`, aluno)
    return response.data;
}

export function deleteById(id) {
    console.log(id);
    return new Promise(resolve => {
        console.log(id);
        api.delete(`/alunos/${id}`).then((response) => {
            if (response.status == 200) {
                resolve(1);
            }
        })
    })
}

export async function login(username, password) {
    try {
        const response =  await axios
            .post('https://localhost:5001/Authenticate/login', { username, password })
        localStorage.setItem("token", response.data.token);
    } catch (e) {
        alert('Errou fiote');
        return false;
    }

    return true;
}

