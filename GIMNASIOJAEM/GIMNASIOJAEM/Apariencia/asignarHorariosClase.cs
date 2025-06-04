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
    public partial class asignarHorariosClase : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        
        public asignarHorariosClase()
        {
            InitializeComponent();
        }

        private void asignarHorariosClase_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql=new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand loadEntrenador=new MySqlCommand("SELECT ID_Entrenador,concat(Nombre_Entrenador,' ',Apellido_Paterno,' ',Apellido_Materno)AS NombredeCoach FROM entrenador",mysql))
                    {
                        MySqlDataAdapter entrenadorAdapt = new MySqlDataAdapter(loadEntrenador);
                        DataTable tablaEntrenador = new DataTable();
                        entrenadorAdapt.Fill(tablaEntrenador);
                        cbEntrenador.DataSource = tablaEntrenador;
                        cbEntrenador.ValueMember = "ID_Entrenador";
                        cbEntrenador.DisplayMember = "NombredeCoach";
                    }
                    using (MySqlCommand loadClases=new MySqlCommand("SELECT ID_Clase,concat(Nombre_Clase,' ',Tipo_Clase)AS NombredeClase FROM clase",mysql))
                    {
                        MySqlDataAdapter claseAdapt = new MySqlDataAdapter(loadClases);
                        DataTable tablaClases = new DataTable();
                        claseAdapt.Fill(tablaClases);
                        cbClase.DataSource = tablaClases;
                        cbClase.ValueMember = "ID_Clase";
                        cbClase.DisplayMember = "NombredeClase";
                    }
                }
                
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql=new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand agregarHorario=new MySqlCommand("INSERT INTO horarios(Entrenador_ID,Clase_ID,Dia_Semana,Horario_Inicio,Horario_Fin) VALUES(@entrenador,@clase,@semana,@inicio,@fin)",mysql))
                    {
                        agregarHorario.Parameters.AddWithValue("@entrenador",cbEntrenador.SelectedValue);
                        agregarHorario.Parameters.AddWithValue("@clase", cbClase.SelectedValue);
                        agregarHorario.Parameters.AddWithValue("@semana",cbDiaSemana.SelectedItem);
                        agregarHorario.Parameters.AddWithValue("@inicio",dtpInicio.Value.ToString("HH:mm:ss"));
                        agregarHorario.Parameters.AddWithValue("@fin",dtpFin.Value.ToString("HH:mm:ss"));
                        agregarHorario.ExecuteNonQuery();
                    }
                    mysql.Close();
                }
            }
            catch (Exception ex) 
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
