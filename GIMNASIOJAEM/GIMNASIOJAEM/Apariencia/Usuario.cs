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
        public Usuario()
        {
            InitializeComponent();
        }
        static string conn = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conexion = new MySqlConnection(conn);
        
        private void button5_Click(object sender, EventArgs e)
        {
            crearUsuario usuarioNuevo = new crearUsuario();
            usuarioNuevo.ShowDialog();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

            SQL mysql = new SQL(conexion);
            mysql.fillDVG("usuario",dgvUsuarios);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            crearUsuario usuarioNuevo = new crearUsuario();
            usuarioNuevo.ShowDialog();
            usuarioNuevo.boton.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            desactivar inhabilitar = new desactivar();
            inhabilitar.ShowDialog();
        }
    }
}
