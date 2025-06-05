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
        static string sql = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        static MySqlConnection con = new MySqlConnection(sql);
        SQL datos = new SQL(con);
        private void eliminarDatos_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(sql))
            {
                mysql.Open();
                using (MySqlCommand loadPersonas=new MySqlCommand("SELECT ID_Persona,concat(Nombre,' ',Apellido_Paterno,' ',Apellido_Materno)AS NombredePersona FROM persona",mysql))
                {
                    MySqlDataAdapter adapt = new MySqlDataAdapter(loadPersonas);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    cbClientes.DataSource = dt;
                    cbClientes.ValueMember = "ID_Persona";
                    cbClientes.DisplayMember = "NombredePersona";
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedIndex <= 0 || cbClientes.SelectedItem.ToString()=="")
            {
                MessageBox.Show("Seleccione una persona a eliminar");
            }
            else
            {
                try
                {
                    con.Open();
                    MySqlCommand queryDelete = new MySqlCommand("DELETE FROM persona WHERE ID_Persona=@id", con);
                    queryDelete.Parameters.AddWithValue("@id", cbClientes.SelectedValue);
                    queryDelete.ExecuteNonQuery();
                    con.Close();
                    eliminarDatos delete = new eliminarDatos();
                    delete.Close();
                }
                catch (Exception ex)
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
}
