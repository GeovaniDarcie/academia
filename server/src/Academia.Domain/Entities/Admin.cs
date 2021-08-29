using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class Admin : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Admin(string nome, string sobrenome, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Alunos = new List<Aluno>();
        }

    }
}