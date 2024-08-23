using Academia.Domain.DTOs;
using FluentValidation;

public class RegisterModel {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterModelDTOValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelDTOValidator()
    {
        RuleFor(usuario => usuario.Username).NotEmpty();
        RuleFor(usuario => usuario.Username)
            .Length(2, 250)
            .WithMessage("Tamanho {TotalLength} é inválido");

        RuleFor(usuario => usuario.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Digite um email válido!");
    }
}