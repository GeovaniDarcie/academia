using System;
using System.Collections.Generic;

namespace Academia.Domain.DTOs
{
    public class AlunoInputDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public DateTime InicioDeMatricula { get; set; }
        public long AcademiaId { get; set; }

        public AlunoInputDTO(string nome, string sobrenome, string email, string celular,
                    string cpf, DateTime dataDeNascimento, string genero, DateTime inicioDeMatricula, long academiaId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Celular = celular;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Genero = genero;
            InicioDeMatricula = inicioDeMatricula;
            AcademiaId = academiaId;
        }

    }
}