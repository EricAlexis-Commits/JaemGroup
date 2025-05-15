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
    public partial class registroCliente : Form
    {
        public registroCliente()
        {
            InitializeComponent();
        }
        static string conexionSQL = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mySql = new MySqlConnection(conexionSQL);
        private void registroCliente_Load(object sender, EventArgs e)
        {
            try
            {
                mySql.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ID_Persona,concat(Nombre,' ',Apellido_Paterno,' ',Apellido_Materno) AS Nombre FROM persona",mySql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbPersonasID.DataSource = dt;
                cbPersonasID.ValueMember = "ID_Persona";
                cbPersonasID.DisplayMember = "Nombre";
                mySql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void cbPersonasID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                mySql.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO cliente(Persona_ID,Clave_Cliente)VALUES (@personaID,@Clave)",mySql);
                cmd.Parameters.AddWithValue("@personaID",cbPersonasID.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Clave",tbClave.Text);
                cmd.ExecuteNonQuery();
                mySql.Close();
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
    }
}
