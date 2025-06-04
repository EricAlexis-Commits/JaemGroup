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
    public partial class Asistencia : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public Asistencia()
        {
            InitializeComponent();
        }

        private void btnAsistir_Click(object sender, EventArgs e)
        {
            agregarAsistencia agregar = new agregarAsistencia();
            agregar.ShowDialog();
            refreshDGV();
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand loadAsistencia = new MySqlCommand("SELECT ID_Asistencia,Cliente_ID,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombredeCliente,Fecha_Asistencia,Horario_Asistencia FROM asistencia JOIN cliente ON cliente.ID_Cliente=asistencia.Cliente_ID JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql))
                {
                    MySqlDataAdapter adapt = new MySqlDataAdapter(loadAsistencia);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dgvAsistencia.DataSource = dt;
                }
            }
        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand refresh=new MySqlCommand("SELECT ID_Asistencia,Cliente_ID,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombredeCliente,Fecha_Asistencia,Horario_Asistencia FROM asistencia JOIN cliente ON cliente.ID_Cliente=asistencia.Cliente_ID JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(refresh);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAsistencia.DataSource = dt;
                }
            }
        }
    }
}
