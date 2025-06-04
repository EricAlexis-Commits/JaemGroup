using GIMNASIOJAEM.Codificacion;
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
    public partial class Clase : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        public Clase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearClase create = new crearClase();
            create.ShowDialog();
            refreshDGV();
        }

        private void Clase_Load(object sender, EventArgs e)
        {
            if (Sension.permisoUsuario!="Administrador") 
            {
                btnDesactivar.Enabled = false;
                btnDesactivar.BackColor = Color.Red;
                
            }
            try
            {
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ID_Clase,Entrenador_ID,concat(entrenador.Nombre_Entrenador,' ',entrenador.Apellido_Paterno,' ',entrenador.Apellido_Materno)AS NombreEntrenador,Capacidad_Maxima,Tipo_Clase,Estado_Clase,Vacante FROM clase JOIN entrenador ON entrenador.ID_Entrenador=clase.Entrenador_ID", mysql);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvClase.DataSource = dt;
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }

        private void btnCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = "Activado";
                string vacante = "Disponible";
                mysql.Open();
                MySqlCommand query = new MySqlCommand($"SELECT Nombre_Clase,Tipo_Clase,Estado_Clase,Vacante,Capacidad_Maxima FROM clase WHERE Estado_Clase=@estado AND Vacante=@vacante", mysql);
                query.Parameters.AddWithValue("@estado",estado);
                query.Parameters.AddWithValue("@vacante",vacante);
                query.ExecuteNonQuery();
                MySqlDataAdapter data = new MySqlDataAdapter(query);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dgvClase.DataSource = dt;
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            asignarClase asignacion = new asignarClase();
            asignacion.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCrearHorarios_Click(object sender, EventArgs e)
        {
            asignarHorariosClase asignar = new asignarHorariosClase();
            asignar.ShowDialog();
            refreshDGV();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mysql.Open();
            using (MySqlCommand horarios=new MySqlCommand("SELECT h.ID_Horario, h.Entrenador_ID,CONCAT(e.Nombre_Entrenador, ' ', e.Apellido_Paterno) AS CoachNombre,h.Clase_ID,(c.Nombre_Clase) AS NombreClase,h.Dia_Semana,h.Horario_Inicio,h.Horario_Fin FROM horarios h JOIN entrenador e ON e.ID_Entrenador = h.Entrenador_ID JOIN clase c ON c.ID_Clase = h.Clase_ID", mysql))
            {
                MySqlDataAdapter horariosLectura = new MySqlDataAdapter(horarios);
                DataTable tablaHorarios = new DataTable();
                horariosLectura.Fill(tablaHorarios);
                dgvClase.DataSource = tablaHorarios;

            }
            mysql.Close();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            desactivarClase desactivar = new desactivarClase();
            desactivar.ShowDialog();
            refreshDGV();
        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql = new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand refrescar = new MySqlCommand("SELECT ID_Clase,Entrenador_ID,concat(entrenador.Nombre_Entrenador,' ',entrenador.Apellido_Paterno,' ',entrenador.Apellido_Materno)AS NombreEntrenador,Capacidad_Maxima,Tipo_Clase,Estado_Clase,Vacante FROM clase JOIN entrenador ON entrenador.ID_Entrenador=clase.Entrenador_ID", mysql))
                {
                    {
                        MySqlDataAdapter adaptadorDGV = new MySqlDataAdapter(refrescar);
                        DataTable dt = new DataTable();
                        adaptadorDGV.Fill(dt);
                        dgvClase.DataSource = dt;
                    }
                }
            }
        }
    }
}
