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

namespace GIMNASIOJAEM.Apariencia
{
    public partial class eliminarDatos : Form
    {
        public eliminarDatos()
        {
            InitializeComponent();
        }
        static string sql = "server=127.0.0.1; user=root; database=gimnasio; password=;";
        static MySqlConnection con = new MySqlConnection(sql);
        SQL datos = new SQL(con);
        private void eliminarDatos_Load(object sender, EventArgs e)
        {
            datos.fillDVG("persona",dgvPersonas);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand queryDelete = new MySqlCommand($"DELETE FROM persona WHERE ID_Persona=@id", con);
                queryDelete.Parameters.AddWithValue("@id", tbID.Text);
                queryDelete.ExecuteNonQuery();
                con.Close();
                eliminarDatos delete = new eliminarDatos();
                delete.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }
    }
}
