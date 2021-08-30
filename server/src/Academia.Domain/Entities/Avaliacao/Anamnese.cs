using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class Anamnese
    {
       public string HabitosGerais { get; set; }
       public Sedentarismo Sedentarismo { get; set; }
       public string Cirurgias { get; set; }
    }
}