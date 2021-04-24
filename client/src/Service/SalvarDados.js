import axios from "axios";

export function cadastrar(aluno) {
    return new Promise((resolve) => {
        axios
            .post("https://localhost:5001/Aluno", {
                nome: aluno.nome,
                sobrenome: aluno.sobrenome,
                dataDeNascimento: aluno.dataDeNascimento,
                sexo: aluno.sexo,
                cpf: aluno.cpf,
                email: aluno.email,
                dataDePagamento: aluno.dataDePagamento,
            }).then((response) => {
                if (response.status == 200) {
                    resolve(1)
                }
            });
    })
}

export function buscar() {
    return new Promise(resolve => {
        axios
            .get("https://localhost:5001/Aluno")
            .then((response) => resolve(response.data));
    })

}

export function remover(id) {
    return new Promise(resolve => {
        axios.delete(`https://localhost:5001/Aluno/${id}`).then((response) => {
            if (response.status == 200) {
                resolve(1);
            }
        })
    })
}
