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

namespace GIMNASIOJAEM
{
    public partial class crearMembresia : Form
    {
        public crearMembresia()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        ComboBox mensualidades = new ComboBox();
        
        

        private void crearMembresia_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand query = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCompleto FROM cliente JOIN persona ON cliente.Persona_ID=persona.ID_Persona;",mysql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbCliente.DataSource = dt;
            cbCliente.ValueMember = "ID_Cliente";
            cbCliente.DisplayMember = "NombreCompleto";
            mysql.Close();
            
            dtpInicio.ShowUpDown = false;
            dtpVencimiento.ShowUpDown = false;

        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaVencimiento = new DateTime();
            switch (cbTipo.SelectedItem.ToString())
            {
                case "Visita":
                    
                    fechaVencimiento =dtpVencimiento.Value.Date;
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
                case "Semanal":
                    fechaVencimiento = fechaInicio.AddDays(7);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
                case "Quincenal":
                    fechaVencimiento = fechaInicio.AddDays(15);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
                case "Mensual":
                    fechaVencimiento = fechaInicio.AddMonths(1);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
                case "Semestral":
                    fechaVencimiento = fechaInicio.AddMonths(6);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
                case "Mensual Estudiante":
                    fechaVencimiento = fechaInicio.AddMonths(1);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;

                case "Semestral Estudiante":
                    fechaVencimiento = fechaInicio.AddMonths(6);
                    dtpVencimiento.Value = fechaVencimiento;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = Convert.ToDateTime(dtpInicio.Value.Date.ToString());
                DateTime fechaFinal = Convert.ToDateTime(dtpVencimiento.Value.Date.ToString());
                string estatus = "Activa";
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO membresia(Cliente_ID,Tipo_Membresia,Fecha_Inicio,Fecha_Vencimiento,Estatus_Membresia) " +
                    "VALUES(@cliente,@tipo,@fechaInicio,@fechaVencimiento,@estatusMembresia)", mysql);
                cmd.Parameters.AddWithValue("@cliente", cbCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicial);
                cmd.Parameters.AddWithValue("@fechaVencimiento", fechaFinal);
                cmd.Parameters.AddWithValue("@estatusMembresia", estatus);
                cmd.ExecuteNonQuery();
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Close();
            }
        }
    }
}
