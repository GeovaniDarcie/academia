using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class Anamnese : BaseEntity
    {
       public string HabitosGerais { get; set; }
       public Sedentarismo Sedentarismo { get; set; }
       public string Cirurgias { get; set; }
       public long AlunoId { get; set; }
       public Aluno Aluno { get; set; }

       public Anamnese(string habitosGerais, Sedentarismo sedentarismo, string cirurgias, long alunoId) {
           HabitosGerais = habitosGerais;
           Sedentarismo = sedentarismo;
           Cirurgias = cirurgias;
           AlunoId = alunoId;
       }
    }
}