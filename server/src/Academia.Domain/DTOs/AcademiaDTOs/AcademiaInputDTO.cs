
using FluentValidation;

namespace Academia.Domain.Entities
{
    public class AcademiaInputDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public AcademiaInputDTO(string nome, string endereco, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
        }
    }

    public class AcademiaInputDTOValidator : AbstractValidator<AcademiaInputDTO>
    {
       public AcademiaInputDTOValidator()
       {
           RuleFor(academia => academia.Nome)
              .NotEmpty()
              .WithMessage("Nome da academia não pode ser vazio");

           RuleFor(academia => academia.Endereco)
              .NotEmpty()
              .WithMessage("Edereço da academia não pode ser vazio");;

           RuleFor(academia => academia.Email)
             .NotEmpty()
             .EmailAddress()
             .WithMessage("Digite um email válido para a academia");
       }   
    }
}