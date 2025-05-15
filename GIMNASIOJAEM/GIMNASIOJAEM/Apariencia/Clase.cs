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
    public partial class Clase : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        public Clase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearClase create = new crearClase();
            create.ShowDialog();
        }

        private void Clase_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM clase",mysql);
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgvClase.DataSource = dt;

        }
    }
}
