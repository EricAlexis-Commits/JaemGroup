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
    public partial class Entrenador : Form
    {
        public Entrenador()
        {
            InitializeComponent();
        }
        static string conexion = "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void button1_Click(object sender, EventArgs e)
        {
            registrarEntrenador registro = new registrarEntrenador();
            registro.ShowDialog();
            
        }

        private void Entrenador_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand command = new MySqlCommand("SELECT Nombre,Apellido_Paterno,Apellido_Materno,Especialidad FROM entrenador",mysql);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable= new DataTable();
            dataAdapter.Fill(dataTable);
            dgvEntrenador.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            especialidadCertificacion especialidad = new especialidadCertificacion();
            especialidad.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Llena el datagridview con datos de una consulta o clausla join de la tabla
            //Entrenador, Rutina y Clase
            mysql.Open();
            using (MySqlCommand join=new MySqlCommand("SELECT entrenador.Nombre,entrenador.Apellido_Paterno,entrenador.Apellido_Materno,rutina.Nombre_Rutina,clase.Nombre FROM entrenador JOIN rutina ON rutina.Entrenador_ID=entrenador.ID_Entrenador JOIN clase ON clase.Entrenador_ID=entrenador.ID_Entrenador;", mysql))
            {
                MySqlDataAdapter mysqlAdapter = new MySqlDataAdapter(join);
                DataTable table = new DataTable();
                mysqlAdapter.Fill(table);
                dgvEntrenador.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mysql.Open();
            using (MySqlCommand rutinaJoin=new MySqlCommand("SELECT `Nombre_Entrenador`,`Apellido_Paterno`,`Especialidad`,rutina.Nombre_Rutina,rutina.Objetivo FROM entrenador JOIN rutina ON rutina.Entrenador_ID=entrenador.ID_Entrenador;", mysql))
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter(rutinaJoin);
                DataTable dataTables = new DataTable();
                adapt.Fill(dataTables);
                dgvEntrenador.DataSource=dataTables;
            }
        }
    }
}
