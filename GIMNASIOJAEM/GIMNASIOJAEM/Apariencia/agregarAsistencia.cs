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
    public partial class agregarAsistencia : Form
    {
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        string fecha = DateTime.Now.ToString("dd:MM:yyyy");
        string hora = DateTime.Now.ToString("hh:MM:ss");
        public agregarAsistencia()
        {
            InitializeComponent();
        }

        private void agregarAsistencia_Load(object sender, EventArgs e)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand llenarClientes=new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno,' ',persona.Apellido_Materno)AS NombredeCliente FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql))
                {
                    MySqlDataAdapter adapt = new MySqlDataAdapter(llenarClientes);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    cbCliente.DataSource = dt;
                    cbCliente.ValueMember = "ID_Cliente";
                    cbCliente.DisplayMember = "NombredeCliente";
                }
            }
        }

        private void btnAgregarAsistencia_Click(object sender, EventArgs e)
        {
            if (dtpFechaAsistencia.Value.Date <= DateTime.Now.Date)
            {
                DateTime fechadeHoy = Convert.ToDateTime(dtpFechaAsistencia.Value.Date.ToString("dd/MM/yyyy"));
                DateTime horadeHoy = Convert.ToDateTime(dtpHoraAsistencia.Value.Date.ToString("hh:MM:ss"));
                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(conexion))
                    {
                        mysql.Open();
                        using (MySqlCommand agregar=new MySqlCommand("INSERT INTO asistencia(Cliente_ID,Fecha_Asistencia,Horario_Asistencia)" +
                            "VALUES(@clienteID,@fechaAsistencia,@horarioAsistencia)",mysql))
                        {
                            agregar.Parameters.AddWithValue("@clienteID",cbCliente.SelectedValue);
                            agregar.Parameters.AddWithValue("@fechaAsistencia",fechadeHoy);
                            agregar.Parameters.AddWithValue("@horarioAsistencia",horadeHoy);
                            agregar.ExecuteNonQuery();
                        }
                    }
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
            else
            {
                MessageBox.Show("Selecciona una fecha no mayor a hoy");
            }
        }
    }
}
