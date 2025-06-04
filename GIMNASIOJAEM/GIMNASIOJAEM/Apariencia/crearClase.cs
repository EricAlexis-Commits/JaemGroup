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
        int cantidaddePersonas;
        int capacidadMaximadeClientes;

        private void crearClase_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ID_Entrenador,concat(Nombre_Entrenador,' ',Apellido_Paterno)AS Nombre FROM entrenador", conn);
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
                string estado = "Activa";
                string disponible = "Disponible";
                conn.Open();
                MySqlCommand query = new MySqlCommand("INSERT INTO clase(Entrenador_ID,Nombre_Clase,Capacidad_Maxima,Tipo_Clase,Estado_Clase,Vacante)" +
                    "VALUES(@entrenador,@nombre,@capacidad,@tipo,@estado,@vacante)", conn);
                query.Parameters.AddWithValue("@entrenador", cbEntrenador.SelectedValue);
                query.Parameters.AddWithValue("@nombre", tbNombre.Text);
                query.Parameters.AddWithValue("@capacidad", tbCapacidad.Text);
                query.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem);
                query.Parameters.AddWithValue("@estado",estado);
                query.Parameters.AddWithValue("@vacante",disponible);
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

    }


}
