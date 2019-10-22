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
    using WFrms = System.Windows.Forms;
    class ListaReparacionesPanel : WFrms.Form
    {

        public ListaReparacionesPanel()
        {
            this.build();
        }


        private void build()
        {
            RegistroAparatos registroa = recuperarRegistroa();
            RegistroReparaciones registro = recuperarRegistro();

            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;


            Label apratos = new Label()
            {
                Dock = DockStyle.Top,
                Text = registroa.toString()
            };

            Label label1 = new Label()
            {
                Dock = DockStyle.Top,
                Text = registro.ToString()
            };
            apratos.UseMnemonic = true;
            label1.UseMnemonic = true;

            apratos.Size = new Size(apratos.PreferredWidth, apratos.PreferredHeight);
            label1.Size = new Size(label1.PreferredWidth, label1.PreferredHeight);
            this.Controls.Add(label1);
            this.Controls.Add(apratos);


            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);
            this.MinimumSize = new Size(320, 240);

        }


        private RegistroReparaciones recuperarRegistro()
        {
            RegistroReparaciones toret = new RegistroReparaciones();

            toret = toret.RecuperaXml();

            return toret;
        }

        private RegistroAparatos recuperarRegistroa()
        {
            RegistroAparatos toret = new RegistroAparatos();

            toret = toret.RecuperaXml();

            return toret;
        }
    }
}
