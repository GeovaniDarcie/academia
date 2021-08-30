using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class Atividade : BaseEntity
    {
       public string Descricao { get; set; }
       public int Series { get; set; }
       public int Repeticoes { get; set; }

        public Atividade(string descricao, int series, int repeticoes)
        {
            Descricao = descricao;
            Series = series;
            Repeticoes = repeticoes;
        }

    }
}