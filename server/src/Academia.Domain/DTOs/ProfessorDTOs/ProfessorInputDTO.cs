using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class ProfessorInputDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public long AcademiaId { get; set; }

        public ProfessorInputDTO(string nome, string sobrenome, string email, long academiaId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            AcademiaId = academiaId;
        }

    }
}