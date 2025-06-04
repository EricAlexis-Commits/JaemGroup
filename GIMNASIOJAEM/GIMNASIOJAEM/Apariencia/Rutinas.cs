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
    public partial class Rutinas : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public Rutinas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearRutina rutina = new crearRutina();
            rutina.ShowDialog();
            refreshDGV();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            asignamientoEntrenador asignamiento = new asignamientoEntrenador();
            asignamiento.ShowDialog();
            refreshDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crearEjercicios creacion = new crearEjercicios();
            creacion.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rutina_Ejercicio rutinas = new Rutina_Ejercicio();
            rutinas.ShowDialog();
        }

        private void Rutinas_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand loadQuery=new MySqlCommand("SELECT Clave_Cliente,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,rutina.Nombre_Rutina,rutina.Fecha_Creacion,rutina.Objetivo FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID LEFT JOIN rutina ON rutina.Cliente_ID=cliente.ID_Cliente", mysql))
                {
                    MySqlDataAdapter adapt = new MySqlDataAdapter(loadQuery);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dgvRutina.DataSource = dt;
                }
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand loadRutinaEjercicio=new MySqlCommand("SELECT re.Rutina_ID,r.Nombre_Rutina,e.Nombre_Ejercicio,re.Series,re.Repeticiones,re.Descanso,re.Dia_Semana FROM rutina_ejercicio re JOIN ejercicio e ON re.Ejercicio_ID = e.ID_Ejercicio JOIN rutina r ON r.ID_Rutina=re.Rutina_ID",mysql))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(loadRutinaEjercicio);
                    DataTable tablaRutinaEjercicio = new DataTable();
                    adapter.Fill(tablaRutinaEjercicio);
                    dgvRutina.DataSource = tablaRutinaEjercicio;
                }
            }
        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand loadDGV=new MySqlCommand("SELECT Clave_Cliente,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,rutina.Nombre_Rutina,rutina.Fecha_Creacion,rutina.Objetivo FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID LEFT JOIN rutina ON rutina.Cliente_ID=cliente.ID_Cliente",mysql))
                {
                    MySqlDataAdapter loadAdapt = new MySqlDataAdapter(loadDGV);
                    DataTable dt = new DataTable();
                    loadAdapt.Fill(dt);
                    dgvRutina.DataSource = dt;
                }
            }
        }
    }
}
