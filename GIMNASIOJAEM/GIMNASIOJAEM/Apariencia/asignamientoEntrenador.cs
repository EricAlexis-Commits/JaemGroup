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
            MySqlCommand query = new MySqlCommand("SELECT ID_Cliente, concat (persona.Nombre,' ',persona.Apellido_Paterno)AS ClienteNombre JOIN persona ON cliente.Persona_ID=persona.ID_Cliente",mysql);
            MySqlDataAdapter adapt = new MySqlDataAdapter(query);
            DataTable tablaDeDatos= new DataTable();
            adapt.Fill(tablaDeDatos);
            
        }
    }
}
