using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIMNASIOJAEM.Apariencia
{
    public partial class registrarEntrenador : Form
    {
        public registrarEntrenador()
        {
            InitializeComponent();
        }
        string rutaFinal = "";
        MySqlConnection mysql = new MySqlConnection("server = 127.0.0.1; user = root; database = gimnasios; password =;");
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void registrarEntrenador_Load(object sender, EventArgs e)
        {
            try
            {   
                mysql.Open();
                MySqlCommand comm = new MySqlCommand("SELECT ID_Usuario,concat(Nombre_Usuario,' ',Tipo_Usuario)AS NombredeUsuario FROM usuario WHERE Tipo_Usuario='Entrenador'",mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbUsuarios.DataSource = dt;
                cbUsuarios.ValueMember = "ID_Usuario";
                cbUsuarios.DisplayMember = "NombredeUsuario";
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Validacion de campos aqui 
                mysql.Open();
                MySqlCommand insert = new MySqlCommand("INSERT INTO entrenador(Usuario_ID,Nombre_Entrenador,Apellido_Paterno,Apellido_Materno,Especialidad,Certificacion)" +
                    "VALUES(@usuario,@nombre,@apellidoP,@apellidoM,@especialidad,@certificado)", mysql);
                insert.Parameters.AddWithValue("@usuario", cbUsuarios.SelectedValue);
                insert.Parameters.AddWithValue("@nombre", tbNombre.Text);
                insert.Parameters.AddWithValue("@apellidoP", tbPaterno.Text);
                insert.Parameters.AddWithValue("@apellidoM", tbMaterno.Text);
                insert.Parameters.AddWithValue("@especialidad", cbEspecialidad.SelectedItem);
                insert.Parameters.AddWithValue("@certificado", rutaFinal);
                insert.ExecuteNonQuery();
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
        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen |*.jpg;*.png;*.jpeg;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = Path.GetFileName(dialog.FileName);
                string carpetaDestino = @"D:\Imágenes\Clientes";
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);

                }
                rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);
                File.Copy(dialog.FileName,rutaFinal,true);
                pbCertificado.ImageLocation = dialog.FileName;
            }
            pbCertificado.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
