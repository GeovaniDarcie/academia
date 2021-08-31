using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

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
}