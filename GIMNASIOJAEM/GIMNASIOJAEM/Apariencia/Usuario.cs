using GIMNASIOJAEM.Codificacion;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class Usuario : Form
    {
        public bool editar { get; set; } = false;
        
        public Usuario()
        {
            InitializeComponent();
        }
        static string conn = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conexion = new MySqlConnection(conn);
        
        private void button5_Click(object sender, EventArgs e)
        {
            crearUsuario usuarioNuevo = new crearUsuario();
            editar = false;
            usuarioNuevo.ShowDialog();
            refreshDGV();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            if (Sension.permisoUsuario == "Administrador")
            {
                btnVerContraseñas.Enabled = true;
                btnDesactivar.Enabled = true;
                
            }
            else
            {
                btnVerContraseñas.Enabled = false;
                btnDesactivar.Enabled = false;
                btnVerContraseñas.BackColor = Color.Red;
                btnDesactivar.BackColor = Color.Red;
               
            }
                conexion.Open();
            using (MySqlCommand usuario=new MySqlCommand("SELECT Clave_Usuario,Nombre_Usuario,Tipo_Usuario,Fecha_Registro,Estado FROM usuario",conexion))
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter(usuario);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dgvUsuarios.DataSource = dt;
            }
            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crearUsuario usuarioNuevo = new crearUsuario();
            editar = true;
            usuarioNuevo.ShowDialog();
            refreshDGV();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            desactivar inhabilitar = new desactivar();
            inhabilitar.ShowDialog();
            refreshDGV();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql=new MySqlConnection(conn))
            {
                mysql.Open();
                using (MySqlCommand refresh=new MySqlCommand("SELECT Clave_Usuario,Nombre_Usuario,Tipo_Usuario,Fecha_Registro,Estado FROM usuario",mysql))
                {
                    MySqlDataAdapter adaptRefresh = new MySqlDataAdapter(refresh);
                    DataTable dt = new DataTable();
                    adaptRefresh.Fill(dt);
                    dgvUsuarios.DataSource = dt;
                }
            }
        }

        private void btnVerContraseñas_Click(object sender, EventArgs e)
        {
            verContraseña verPassword = new verContraseña();
            verPassword.ShowDialog();
        }
    }
}
