using System;
using System.Collections.Generic;

namespace Academia.Domain.Entities
{
    public class DobrasCutaneas : BaseEntity
    {
       public double Triciptal { get; set; }
       public double Subescapular { get; set; }
       public double Biciptal { get; set; }
       public double AxilarMedia { get; set; }
       public double SupraIliaca { get; set; }
       public double Toracica { get; set; }
       public double Coxa { get; set; }
       public double Abdominal { get; set; }
       public double PanturrilhaMedial { get; set; }
       public long AlunoId { get; set; }
       public Aluno Aluno { get; set; }

       public DobrasCutaneas(double triciptal, double subescapular, double biciptal, double axilarMedia, double supraIliaca,
            double toracica, double coxa, double abdominal, double panturrilhaMedial, long alunoId) {
                Triciptal = triciptal;
                Subescapular = subescapular;
                Biciptal = biciptal;
                AxilarMedia = axilarMedia;
                SupraIliaca = supraIliaca;
                Toracica = toracica;
                Coxa = coxa;
                Abdominal = abdominal;
                PanturrilhaMedial = panturrilhaMedial;
                AlunoId = alunoId;
       }
    }
}