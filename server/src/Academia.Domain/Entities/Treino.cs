using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class Treino : BaseEntity
    {
       public Dia Dia { get; set; }
       public List<Atividade> Atividades { get; set; }

       public long AlunoId { get; set; }
     
        public Treino(Dia dia, long alunoId)
        {
            Dia = dia;
            AlunoId = alunoId; 
            Atividades = new List<Atividade>();
        }

    }
}