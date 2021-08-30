using System;
using System.Collections.Generic;

namespace Academia.Domain.DTOs
{
    public class AdminInputDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public AdminInputDTO(string nome, string sobrenome, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }

    }
}