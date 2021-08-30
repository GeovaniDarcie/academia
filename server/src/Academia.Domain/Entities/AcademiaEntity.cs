using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class AcademiaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public AcademiaEntity(string nome, string endereco, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
        }

    }
}