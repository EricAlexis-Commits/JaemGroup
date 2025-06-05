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
    

    public partial class Rutina_Ejercicio : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        List<string> listaDias = new List<string>();
        public Rutina_Ejercicio()
        {
            InitializeComponent();
        }
        private void Rutina_Ejercicio_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conecction=new MySqlConnection(conexion))
            {
                conecction.Open();
                using (MySqlCommand cbLlenado=new MySqlCommand("SELECT ID_Rutina,concat(Nombre_Rutina)AS NombredeRutina FROM rutina",conecction))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cbLlenado);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    cbRutina.DataSource= dataTable;
                    cbRutina.ValueMember = "ID_Rutina";
                    cbRutina.DisplayMember = "NombredeRutina";
                }
                using (MySqlCommand cbLlenado2=new MySqlCommand("SELECT ID_Ejercicio,concat(Nombre_Ejercicio)AS NombredeEjercicio FROM ejercicio",conecction))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cbLlenado2);
                    DataTable dataTable2 = new DataTable(); 
                    adapter.Fill(dataTable2);
                    cbEjercicio.DataSource= dataTable2;
                    cbEjercicio.ValueMember = "ID_Ejercicio";
                    cbEjercicio.DisplayMember = "NombredeEjercicio";
                }
                conecction.Close();
            }
            nudSeries.Value = 1;
            nudRepeticiones.Value = 1;
            nudDescanso.Value = 1;
        }

        private void nudSeries_ValueChanged(object sender, EventArgs e)
        {
            nudSeries.Minimum = 1;
            nudSeries.Maximum = 4;

        }

        private void nudRepeticiones_ValueChanged(object sender, EventArgs e)
        {
            nudRepeticiones.Minimum = 1;
            nudRepeticiones.Maximum = 30;
        }

        private void nudDescanso_ValueChanged(object sender, EventArgs e)
        {
            nudDescanso.Minimum = 1;
            nudDescanso.Maximum = 3;
        }

        private void clbDiasSemana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEstructurar_Click(object sender, EventArgs e)
        {
            try
            {

                /*if (listaDias.Count == 0)
                {
                    MessageBox.Show("Selecciona un día de la semana");
                    return;
                }
                string diasConcatenados = string.Join(",",listaDias);
                */
                if (nudDescanso.Value<1 || nudSeries.Value<1 || nudRepeticiones.Value < 1)
                {
                    MessageBox.Show("Alguno de tus valores es menor a 1");
                    return;
                }
                using (MySqlConnection connection = new MySqlConnection(conexion))
                {
                    connection.Open();
                    using (MySqlCommand insert = new MySqlCommand("INSERT INTO rutina_ejercicio(Rutina_ID,Ejercicio_ID,Series,Repeticiones,Descanso,Dia_Semana)" +
                        "VALUES(@rutina,@ejercicio,@series,@rep,@descanso,@diasemana)", connection))
                    {
                        insert.Parameters.AddWithValue("@rutina", cbRutina.SelectedValue);
                        insert.Parameters.AddWithValue("@ejercicio", cbEjercicio.SelectedValue);
                        insert.Parameters.AddWithValue("@series", nudSeries.Value);
                        insert.Parameters.AddWithValue("@rep", nudRepeticiones.Value);
                        insert.Parameters.AddWithValue("@descanso", nudDescanso.Value);
                        insert.Parameters.AddWithValue("@diasemana", cbDiasSemana.SelectedItem);
                        insert.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void clbDiasSemana_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*string diaSeleccionad = clbDiasSemana.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                if (!listaDias.Contains(diaSeleccionad))
                {
                    listaDias.Add(diaSeleccionad);
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (listaDias.Contains(diaSeleccionad))
                {
                    listaDias.Remove(diaSeleccionad);
                }
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
