using System;
using System.Collections.Generic;
using System.Text;

namespace ReparacionesGrafico.Core
{
    class SustitucionPiezas : Reparacion
    {

        public SustitucionPiezas(int precio, double horas, int numSerie)
            : base(precio, horas, numSerie)
        {
        }

        public override string ToString()
        {
            double total = precioBase + precioPiezas + precio * horas;
            return base.ToString() + "\nPrecio total: " + total;
        }

    }
}
