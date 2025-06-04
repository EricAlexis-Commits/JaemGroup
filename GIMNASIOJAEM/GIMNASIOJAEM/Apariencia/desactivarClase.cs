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
    public partial class desactivarClase : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public desactivarClase()
        {
            InitializeComponent();
        }

        private void desactivarClase_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand claseDesactivar = new MySqlCommand("SELECT ID_Clase, concat(Nombre_Clase)AS NombredeClase FROM clase", mysql))
                    {
                        MySqlDataAdapter adaptClase = new MySqlDataAdapter(claseDesactivar);
                        DataTable tablaClase = new DataTable();
                        adaptClase.Fill(tablaClase);
                        cbClase.DataSource = tablaClase;
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
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (MySqlConnection mysql = new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand desactivar = new MySqlCommand("UPDATE clase SET Estado_Clase=@estado WHERE ID_Clase=@idClase", mysql))
                    {
                        desactivar.Parameters.AddWithValue("@estado", cbOpciones.SelectedItem);
                        desactivar.Parameters.AddWithValue("@idClase", cbClase.SelectedValue);
                        desactivar.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Estado cambiado");
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
