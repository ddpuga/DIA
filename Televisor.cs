using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class Televisor : Aparato
    {

        double pulgadas;
        public const int precio = 10;

       public Televisor(int numSerie, string modelo, double pulgadas)
            : base (numSerie, modelo)
        {
            this.pulgadas = pulgadas;
        }

        public double Pulgadas
        {
            get; private set;
        }

        public override string ToString()
        {
            return "Televisor:\n" + base.ToString() + "\n" + pulgadas + " pulgadas";
        }
    }
}
