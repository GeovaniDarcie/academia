using Academia.Domain.Entities.Enums;
using FluentValidation;

namespace Academia.Domain.Entities
{
    public class AntropometriaInputDTO
    {
       public double Peso { get; set; } 
       public double Altura { get; set; }
       public int PercentualDeGordura { get; set; }
       public double MassaMuscular { get; set; }
       public long AlunoId { get; set; }
    }

    public class AntropometriaInputDTOValidator : AbstractValidator<AntropometriaInputDTO>
    {
        public AntropometriaInputDTOValidator()
        {
            RuleFor(antropometria => antropometria.AlunoId).NotEmpty();
        }
    }
}