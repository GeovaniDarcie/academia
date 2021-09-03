import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:5001/api/'
});

export async function post(avaliacao) {
    const response = await api.post('/Anamnese', avaliacao);
    return response.data;
}