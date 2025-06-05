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
    public partial class Membresia : Form
    {
        public Membresia()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void btnCrear_Click(object sender, EventArgs e)
        {
            crearMembresia crear = new crearMembresia();
            crear.ShowDialog();
            refreshDGV();
        }

        private void Membresia_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand query = new MySqlCommand("SELECT Cliente_ID,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombredeCliente,Tipo_Membresia,Fecha_Inicio,Fecha_Vencimiento,Estatus_Membresia FROM membresia JOIN cliente ON cliente.ID_Cliente=membresia.Cliente_ID JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql);
            MySqlDataAdapter adapt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            adapt.Fill(data);
            dgvMembresia.DataSource = data;
        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand refresh=new MySqlCommand("SELECT Cliente_ID,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombredeCliente,Tipo_Membresia,Fecha_Inicio,Fecha_Vencimiento,Estatus_Membresia FROM membresia JOIN cliente ON cliente.ID_Cliente=membresia.Cliente_ID JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql))
                {
                    MySqlDataAdapter adapt = new MySqlDataAdapter(refresh);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dgvMembresia.DataSource = dt;
                }
            }
        }

        private void btnFechas_Click(object sender, EventArgs e)
        {
            fechasMembresias fechas = new fechasMembresias();
            fechas.ShowDialog();
        }

        private void btnEstatus_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand estatus=new MySqlCommand("SELECT m.ID_Membresia,m.Cliente_ID,CONCAT(p.Nombre, ' ', p.Apellido_Paterno, ' ', p.Apellido_Materno) AS NombredeCliente,pg.Estatus_Pago FROM membresia m JOIN cliente c ON c.ID_Cliente = m.Cliente_ID JOIN persona p ON p.ID_Persona = c.Persona_ID JOIN pagos pg ON pg.Membresia_ID = m.ID_Membresia", mysql))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(estatus);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMembresia.DataSource = dt;
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Pagos pagar = new Pagos();
            pagar.ShowDialog();
        }
    }
}
