using ReparacionesGrafico.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReparacionesGrafico.Core;

namespace KutreKalc.UI
{

    using WFrms = System.Windows.Forms;
    public class MainWindow : Form
    {

        public MainWindow()
        {
            this.Build();
        }

        private void OnQuit()
        {
            this.Hide();
            this.Close();
        }

        private void ViewIntroducirElementoPanel()
        {
            new IntroducirElementoPanel().Show();
        }

        private void ViewTipoReparacionPanel()
        {
            new TipoReparacionPanel().Show();
        }

        private void ViewListaReparacionesPanel()
        {
            new ListaReparacionesPanel().Show();
        }


        /*private void BuildMenu()
        {
            this.Menu = new MainMenu();

            // Quit
            var opQuit = new MenuItem("&Quit")
            {
                Shortcut = Shortcut.CtrlQ
            };

            opQuit.Click += (sender, args) =>
            {
                this.OnQuit();
            };

        
            var opIntroducirAparato = new MenuItem("&Introducir aparato");
            opIntroducirAparato.Click += (sender, args) => this.ViewIntroducirElementoPanel();

           
            var opIntroducirReparacion = new MenuItem("&Introducir reparacion");
            opIntroducirReparacion.Click += (sender, args) => this.ViewTipoReparacionPanel();

           
            var opListaAparato = new MenuItem("&Lista aparato");
            opListaAparato.Click += (sender, args) => this.ViewListaAparatoPanel();


            var opListaReparaciones = new MenuItem("&Lista reparaciones");
            opListaAparato.Click += (sender, args) => this.ViewListaReparacionesPanel();

            var opBorrarDatos = new MenuItem("&Borrar datos");
            opListaAparato.Click += (sender, args) => this.showBorrarDatos();

        
            var mFile = new MenuItem("&File");
            var mView = new MenuItem("&View");

            mFile.MenuItems.Add(opQuit);

            mView.MenuItems.Add(opIntroducirAparato);
            mView.MenuItems.Add(opIntroducirReparacion);
            mView.MenuItems.Add(opListaAparato);
            mView.MenuItems.Add(opListaReparaciones);
            mView.MenuItems.Add(opBorrarDatos);


            this.Menu.MenuItems.Add(mFile);
            this.Menu.MenuItems.Add(mView);
        }*/



        private void Build()
        {
            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;

            var btIntroducirAparato = new Button
            {
                Text = "Introducir aparato",
                Dock = DockStyle.Top
            };

            var btIntroducirReparacion = new Button
            {
                Text = "Introducir reparación",
                Dock = DockStyle.Top
            };

            var btListaReparaciones = new Button
            {
                Text = "Lista de reparaciones",
                Dock = DockStyle.Top
            };

            var btBorrarDatos = new Button
            {
                Text = "Borrar datos",
                Dock = DockStyle.Top
            };


            btIntroducirAparato.Click += (sender, args) => ViewIntroducirElementoPanel();
            btIntroducirReparacion.Click += (sender, args) => ViewTipoReparacionPanel();
            btListaReparaciones.Click += (sender, args) => ViewListaReparacionesPanel();
            btBorrarDatos.Click += (sender, args) => showBorrarDatos();

            pnlTable.Controls.Add(btIntroducirAparato);
            pnlTable.Controls.Add(btIntroducirReparacion);
            pnlTable.Controls.Add(btListaReparaciones);
            pnlTable.Controls.Add(btBorrarDatos);

            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

           // this.BuildMenu();
            this.MinimumSize = new Size(320, 240);
            this.Text = "Tienda de electronica";
        }



        private void showBorrarDatos()
        {

            RegistroAparatos registro = new RegistroAparatos();
            RegistroReparaciones registro2 = new RegistroReparaciones();
            registro.Clear();
            registro2.Clear();

            Label label1 = new Label() {
                Dock = DockStyle.Bottom,
            Text = "Datos Borrados"
            };
            label1.UseMnemonic = true;
           
            label1.Size = new Size(label1.PreferredWidth, label1.PreferredHeight);
            this.Controls.Add(label1);
                
        }


    }
}
