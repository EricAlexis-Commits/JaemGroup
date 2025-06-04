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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            registroCliente registro = new registroCliente();
            registro.ShowDialog();
            refreshDGV();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            mysql.Open();
            MySqlCommand query = new MySqlCommand("SELECT Persona_ID,Clave_Cliente,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,cliente.Objetivos,cliente.Nivel_Experiencia FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID",mysql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvClientes.DataSource = dt;
            mysql.Close();

        }

        private void btnObjetivos_Click(object sender, EventArgs e)
        {
            objetivo objetivos = new objetivo();
            objetivos.ShowDialog();
            refreshDGV();
        }

        private void btnRutinas_Click(object sender, EventArgs e)
        {
            rutinasPersonalizadas rutinas = new rutinasPersonalizadas();
            rutinas.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            mysql.Open();
            using (MySqlCommand pagosJoin = new MySqlCommand("SELECT `Clave_Cliente`,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,pagos.Fecha_Pago,pagos.Monto,pagos.Tipo_Pago,pagos.Estatus_Pago,pagos.Concepto FROM\r\ncliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID LEFT JOIN pagos ON pagos.Cliente_ID=cliente.ID_Cliente",mysql))
            {
                MySqlDataAdapter adapterPagos = new MySqlDataAdapter(pagosJoin);
                DataTable dataTable = new DataTable();
                adapterPagos.Fill(dataTable);
                dgvClientes.DataSource=dataTable;
            }
            mysql.Close();
        }

        private void butto_Click(object sender, EventArgs e)
        {
            mysql.Open();
            using (MySqlCommand join = new MySqlCommand("SELECT `Clave_Cliente`,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,asistencia.Fecha_Asistencia,asistencia.Horario_Asistencia FROM cliente JOIN persona ON persona.ID_Persona=Persona_ID LEFT JOIN asistencia ON asistencia.Cliente_ID=cliente.ID_Cliente", mysql))

            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(join);
                DataTable datosJoin = new DataTable();
                mySqlDataAdapter.Fill(datosJoin);
                dgvClientes.DataSource = datosJoin;
            }
            mysql.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void refreshDGV()
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand refresh=new MySqlCommand("SELECT Persona_ID,Clave_Cliente,persona.Nombre,persona.Apellido_Paterno,persona.Apellido_Materno,cliente.Objetivos,cliente.Nivel_Experiencia FROM cliente JOIN persona ON persona.ID_Persona=cliente.Persona_ID", mysql))
                {
                    MySqlDataAdapter adapterRefresh = new MySqlDataAdapter(refresh);
                    DataTable datosRefresh = new DataTable();
                    adapterRefresh.Fill(datosRefresh);
                    dgvClientes.DataSource = datosRefresh;
                }
            }
        }
    }
}
