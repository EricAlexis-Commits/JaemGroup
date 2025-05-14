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
    public partial class registrarEntrenador : Form
    {
        public registrarEntrenador()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        MySqlConnection mysql;
        MySqlCommand comm;
        MySqlDataReader adapt;

        private void registrarEntrenador_Load(object sender, EventArgs e)
        {
            try
            {
                mysql = new MySqlConnection("server = 127.0.0.1; user = root; database = gimnasios; password =;");
                mysql.Open();
                comm = new MySqlCommand("SELECT * FROM usuario");
                adapt = comm.ExecuteReader();
                while (adapt.Read())
                {
                    cbUsuarios.Items.Add(adapt["Nombre"]);
                }
                mysql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen |*.jpg;*.png;*.jpeg;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbCertificado.ImageLocation = dialog.FileName;
            }
            pbCertificado.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
