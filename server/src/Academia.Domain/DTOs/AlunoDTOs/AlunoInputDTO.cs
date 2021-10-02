using System;
using FluentValidation;
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

    public class AlunoInputDTOValidator : AbstractValidator<AlunoInputDTO> 
    {
        public AlunoInputDTOValidator()
        {
            RuleFor(aluno => aluno.Nome).NotEmpty();
            RuleFor(aluno => aluno.Nome)
                .Length(2, 250)
                .WithMessage("Tamanho {TotalLength} é inválido");

            RuleFor(aluno => aluno.Sobrenome).NotEmpty();
            RuleFor(aluno => aluno.Sobrenome)
                .Length(2, 250)
                .WithMessage("Tamanho {TotalLength} é inválido");
            
            RuleFor(aluno => aluno.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Digite um email válido!");

            RuleFor(aluno => aluno.Celular)
                .NotEmpty()
                .MinimumLength(13)
                .WithMessage("Celular deve ter menos que 13 digítos!");
    
            RuleFor(aluno => aluno.Celular)
                .NotEmpty()
                .MinimumLength(13)
                .WithMessage("Celular deve ter 13 digítos!");
        }
    }
}