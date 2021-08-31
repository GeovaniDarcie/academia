import axios from "axios";

const route = 'https://localhost:5001/api/alunos';

const instance = axios.create({
    baseURL: 'https://localhost:5001/api/'
});

instance.interceptors.request.use(
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


export function cadastrar(aluno) {
    return new Promise((resolve) => {
        axios
            .post(route, {
                nome: aluno.nome,
                sobrenome: aluno.sobrenome,
                email: aluno.email,
                celular: aluno.celular,
                cpf: aluno.cpf,
                dataDeNascimento: aluno.dataDeNascimento,
                genero: aluno.genero,
                inicioDeMatricula: aluno.inicioDeMatricula
            }).then((response) => {
                if (response.status == 201) {
                    resolve(1)
                }
            });
    })
}

export async function getAll() {
    const response = await instance.get('/alunos');
    return response.data;
}

export async function getById(id) {
    const response = await instance.get(`/alunos/${id}`);
    return response.data;
}

export function remover(id) {
    return new Promise(resolve => {
        axios.delete(`${route}/${id}`).then((response) => {
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

