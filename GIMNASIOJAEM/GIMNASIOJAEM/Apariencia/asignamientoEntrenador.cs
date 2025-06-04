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
    public partial class asignamientoEntrenador : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        public asignamientoEntrenador()
        {
            InitializeComponent();
        }
        private void asignamientoEntrenador_Load(object sender, EventArgs e)
        {
            mysql.Open();
            try
            {
             
                MySqlCommand query = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS ClienteNombre FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql);
                MySqlDataAdapter adapt = new MySqlDataAdapter(query);
                DataTable tablaDeDatos = new DataTable();
                adapt.Fill(tablaDeDatos);
                cbCliente.DataSource = tablaDeDatos;
                cbCliente.ValueMember = "ID_Cliente";
                cbCliente.DisplayMember = "ClienteNombre";
                MySqlCommand query2 = new MySqlCommand("SELECT ID_Entrenador, concat(Nombre_Entrenador,' ',Apellido_Paterno,' ',Apellido_Materno)AS NombredeEntrenador FROM entrenador", mysql);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query2);
                DataTable tabladeEntrenador = new DataTable();
                adaptador.Fill(tabladeEntrenador);
                cbEntrenador.DataSource = tabladeEntrenador;
                cbEntrenador.ValueMember = "ID_Entrenador";
                cbEntrenador.DisplayMember = "NombredeEntrenador";
            }
             
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            mysql.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mysql.Open();
                using (MySqlCommand update = new MySqlCommand("UPDATE rutina SET Entrenador_ID=@entrenador WHERE Cliente_ID=@cliente", mysql))
                {
                    update.Parameters.AddWithValue("@entrenador", cbEntrenador.SelectedValue);
                    update.Parameters.AddWithValue("@cliente",cbCliente.SelectedValue);
                    update.ExecuteNonQuery();
                }
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
}
