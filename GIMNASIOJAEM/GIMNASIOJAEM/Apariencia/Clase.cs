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
            try
            {
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clase", mysql);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvClase.DataSource = dt;
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }

        private void btnCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = "Activa";
                string vacante = "Disponible";
                mysql.Open();
                MySqlCommand query = new MySqlCommand($"SELECT Nombre,Tipo_Clase,Estado_Clase,Vacante FROM clase WHERE Estado_Clase={estado} AND Vacante={vacante}", mysql);
                MySqlDataAdapter data = new MySqlDataAdapter(query);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvClase.DataSource = dt;
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            asignarClase asignacion = new asignarClase();
            asignacion.ShowDialog();
        }
    }
}
