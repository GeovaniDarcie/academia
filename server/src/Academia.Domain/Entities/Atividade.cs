using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Academia.Domain.Entities
{
    public class Atividade : BaseEntity
    {
       public string Descricao { get; set; }
       public int Series { get; set; }
       public int Repeticoes { get; set; }
       public long TreinoId { get; set; }

       [JsonIgnore] 
       [IgnoreDataMember] 
       public Treino Treino { get; set; }

        public Atividade(string descricao, int series, int repeticoes, long treinoId)
        {
            Descricao = descricao;
            Series = series;
            Repeticoes = repeticoes;
            TreinoId = treinoId;
        }

    }
}