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

namespace GIMNASIOJAEM
{
    public partial class crearEjercicios : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public crearEjercicios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbNombreEjercicio.Text.Length>70 && tbDescripcionGeneral.Text.Length > 100)
            {
                MessageBox.Show("Los caracteres del Nombre y Descripcion son muy largos reducelos");
            }
            else if (cbDificultad.SelectedItem.ToString() == "" && cbGrupoMuscular.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Selecciona por favor algunos elementos de Dificultad y Grupo Muscular");
            }
            else
            {
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(conexion))
                    {
                        mysql.Open();
                        using (MySqlCommand insertExercises = new MySqlCommand("INSERT INTO ejercicio(Nombre_Ejercicio,Descripcion_Ejercicio,Grupo_Muscular,Dificultad) VALUES (@name,@description,@body,@dificulty)", mysql))
                        {
                            insertExercises.Parameters.AddWithValue("@name", tbNombreEjercicio.Text);
                            insertExercises.Parameters.AddWithValue("@description", tbDescripcionGeneral.Text);
                            insertExercises.Parameters.AddWithValue("@body", cbGrupoMuscular.SelectedItem);
                            insertExercises.Parameters.AddWithValue("@dificulty", cbDificultad.SelectedItem);
                            insertExercises.ExecuteNonQuery();
                        }
                        mysql.Close();
                    }
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
}
