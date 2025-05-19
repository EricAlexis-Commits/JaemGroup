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
    public partial class Entrenador : Form
    {
        public Entrenador()
        {
            InitializeComponent();
        }
        static string conexion = "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void button1_Click(object sender, EventArgs e)
        {
            registrarEntrenador registro = new registrarEntrenador();
            registro.ShowDialog();
            
        }

        private void Entrenador_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand command = new MySqlCommand("SELECT Nombre,Apellido_Paterno,Apellido_Materno,Especialidad FROM entrenador",mysql);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable= new DataTable();
            dataAdapter.Fill(dataTable);
            dgvEntrenador.DataSource = dataTable;
        }
    }
}
