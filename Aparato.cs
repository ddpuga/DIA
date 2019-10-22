using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
     public class Aparato
    {
        public int numSerie;
        public string modelo;

        public Aparato(int numSerie, string modelo)
        {
            this.numSerie = numSerie;
            this.modelo = modelo;
        }

        public override string ToString()
        {
            return "Modelo: " + modelo + "\nNum serie: " + numSerie;
        }

    }

}
