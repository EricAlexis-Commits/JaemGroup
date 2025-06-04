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
    public partial class crearRutina : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        string fechaHoy = DateTime.Now.ToString("yyyy:MM:dd");
        public crearRutina()
        {
            InitializeComponent();
        }

        private void crearRutina_Load(object sender, EventArgs e)
        {
            
            try
            {
                mysql.Open();
                MySqlCommand query = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCompleto FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID", mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbClientes.DataSource = dt;
                cbClientes.ValueMember = "ID_Cliente";
                cbClientes.DisplayMember = "NombreCompleto";
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbEntrenador.Enabled = true;
            if (cbEntrenador.Enabled==true)
            {
                mysql.Open();
                MySqlCommand entrenadores = new MySqlCommand("SELECT ID_Entrenador,concat (Nombre_Entrenador,' ',Apellido_Paterno)AS NombreEntrenador FROM entrenador", mysql);
                MySqlDataAdapter adapt = new MySqlDataAdapter(entrenadores);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                cbEntrenador.DataSource = dt;
                cbEntrenador.ValueMember = "ID_Entrenador";
                cbEntrenador.DisplayMember = "NombreEntrenador";
                mysql.Close();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validacionCampos())
            {
                try
                {
                    mysql.Open();
                    MySqlCommand insertar = new MySqlCommand("INSERT INTO rutina(Cliente_ID,Nombre_Rutina,Fecha_Creacion,Objetivo)" +
                        "VALUES (@cliente,@nombre,@fecha,@objetivo)", mysql);
                    insertar.Parameters.AddWithValue("@cliente", cbClientes.SelectedValue);
                    insertar.Parameters.AddWithValue("@nombre", tbRutina.Text);
                    insertar.Parameters.AddWithValue("@fecha",fechaHoy);
                    insertar.Parameters.AddWithValue("@objetivo", tbObjetivo.Text);
                    insertar.ExecuteNonQuery();
                    mysql.Close();
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
        private bool validacionCampos()
        {
            if (cbClientes.SelectedValue.ToString() != "" && tbRutina.Text!=""&& tbObjetivo.Text!="")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Campos Clientes, Nombre rutina y Objetivo Obligatorios ");
            }
            return false;
        }
    }
}
