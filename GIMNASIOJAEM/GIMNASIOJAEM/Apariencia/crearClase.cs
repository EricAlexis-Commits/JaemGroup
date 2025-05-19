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

                MySqlCommand query = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCompleto FROM cliente JOIN persona ON cliente.Persona_ID=persona.ID_Persona;",conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                cbCliente.DataSource = datatable;
                cbCliente.ValueMember = "ID_Cliente";
                cbCliente.DisplayMember = "NombreCompleto";
                

                conn.Close();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        /*
               //Llena el comboBox con una consulta de las clases disponibles, seleccionado su ID y mostrandolo como nombre y tipo de clase
               mysql.Open();
               MySqlCommand query = new MySqlCommand("SELECT ID_Clase,concat(Nombre,' ',Tipo_Clase)AS Nombre FROM clase",mysql);
               MySqlDataAdapter adapter = new MySqlDataAdapter(query);
               DataTable dt = new DataTable();
               adapter.Fill(dt);
               cbClases.DataSource = dt;
               cbClases.ValueMember = "ID_Clase";
               cbClases.DisplayMember = "Nombre";
               mysql.Close();
               //Llenar el otro comboBox de Clientes para asignar clase dentro de la tabla clase
               //Se prefiere usar consulta JOIN de clientes y persona
               mysql.Open();
               query = new MySqlCommand("SELECT cliente.ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCompleto" +
                   "FROM cliente JOIN persona on cliente.Persona_ID=persona.ID_Cliente",mysql);
               adapter = new MySqlDataAdapter(query);
               dt = new DataTable();
               adapter.Fill(dt);
               cbClientes.DataSource = dt;
               cbClientes.ValueMember = "ID_Cliente";
               cbClientes.DisplayMember = "NombreCompleto";
               mysql.Close();
               */
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand("SELECT COUNT(*)FROM clase WHERE Tipo_Clase=");
                string disponible = "Disponible";
                conn.Open();
                MySqlCommand query = new MySqlCommand("INSERT INTO clase(Entrenador_ID,Cliente_ID,Nombre,Capacidad_Maxima,Tipo_Clase,Estado_Clase,Vacante)" +
                    "VALUES(@entrenador,@cliente,@nombre,@capacidad,@tipo,@estado,@vacante)", conn);
                query.Parameters.AddWithValue("@entrenador", cbEntrenador.SelectedValue);
                query.Parameters.AddWithValue("@cliente", cbCliente.SelectedValue);
                query.Parameters.AddWithValue("@nombre", tbNombre.Text);
                query.Parameters.AddWithValue("@capacidad", tbCapacidad.Text);
                query.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem);
                query.Parameters.AddWithValue("@estado",cbEstado.SelectedItem);
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
