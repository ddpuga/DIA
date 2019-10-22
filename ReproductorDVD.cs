using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class ReproductorDVD : Aparato
    {

        Boolean bluRay;
        Boolean graba;
        int tiempo;
        public const int precio = 10;

        public ReproductorDVD(int numSerie, string modelo, Boolean bluRay)
            : base(numSerie, modelo)
        {
            this.bluRay = bluRay;
            graba = false;

        }

        public ReproductorDVD(int numSerie, string modelo, Boolean bluRay, int tiempo)
            : base (numSerie, modelo)
        {
            this.bluRay = bluRay;
            graba = true;
            this.tiempo = tiempo;
        }

        public Boolean BluRay
        {
            get; private set;
        }

        public Boolean Graba
        {
            get; private set;
        }

        public int Tiempo
        {
            get; private set;
        }


        public string toString()
            {
                StringBuilder toret = new StringBuilder();
                toret.Append("Reproductor DVD");
                toret.Append(base.ToString());
            if (bluRay)
            {
                toret.Append("\ncon lector bluray");
            }
            else
            {
                toret.Append("\nsin lector bluray");
            }
                if (graba == true)
                {
                    toret.Append("\nCon grabación");
                    toret.Append("\nTiempo de grabacion: " + tiempo);
                }
                else
                {
                    toret.Append("\nSin grabacion");
                }
                return toret.ToString();
            }


    }
}
