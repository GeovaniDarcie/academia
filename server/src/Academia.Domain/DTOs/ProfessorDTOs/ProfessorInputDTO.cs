using System;
using System.Collections.Generic;
using FluentValidation;

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

    public class ProfessorInputDTOValidator : AbstractValidator<ProfessorInputDTO> 
    {
        public ProfessorInputDTOValidator()
        {
            RuleFor(professor => professor.Nome).NotEmpty();
            RuleFor(professor => professor.Nome)
                .Length(2, 250)
                .WithMessage("Tamanho {TotalLength} é inválido");

            RuleFor(professor => professor.Sobrenome).NotEmpty();
            RuleFor(professor => professor.Sobrenome)
                .Length(2, 250)
                .WithMessage("Tamanho {TotalLength} é inválido");
            
            RuleFor(professor => professor.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Digite um email válido!");

            RuleFor(professor => professor.AcademiaId).NotEmpty();    
        }
    }
}