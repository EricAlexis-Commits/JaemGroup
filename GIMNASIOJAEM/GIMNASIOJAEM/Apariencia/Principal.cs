using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIMNASIOJAEM.Apariencia
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void abrirSubPanel<T>()where T: Form, new()
        {
            /*Form formulario = panelContenido.Controls.OfType<T>().FirstOrDefault();
            if (formulario != null)
            {
                //Si la instancia esta minimizada la dejamos en su estado normal
                if (formulario.WindowState == FormWindowState.Maximized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                formulario.BringToFront();
                return;
            }
            //Si la instancia existe la pongo en primer plano
            //Se abre el form
            formulario = new T();
            formulario.TopLevel = false;
            panelContenido.Controls.Add(formulario);
            panelContenido.Tag = formulario;
            formulario.Show();*/

        }
        private void abrirpanelHijo(object formHijo)
        {
            if (this.panelContenido.Controls.Count > 0)
            {
                this.panelContenido.Controls.RemoveAt(0);
            }
            Form fhijo = formHijo as Form;
            fhijo.TopLevel = false;
            fhijo.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(fhijo);
            this.panelContenido.Tag = fhijo;
            fhijo.Show();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Personas());
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Usuario());
        }
    }
}
