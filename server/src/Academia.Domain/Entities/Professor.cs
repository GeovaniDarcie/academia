using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public long AcademiaId { get; set; }
        public AcademiaEntity Academia { get; set; }

        public Professor(string nome, string sobrenome, string email, long academiaId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            AcademiaId = academiaId;
        }

    }
}