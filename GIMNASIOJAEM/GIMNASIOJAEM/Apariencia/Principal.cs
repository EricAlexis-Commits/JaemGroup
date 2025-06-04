using GIMNASIOJAEM.Codificacion;
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
        Button[] botones;

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
            botones = new Button[] {btnInicio,btnPersonas,btnUsuario,btnEntrenador,btnClientes,btnClases,btnMembresias,btnPago,btnAsistencia,btnRutinas };
            if (Sension.permisoUsuario=="Entrenador")
            {
                
                btnPersonas.Enabled = false;
                btnUsuario.Enabled = false;
                btnClientes.Enabled = false;
                btnMembresias.Enabled = false;
                btnPago.Enabled = false;
                btnAsistencia.Enabled = false;

                btnPersonas.BackColor = Color.Red;
                btnUsuario.BackColor = Color.Red;
                btnClientes.BackColor = Color.Red;
                btnMembresias.BackColor = Color.Red;
                btnPago.BackColor = Color.Red;
                btnAsistencia.BackColor= Color.Red;

            }
            lblUser.Text = Sension.usuarioActual;
            abrirpanelHijo(new Inicio());
            
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
            abrirpanelHijo(new Clase());
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Clientes());
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Membresia());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Inicio());
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            Pagos formPagos = new Pagos();
            formPagos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Asistencia());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirpanelHijo(new Rutinas());
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Clientes());
        }

        private void btnPersonas_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Personas());
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnMembresias_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Membresia());
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Usuario());
        }

        private void btnAsistencia_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Clase());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Rutinas());
        }

        private void btnPago_Click_1(object sender, EventArgs e)
        {
            Pagos pagar = new Pagos();
            pagar.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEntrenador_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Entrenador());
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Inicio());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            abrirpanelHijo(new Asistencia());
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void ajustarAncho()
        {
            var botones = panel1.Controls.OfType<Button>().ToList();
            int altoDisponible = panel1.Width - 20;
            int anchoPorBoton = altoDisponible / botones.Count;
            for (int i=0; i<botones.Count; i++)
            {
                botones[i].Width = anchoPorBoton;
                botones[i].Left = i * anchoPorBoton + 10;
            }
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            ajustarAncho();
        }
    }
}
