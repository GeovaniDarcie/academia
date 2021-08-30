using System;
using System.Collections.Generic;
using Academia.Domain.Entities.Enums;

namespace Academia.Domain.Entities
{
    public class Antropometria
    {
       public double Peso { get; set; } 
       public double Altura { get; set; }
       public IMC IMC { get; private set; }
       public int PercentualDeGordura { get; set; }
       public double MassaMuscular { get; set; }

       public Antropometria (double peso, double altura, int percentualDeGordura, double massaMuscular) {
           Peso = peso;
           Altura = altura;
           PercentualDeGordura = percentualDeGordura;
           MassaMuscular = massaMuscular;

           CalculoIMC();
       }

       private void CalculoIMC() {
           double imc = Peso / Math.Pow(Altura, 2);
           
           if (imc <= 16) 
              IMC = IMC.Desnutrição;

           if (imc >= 16.1 && imc <= 18.4)
              IMC = IMC.Magreza; 

            if (imc >= 18.5 && imc <= 24.9)
               IMC = IMC.PesoNormal;

            if (imc >= 25 && imc <= 29.9)
               IMC = IMC.Sobrepeso;

            if(imc >= 30 && imc <= 39.9)
               IMC = IMC.Obesidade;

            if(imc >= 40)
               IMC = IMC.ObesidadeMorbida;           

          Console.WriteLine(IMC);    
       }
    }
}