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
    public partial class objetivo : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        public objetivo()
        {
            InitializeComponent();
        }

        private void objetivo_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Clave_Cliente FROM cliente",mysql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbClave.DataSource = dt;
            cbClave.ValueMember = "Clave_Cliente";
            mysql.Close();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE cliente SET Objetivos=@objetivo,Nivel_Experiencia=@experiencia WHERE Clave_Cliente=@clave", mysql);
                cmd.Parameters.AddWithValue("@clave",cbClave.SelectedValue);
                cmd.Parameters.AddWithValue("@objetivo", tbObjetivo.Text);
                cmd.Parameters.AddWithValue("@experiencia", cbExperiencia.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                mysql.Close();
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
