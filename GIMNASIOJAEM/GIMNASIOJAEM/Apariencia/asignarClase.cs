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
    public partial class asignarClase : Form
    {
        public asignarClase()
        {
            InitializeComponent();
        }
        static string conexion = "server = 127.0.0.1; user = root; database = gimnasios; password =;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void asignarClase_Load(object sender, EventArgs e)
        {
            try
            {
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

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /*
         * 
         * MySqlConnection mysql = new MySqlConnection("server = 127.0.0.1; user = root; database = gimnasios; password =;");
                mysql.Open();
                MySqlCommand comm = new MySqlCommand("SELECT Clave_Usuario,concat(Nombre_Usuario,' ',Tipo_Usuario)AS Nombre_Usuario FROM usuario",mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbUsuarios.DataSource = dt;
                cbUsuarios.ValueMember = "Clave_Usuario";
                cbUsuarios.DisplayMember = "Nombre_Usuario";
                mysql.Close();
        */
    }
}
