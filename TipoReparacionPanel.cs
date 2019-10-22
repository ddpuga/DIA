using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReparacionesGrafico.UI
{

    using WFrms = System.Windows.Forms;
    class TipoReparacionPanel : WFrms.Form
    {
        public TipoReparacionPanel()
        {
            this.build();
        }


        private void build()
        {

            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;

            var btTDT = new Button
            {
                Text = "Aparato TDT",
                Dock = DockStyle.Top
            };

            var btRadio = new Button
            {
                Text = "Radio",
                Dock = DockStyle.Top
            };

            var btDVD = new Button
            {
                Text = "Reproductor DVD",
                Dock = DockStyle.Top
            };

            var btTV = new Button
            {
                Text = "Televisor",
                Dock = DockStyle.Top
            };

            
            btTDT.Click += (sender, args) => new IntroducirReparacionPanel("tdt").Show();
            btRadio.Click += (sender, args) => new IntroducirReparacionPanel("radio").Show();
            btDVD.Click += (sender, args) => new IntroducirReparacionPanel("dvd").Show();
            btTV.Click += (sender, args) => new IntroducirReparacionPanel("tv").Show();

            pnlTable.Controls.Add(btTDT);
            pnlTable.Controls.Add(btRadio);
            pnlTable.Controls.Add(btDVD);
            pnlTable.Controls.Add(btTV);


            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);
            this.MinimumSize = new Size(320, 240);

        }




    }
}
