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
    public partial class rutinasPersonalizadas : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";

        public rutinasPersonalizadas()
        {
            InitializeComponent();
        }

        private void historialPagosClientes_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)" +
                    "AS NombreCliente FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql);
                MySqlDataAdapter adapt = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                cbClientes.DataSource = dt;
                cbClientes.ValueMember = "ID_Cliente";
                cbClientes.DisplayMember = "NombreCliente";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedValue.ToString()!="")
            {
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(conexion))
                    {
                        MySqlCommand query = new MySqlCommand("SELECT `Clave_Cliente`,persona.Nombre,persona.Apellido_Paterno,rutina.Nombre_Rutina,rutina.Objetivo FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID LEFT JOIN rutina ON rutina.Cliente_ID=cliente.ID_Cliente WHERE cliente.ID_Cliente=@id", mysql);
                        query.Parameters.AddWithValue("@id", cbClientes.SelectedValue);
                        MySqlDataAdapter adapterNew = new MySqlDataAdapter(query);
                        DataTable dataTable = new DataTable();
                        adapterNew.Fill(dataTable);
                        dgvClientes.DataSource = dataTable;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente");
            }
            
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
