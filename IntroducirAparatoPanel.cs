using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReparacionesGrafico.Core;

namespace ReparacionesGrafico.UI
{

    class IntroducirAparatoPanel : Form
    {
        private string tipo;
        RegistroAparatos registro = new RegistroAparatos();

        public IntroducirAparatoPanel(String tipo)
        {
            registro = registro.RecuperaXml();
            this.tipo = tipo;
            build();
        }

        public string Tipo
        {
            get; private set;
        }




        private void build()
        {

            //Crear panel
            var pnl = new Panel { Dock = DockStyle.Top };
            pnl.SuspendLayout();
            pnl.Dock = DockStyle.Fill;

            var btGuardar = new Button
            {
                Text = "Guardar",
                Dock = DockStyle.Top
            };


            //Numero de serie
            var lblns = new Label
            {
                Dock = DockStyle.Top,
                Text = "Numero de serie"
            };

            this.Edns = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            //Modelo

            var lblm = new Label
            {
                Dock = DockStyle.Top,
                Text = "Modelo"
            };


            this.Edm = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            pnl.Controls.Add(btGuardar);
            pnl.Controls.Add(this.Edm);
            pnl.Controls.Add(lblm);
            pnl.Controls.Add(this.Edns);
            pnl.Controls.Add(lblns);

            int numSerie;
            int.TryParse(Edns.Text, out numSerie);
            int tiempo;


            //Switch para introducir los campos NO comunes a cada tipo de aparato

            switch (tipo)
            {
                case "tdt":
                    viewTDT(pnl);
                    break;
                case "radio":
                    viewRadio(pnl);
                    break;
                case "dvd":
                    viewDVD(pnl);
                    break;
                case "tv":
                    viewTV(pnl);
                    break;
            }


            btGuardar.Click += (sender, args) => guardarDatos(pnl);
            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);
            this.MinimumSize = new Size(320, 240);


        }




        public void viewTDT(Panel pnl)
        {


            var lblt = new Label
            {
                Dock = DockStyle.Top,
                Text = "Tiempo de grabacion (0 si no graba)"
            };

            this.Edt = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            pnl.Controls.Add(this.Edt);
            pnl.Controls.Add(lblt);

            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);

        }



        public void viewDVD(Panel pnl)
        {


            var lblb = new Label
            {
                Dock = DockStyle.Top,
                Text = "Con reproductor blurray? (s/n) "
            };

            this.Edb = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            var lblgd = new Label
            {
                Dock = DockStyle.Top,
                Text = "Tiempo de grabacion (0 si no graba)"
            };

            this.Edgd = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };



            pnl.Controls.Add(this.Edb);
            pnl.Controls.Add(lblb);
            pnl.Controls.Add(this.Edgd);
            pnl.Controls.Add(lblgd);

            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);

        }


        public void viewRadio(Panel pnl)
        {

            var lblr = new Label
            {
                Dock = DockStyle.Top,
                Text = "Bandas que soporta: "
            };

            this.Edr = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            pnl.Controls.Add(this.Edr);
            pnl.Controls.Add(lblr);

            this.Controls.Add(pnl);

        }


        public void viewTV(Panel pnl)
        {
            double toret;

            var lblp = new Label
            {
                Dock = DockStyle.Top,
                Text = "Pulgadas "
            };

            this.Edp = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = "0"
            };

            pnl.Controls.Add(this.Edp);
            pnl.Controls.Add(lblp);

            this.Controls.Add(pnl);

        }


        public void guardarDatos(Panel pnl)
        {
            int tiempo;
            int numSerie;
            int.TryParse(Edns.Text, out numSerie);

            switch (tipo)
            {
                case "tdt":
                    int.TryParse(Edt.Text, out tiempo);
                    if (tiempo > 0)
                    {
                        registro.AddAparato(new AdaptadorTDT(numSerie, Edm.Text, tiempo));
                    }
                    else
                    {
                        registro.AddAparato(new AdaptadorTDT(numSerie, Edm.Text));
                    }
                    break;
                case "radio":
                    registro.AddAparato(new Radio(numSerie, Edm.Text, Edr.Text));
                    break;
                case "dvd":
                    int.TryParse(Edgd.Text, out tiempo);
                    bool blu;
                    blu = Edb.Text.Equals("s");
                    if (tiempo > 0)
                    {
                        registro.AddAparato(new ReproductorDVD(numSerie, Edm.Text, blu, tiempo));
                    }
                    else
                    {
                        registro.AddAparato(new ReproductorDVD(numSerie, Edm.Text, blu));
                    }
                    break;
                case "tv":
                    double pulgadas;
                    double.TryParse(Edp.Text, out pulgadas);
                    registro.AddAparato(new Televisor(numSerie, Edm.Text, pulgadas));
                    break;
            }

            registro.GuardaXml();


        }


        public TextBox Edns
        {
            get; private set;
        }

        public TextBox Edm
        {
            get; private set;
        }
        public TextBox Edt { get; private set; }
        public TextBox Edg { get; private set; }
        public Control Edgd { get; private set; }
        public Control Edb { get; private set; }
        public TextBox Edr { get; private set; }
        public TextBox Edp { get; private set; }
    }

}
