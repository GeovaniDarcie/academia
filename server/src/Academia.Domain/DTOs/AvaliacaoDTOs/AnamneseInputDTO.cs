using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;
using FluentValidation;

namespace Academia.Domain.Entities
{
    public class AnamneseInputDTO
    {
       public string HabitosGerais { get; set; }
       public Sedentarismo Sedentarismo { get; set; }
       public string Cirurgias { get; set; }
       public long AlunoId { get; set; }

       public AnamneseInputDTO(string habitosGerais, Sedentarismo sedentarismo, string cirurgias, long alunoId) {
           HabitosGerais = habitosGerais;
           Sedentarismo = sedentarismo;
           Cirurgias = cirurgias;
           AlunoId = alunoId;
       }
    }

    public class AnamneseInputDTOValidator : AbstractValidator<AnamneseInputDTO>
    {
        public AnamneseInputDTOValidator()
        {
            RuleFor(anamnese => anamnese.AlunoId).NotEmpty();
        }
    }
}