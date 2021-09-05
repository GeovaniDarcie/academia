using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class AtividadeInputDTO
    {
       public string Descricao { get; set; }
       public int Series { get; set; }
       public int Repeticoes { get; set; }
       public long TreinoId { get; set; }
    }
}