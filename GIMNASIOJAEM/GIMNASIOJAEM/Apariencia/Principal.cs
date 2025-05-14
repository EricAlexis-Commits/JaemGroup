using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        
        private void abrirpanelHijo(object formHijo)
        {
            if (this.panelInformacion.Controls.Count > 0)
            {
                this.panelInformacion.Controls.RemoveAt(0);
            }
            Form fhijo = formHijo as Form;
            fhijo.TopLevel = false;
            fhijo.Dock = DockStyle.Fill;
            this.panelInformacion.Controls.Add(fhijo);
            this.panelInformacion.Tag = fhijo;
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

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Entrenador());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                abrirpanelHijo(new Personas());
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "Q")
            {
                abrirpanelHijo(new Inicio());
            }
        }

        private void btnUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                abrirpanelHijo(new Usuario());
            }
        }

        private void btnEntrenador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                abrirpanelHijo(new Entrenador());
            }
        }

        private void btnClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "W")
            {
                
            }
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {

        }

        private void btnAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() =="E")
            {

            }
        }

        private void btnMembresias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "R")
            {

            }
        }

        private void btnPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "T")
            {

            }
        }
    }
}
