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
        public static string sqlDB = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public static MySqlConnection mysql = new MySqlConnection(sqlDB);
        SQL query = new SQL(mysql);
        private void Personas_Load(object sender, EventArgs e)
        {

            try
            {
                string sqlServer = "server=127.0.0.1; user=root; database=gimnasios; password=;";
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
            nuevo.ocultarDatos();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarDatos datos = new eliminarDatos();
            datos.ShowDialog();
            
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbBusqueda.Text != "")
            {
                //Abrimos la conexion
                mysql.Open();
                //Creamos la query de busqueda
                MySqlCommand busqueda = new MySqlCommand("SELECT * FROM persona WHERE Nombre=@nombre", mysql);
                //La consulta se hace en base a el nombre cuyo tipo va ser un varchar, ubicado en tbBusqueda
                busqueda.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = tbBusqueda.Text;
                //Creamos un adaptador
                MySqlDataAdapter adaptador = new MySqlDataAdapter(busqueda);
                //Creamos un objeto tipo datatable
                DataTable tabla = new DataTable();
                //Llenamos la tabla con ayuda del adaptador
                adaptador.Fill(tabla);
                //Los datos de la variable tabla va ser igual a los datos del dgv
                dgvPersonas.DataSource = tabla;
                //Se cierra la conexion
                mysql.Close();
            }
            else
            {
                //Abrimos la conexion
                mysql.Open();
                //Creamos la query de busqueda
                MySqlCommand busqueda = new MySqlCommand("SELECT * FROM persona", mysql);
                //La consulta se hace en base a el nombre cuyo tipo va ser un varchar, ubicado en tbBusqueda
                //busqueda.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = tbBusqueda.Text;
                //Creamos un adaptador
                MySqlDataAdapter adaptador = new MySqlDataAdapter(busqueda);
                //Creamos un objeto tipo datatable
                DataTable tabla = new DataTable();
                //Llenamos la tabla con ayuda del adaptador
                adaptador.Fill(tabla);
                //Los datos de la variable tabla va ser igual a los datos del dgv
                dgvPersonas.DataSource = tabla;
                //Se cierra la conexion
                mysql.Close();
            }
        }
        public void refrescarForm(string tabla)
        {
            mysql.Open();

            MySqlCommand busqueda = new MySqlCommand($"SELECT * FROM {tabla}", mysql);


            MySqlDataAdapter adaptador = new MySqlDataAdapter(busqueda);

            DataTable table = new DataTable();

            adaptador.Fill(table);

            dgvPersonas.DataSource = table;

            mysql.Close();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            agregarDatos nuevos = new agregarDatos();
            nuevos.ShowDialog();
            nuevos.revelarDatos();
        }
    }
    
}
