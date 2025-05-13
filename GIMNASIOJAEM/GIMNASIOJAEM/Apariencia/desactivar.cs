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
    public partial class desactivar : Form
    {
        public desactivar()
        {
            InitializeComponent();
        }
        static string conexion ="server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conn = new MySqlConnection(conexion);
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) && string.IsNullOrEmpty(cbState.SelectedItem.ToString()))
            {
                MessageBox.Show("Seleccione una opcion y agregue informacion");
            }
            else
            {
                try { 
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE usuario SET Estado=@state WHERE Nombre_Usuario=@name",conn);
                        cmd.Parameters.AddWithValue("@state", cbState.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@name", tbName.Text);
                        int filasAfectadas=cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Datos actualizados");
                    }
                    else
                    {
                        MessageBox.Show("No se encontro al usuario");
                    }
                         
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    
                }
               
            }
            this.Close();
        }
    }
}
