using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class AdaptadorTDT : Aparato
    {

        Boolean graba;
        int tiempo;
        public const int precio = 5;

        public AdaptadorTDT(int numSerie, string modelo)
            : base (numSerie, modelo)
        {
            this.graba = false;

        }

        public AdaptadorTDT(int numSerie, string modelo, int tiempo)
            :base (numSerie, modelo)
        {
            this.graba = true;
            this.tiempo = tiempo;

        }

        public Boolean Graba
        {
            get; private set;
        }

        public int Tiempo
        {
            get; private set;
        }

        public override string ToString()
        {
            
            StringBuilder toret = new StringBuilder();
               toret.AppendLine("Adaptador TDT");
               toret.AppendLine(base.ToString());
               if (graba==true)
               {
                   toret.Append("\nCon grabación");
                   toret.Append("\nTiempo de grabacion: " + tiempo);
               }
               else
               {
                   toret.Append("Sin grabacion");
               }

               return toret.ToString();
        }
    
    }

   
}
