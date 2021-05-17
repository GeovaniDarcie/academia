import axios from "axios";

const route = 'https://localhost:5001/academia/alunos';

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

export function buscar() {
    return new Promise(resolve => {
        axios
            .get(route)
            .then((response) => resolve(response.data));
    })

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
