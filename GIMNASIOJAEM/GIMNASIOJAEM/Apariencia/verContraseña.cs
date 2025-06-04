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
    public partial class verContraseña : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public verContraseña()
        {
            InitializeComponent();
        }

        private void verContraseña_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand load = new MySqlCommand("SELECT ID_Usuario,concat(Nombre_Usuario,' ',Tipo_Usuario)AS NombreUsuario FROM usuario",mysql))
                {
                    MySqlDataAdapter adaptLoad = new MySqlDataAdapter(load);
                    DataTable dt = new DataTable();
                    adaptLoad.Fill(dt);
                    cbUsuarios.DataSource = dt;
                    cbUsuarios.ValueMember = "ID_Usuario";
                    cbUsuarios.DisplayMember = "NombreUsuario";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contraseña;
            if (tbContraseñas.Text != "")
            {
                tbContraseñas.Clear();
            }
            else
            {
                using (MySqlConnection mysql=new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand cargar=new MySqlCommand("SELECT Contraseña FROM usuario WHERE ID_Usuario=@idUser",mysql))
                    {
                        cargar.Parameters.AddWithValue("@idUser",cbUsuarios.SelectedValue);
                        contraseña = cargar.ExecuteScalar()?.ToString();
                        tbContraseñas.Text = contraseña;
                    }
                }
            }
        }

        private void chbContraseñas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbContraseñas.Checked == true)
            {
                tbContraseñas.UseSystemPasswordChar = false;
            }
            else
            {
                tbContraseñas.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
