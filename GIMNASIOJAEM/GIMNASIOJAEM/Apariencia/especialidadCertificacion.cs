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
    public partial class especialidadCertificacion : Form
    {
        static string conexion = "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        public especialidadCertificacion()
        {
            InitializeComponent();
        }
        string rutaFinal = "";
        string especialidad = "";
        bool datosCargados = false;
        private void especialidadCertificacion_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                conn.Open();
                MySqlCommand query = new MySqlCommand("SELECT ID_Entrenador,concat(entrenador.Nombre,' ',entrenador.Apellido_Paterno)AS NombreEntrenador FROM entrenador",conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter(query);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                cbEntrenador.DataSource = dt;
                cbEntrenador.ValueMember = "ID_Entrenador";
                cbEntrenador.DisplayMember = "NombreEntrenador";
                datosCargados = true;
            }
        }
        private void cbEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!datosCargados)
            {
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open();
                    MySqlCommand queryEntrenador = new MySqlCommand("SELECT Especialidad,Certificacion FROM entrenador WHERE ID_Entrenador=@id", conn);
                    queryEntrenador.Parameters.AddWithValue("@id", cbEntrenador.SelectedValue);
                    using (MySqlDataReader read = queryEntrenador.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            especialidad = read["Especialidad"].ToString();
                            rutaFinal = read["Certificacion"].ToString();
                            tbEspecialidad.Text = especialidad;
                            if (string.IsNullOrEmpty(especialidad) || !File.Exists(rutaFinal))
                            {
                                pbCertificado.Image = Image.FromFile(@"D:\Imágenes\imagenNoCargada.jpg");

                            }
                            else
                            {
                                pbCertificado.Image = Image.FromFile(rutaFinal);
                            }
                            pbCertificado.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                pbCertificado.Image = Image.FromFile(@"D:\Imágenes\imagenNoCargada.jpg");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
