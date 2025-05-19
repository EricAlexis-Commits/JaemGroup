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
        }

        private void Membresia_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand query = new MySqlCommand("SELECT Cliente_ID,Tipo_Membresia,Fecha_Inicio,Fecha_Vencimiento,Estatus_Membresia FROM membresia",mysql);
            MySqlDataAdapter adapt = new MySqlDataAdapter(query);
            DataTable data = new DataTable();
            adapt.Fill(data);
            dgvMembresia.DataSource = data;
        }
        
    }
}
