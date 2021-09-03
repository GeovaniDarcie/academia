using System;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class AntropometriaOutputDTO
    {
       public long Id { get; set; }
       public double Peso { get; set; } 
       public double Altura { get; set; }
       public IMC IMC { get; private set; }
       public double ValorIMC { get; set; }
       public int PercentualDeGordura { get; set; }
       public double MassaMuscular { get; set; }
       public long AlunoId { get; set; }

       public AntropometriaOutputDTO(long id, double peso, double altura, IMC imc, 
                int percentualDeGordura, double massaMuscular, long alunoId) {
           Id = id;
           Peso = peso;
           IMC = imc;
           Altura = altura;
           PercentualDeGordura = percentualDeGordura;
           MassaMuscular = massaMuscular;
           AlunoId = alunoId;

           CalculoIMC();
       }

       private void CalculoIMC() {
            ValorIMC = Peso / Math.Pow(Altura, 2);
       }

    }
}