using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class ReparacionCompleja : Reparacion
    {

        public const double factor = 1.25;

        public ReparacionCompleja(int precio, double horas, int numSerie)
            :base(precio,horas,numSerie)
        {   
        }

        public override string ToString()
        {

            double total = precioBase + precioPiezas + (precio * factor * horas);
            return base.ToString() + "\nPrecio total: " + total;
        }



    }
}
