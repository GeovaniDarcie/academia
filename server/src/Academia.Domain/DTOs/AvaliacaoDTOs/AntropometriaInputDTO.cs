using Academia.Domain.Entities.Enums;

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
}