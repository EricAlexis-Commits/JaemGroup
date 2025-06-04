using MySql.Data.MySqlClient;
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
    public partial class fechasMembresias : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public fechasMembresias()
        {
            InitializeComponent();
        }

        private void fechasMembresias_Load(object sender, EventArgs e)
        {
            try
            {


                using (MySqlConnection mysql = new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand loadClientes = new MySqlCommand("SELECT ID_Membresia,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombreCliente FROM membresia JOIN cliente ON cliente.ID_Cliente=membresia.Cliente_ID JOIN persona ON persona.ID_Persona=cliente.Persona_ID", mysql))
                    {
                        MySqlDataAdapter adaptClientes = new MySqlDataAdapter(loadClientes);
                        DataTable dt = new DataTable();
                        adaptClientes.Fill(dt);
                        cbCliente.DataSource = dt;
                        cbCliente.ValueMember = "ID_Membresia";
                        cbCliente.DisplayMember = "NombreCliente";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio;
            DateTime fechaVencimiento;
            try
            {
                using (MySqlConnection mysql=new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand cargarFechas=new MySqlCommand("SELECT Fecha_Inicio, Fecha_Vencimiento FROM membresia WHERE ID_Membresia=@idMembresia",mysql))
                    {
                        cargarFechas.Parameters.AddWithValue("@idMembresia",cbCliente.SelectedValue);
                        using (MySqlDataReader readerFechas = cargarFechas.ExecuteReader())
                        {
                            if (readerFechas.Read())
                            {
                                fechaInicio = Convert.ToDateTime(readerFechas["Fecha_Inicio"].ToString());
                                fechaVencimiento = Convert.ToDateTime(readerFechas["Fecha_Vencimiento"].ToString());
                                lblInicio.Text = fechaInicio.ToString("dd/MM/yyyy");
                                lblVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy");
                            }
                        }
                        

                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
