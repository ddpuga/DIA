namespace ReparacionesGrafico.Core
{

    public class Reparacion
    {

        public int precio;
        public double horas;
        public const int precioBase = 10;
        public const int precioPiezas = 10;
        public int numSerie;

        public Reparacion (int precio, double horas, int numSerie)
        {
            this.precio = precio;
            this.horas = horas;
            this.numSerie = numSerie;
        }

        public  Reparacion crea()
        {

            if (horas <= 1 && horas > 0)
            {
                return new SustitucionPiezas(precio, horas, numSerie);
            }
            else
            {
                return new ReparacionCompleja(precio, horas,  numSerie);
            }

        }


        public override string ToString()
        {
            return "\nHoras de reparación: " + horas + "\nNumero de serie del aparato: " + numSerie;
        }

    }
}
