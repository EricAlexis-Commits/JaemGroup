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
    public partial class crearClase : Form
    {
        public crearClase()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conn = new MySqlConnection(conexion);

        private void crearClase_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ID_Entrenador,concat(Nombre,' ',Apellido_Paterno)AS Nombre FROM entrenador", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbEntrenador.DataSource = dt;
                cbEntrenador.ValueMember = "ID_Entrenador";
                cbEntrenador.DisplayMember = "Nombre";
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand query = new MySqlCommand("INSERT INTO clase(Entrenador_ID,Nombre,Descripcion,Capacidad_Maxima,Tipo_Clase)" +
                    "VALUES(@entrenador,@nombre,@descripcion,@capacidad,@tipo)", conn);
                query.Parameters.AddWithValue("@entrenador", cbEntrenador.SelectedValue);
                query.Parameters.AddWithValue("@nombre", tbNombre.Text);
                query.Parameters.AddWithValue("@descripcion", tbDescripcion.Text);
                query.Parameters.AddWithValue("@capacidad", tbCapacidad.Text);
                query.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem.ToString());
                query.ExecuteNonQuery();
                conn.Close();
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
        /*
* 
*  mySql.Open();
MySqlCommand cmd = new MySqlCommand("SELECT ID_Persona,concat(Nombre,' ',Apellido_Paterno,' ',Apellido_Materno) AS Nombre FROM persona",mySql);
MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);
cbPersonasID.DataSource = dt;
cbPersonasID.ValueMember = "ID_Persona";
cbPersonasID.DisplayMember = "Nombre";
mySql.Close();
* 
* */
    }


}
