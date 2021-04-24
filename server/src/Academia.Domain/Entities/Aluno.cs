using System;

namespace Academia.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DataDePagamento { get; set; }

        public Aluno(string nome, string sobrenome, string dataDeNascimento, string sexo,
                    string cpf, string email, string dataDePagamento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            Cpf = cpf;
            Email = Email;
            DataDePagamento = dataDePagamento;
        }

    }
}