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
    public partial class Inicio : Form
    {
        string conn= "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conexion;
        MySqlCommand query;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            conexion = new MySqlConnection(conn);
            conexion.Open();

        }
    }
}
