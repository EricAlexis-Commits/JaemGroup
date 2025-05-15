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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            registroCliente registro = new registroCliente();
            registro.ShowDialog();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand query = new MySqlCommand("SELECT Persona_ID,Clave_Cliente,Objetivos,Nivel_Experiencia FROM cliente",mysql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvClientes.DataSource = dt;

        }

        private void btnObjetivos_Click(object sender, EventArgs e)
        {
            objetivo objetivos = new objetivo();
            objetivos.ShowDialog();
        }
    }
}
