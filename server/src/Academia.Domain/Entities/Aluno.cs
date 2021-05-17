using System;

namespace Academia.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public DateTime InicioDeMatricula { get; set; }

        public Aluno(string nome, string sobrenome, string email, string celular,
                    string cpf, DateTime dataDeNascimento, string genero, DateTime inicioDeMatricula)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Celular = celular;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Genero = genero;
            InicioDeMatricula = inicioDeMatricula;
        }

    }
}