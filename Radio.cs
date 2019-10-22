using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class Radio : Aparato
    {

        string bandas;
        public const int precio = 5;

        public Radio(int numSerie, string modelo, string bandas)
            :base(numSerie, modelo)
        {
            this.bandas = bandas;
        }

        public string Bandas
        {
            get; private set;
        }

        public override string ToString()
        {
            return "Radio:\n" + base.ToString() + "\nBandas: " + bandas;
        }


    }
}
