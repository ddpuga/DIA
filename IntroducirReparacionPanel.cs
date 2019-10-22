using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReparacionesGrafico.Core;

namespace ReparacionesGrafico.UI
{
   using WFrms = System.Windows.Forms;
    class IntroducirReparacionPanel : WFrms.Form
    {
        private string tipo;
        RegistroReparaciones registro = new RegistroReparaciones();

        public IntroducirReparacionPanel(string tipo)
        {
            this.build();
            this.tipo = tipo;
        }

        public TextBox Edns { get; private set; }
        public TextBox Edh { get; private set; }
     

        private void build()
        {
            registro = registro.RecuperaXml();

            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            var lblns = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Top,
                Text = "Numero de serie"
            };

            this.Edns = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Top,
                TextAlign = WFrms.HorizontalAlignment.Left,
                Text = "0"
            };


            var lblh = new WFrms.Label
            {
                Dock = WFrms.DockStyle.Top,
                Text = "Horas (decimal acabado en .0 o .5)"
            };

            this.Edh = new WFrms.TextBox
            {
                Dock = WFrms.DockStyle.Top,
                TextAlign = WFrms.HorizontalAlignment.Left,
                Text = "0"
            };

            double horas;
            int numSerie;
            double.TryParse(Edh.Text, out horas);
            int.TryParse(Edns.Text, out numSerie);
     
            switch(tipo){

                case "tdt":
                    registro.AddReparacion(new Reparacion(AdaptadorTDT.precio, horas, numSerie));
                    break;
                case "radio":
                    registro.AddReparacion(new Reparacion(Radio.precio, horas, numSerie));
                    break;
                case "dvd":
                    registro.AddReparacion(new Reparacion(ReproductorDVD.precio, horas, numSerie));
                    break;
                case "tv":
                    registro.AddReparacion(new Reparacion(Televisor.precio, horas, numSerie));
                    break;
            }

            pnl.Controls.Add(this.Edh);
            pnl.Controls.Add(lblh);
            pnl.Controls.Add(this.Edns);
            pnl.Controls.Add(lblns);

            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);

            registro.GuardaXml();

        }

    }
}
