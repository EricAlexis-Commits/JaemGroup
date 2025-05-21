using GIMNASIOJAEM.Apariencia;
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

namespace GIMNASIOJAEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string mysqlConn = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        static MySqlConnection mysql = new MySqlConnection(mysqlConn);
        private void btnEnter_Click(object sender, EventArgs e)
        {

            CMD logear = new CMD();
            Sension.usuarioActual = tbUserName.Text;
            logear.seleccionarUsuario(tbUserName.Text,tbUserPassword.Text);
            this.Hide();
            
        }
        
        class CMD
        {
            public void seleccionarUsuario(string nombre, string contraseña)
            {
                try
                {
                    //Abrimos primeramente la base de datos
                    mysql.Open();
                    MySqlCommand consulta = new MySqlCommand("SELECT Nombre_Usuario, Tipo_Usuario,Estado FROM usuario WHERE Nombre_Usuario= @nombre AND Contraseña=@contraseña AND Estado='Activo'", mysql);
                    consulta.Parameters.AddWithValue("@nombre", nombre);
                    consulta.Parameters.AddWithValue("@contraseña", contraseña);
                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(consulta);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][1].ToString() == "Administrador" || dt.Rows[0][1].ToString() == "administrador")
                        {
                            
                            Principal menu = new Principal();
                            menu.Show();
                            
                            
                        }
                        else if (dt.Rows[0][1].ToString()=="Encargado" || dt.Rows[0][1].ToString() == "encargado")
                        {
                            Principal menu = new Principal();
                            menu.Show();
                           
                        }
                        else if (dt.Rows[0][1].ToString()=="Entrenador" || dt.Rows[0][1].ToString() == "entrenador")
                        {
                            Principal menu = new Principal();
                            menu.Show();
                        }
                        else
                        {
                            MessageBox.Show("No se encontro ese usuario");
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
                    }
                    mysql.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //Metodo para obtener el nombre de usuario en base al nombre colocado en el textbox
            public string accesoRol(string name,Label user) //Necesito poner un string en el otro form???
            {
                if (string.IsNullOrEmpty(name)) //Si esta vacio entonces vamos a decirr que el texto va ser ese string vacio
                {
                    user.Text = name;
                }
                else //Al contrario damos lo mismo
                {
                    user.Text = name;
                }
                //Retornamos el nombre
                return name;
            }
        }
        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (tbUserPassword.UseSystemPasswordChar==true && cbPassword.Checked == true)
            {
                tbUserPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbUserPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
