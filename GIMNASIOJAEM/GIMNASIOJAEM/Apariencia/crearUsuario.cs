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
    public partial class crearUsuario : Form
    {
        public crearUsuario()
        {
            InitializeComponent();
            btnCrear = boton;
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        public MySqlConnection mysql = new MySqlConnection(conexion);
        public Button boton = new Button();
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (checarCampos()==false)
            {
                MessageBox.Show("Te falto agregar un dato");
            }
            else
            {
                try
                {
                    string estado = "Activo";
                    DateTime myDate = Convert.ToDateTime(dtpDate.Value.Date.ToString("dd-MM-yyyy"));
                    mysql.Open();
                    MySqlCommand query = new MySqlCommand("INSERT INTO usuario(Clave_Usuario,Nombre_Usuario,Tipo_Usuario,Fecha_Registro,Contraseña,Estado) " +
                        "VALUES (@clave,@nombre,@tipo,@fecha,@password,@status)",mysql);
                    query.Parameters.AddWithValue("@clave",tbCode.Text);
                    query.Parameters.AddWithValue("@nombre", tbName.Text);
                    query.Parameters.AddWithValue("@tipo", cbUserType.SelectedItem.ToString());
                    query.Parameters.AddWithValue("@fecha", myDate);
                    query.Parameters.AddWithValue("@password", tbPassword.Text);
                    query.Parameters.AddWithValue("@status", estado);
                    query.ExecuteNonQuery();

                    mysql.Close();


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("Hecho con exito");
                    this.Close();
                }
            }
        }
        private bool checarCampos()
        {
            if (string.IsNullOrEmpty(tbCode.Text) && string.IsNullOrEmpty(tbName.Text)&& string.IsNullOrEmpty(tbPassword.Text)
                && string.IsNullOrEmpty(cbUserType.SelectedText) && string.IsNullOrEmpty(dtpDate.Text))
            {
                return false;
            }
            return true;
        }
    }
}
