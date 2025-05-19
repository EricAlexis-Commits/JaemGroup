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
    public partial class Inicio : Form
    {
        static string conn= "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection conexion=new MySqlConnection(conn);
        MySqlCommand query;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                int cantidadClientes = 0;
                int cantidadEntrenadores = 0;
                int cantidadClases = 0;
                int cantidadMembresias = 0;
                conexion.Open();
                cantidadClientes = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*)FROM cliente", conexion).ExecuteScalar());
                cantidadEntrenadores = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*)FROM entrenador", conexion).ExecuteScalar());
                cantidadClases = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*)FROM clase WHERE Estado_Clase='Activa'", conexion).ExecuteScalar());
                cantidadMembresias = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*)FROM membresia WHERE Estatus_Membresia='Activa'", conexion).ExecuteScalar());
                conexion.Close();
                lblClientes.Text = cantidadClientes.ToString();
                lblClases.Text = cantidadClases.ToString();
                lblEntrenadores.Text = cantidadEntrenadores.ToString();
                lblMembresias.Text = cantidadMembresias.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           




        }
    }
}
