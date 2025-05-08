using GIMNASIOJAEM.Codificacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIMNASIOJAEM.Apariencia
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }
        public static string sqlDB = "server=127.0.0.1; user=root; database=gimnasio; password=;";
        public static MySqlConnection mysql = new MySqlConnection(sqlDB);
        SQL query = new SQL(mysql);
        private void Personas_Load(object sender, EventArgs e)
        {

            try
            {
                string sqlServer = "server=127.0.0.1; user=root; database=gimnasio; password=;";
                MySqlConnection con = new MySqlConnection(sqlServer);
                SQL mysql = new SQL(con);
                mysql.fillDVG("persona", dgvPersonas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnAux_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            agregarDatos nuevo = new agregarDatos();
            nuevo.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarDatos datos = new eliminarDatos();
            datos.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand busqueda = new MySqlCommand("SELECT * FROM persona WHERE Nombre=@nombre",mysql);
            busqueda.Parameters.Add("@nombre",MySqlDbType.VarChar).Value=tbBusqueda.Text;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(busqueda);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvPersonas.DataSource = tabla;
            mysql.Close();
            

        }
    }
    
}
