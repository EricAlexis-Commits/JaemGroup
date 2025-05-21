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
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
        }
        static string conexion = "server=127.0.0.1; user=root; database=gimnasios; password=;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        string iDentificador;
        float dineroPagar;
        private void Pagos_Load(object sender, EventArgs e)
        {

            lblUsuario.Text = Sension.usuarioActual;
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
            try
            {
                mysql.Open();
                //Obtener el identificador maximo para incrementar y usar ese mismo que sigue
                MySqlCommand queryID = new MySqlCommand("SELECT MAX(ID_Pagos)FROM pagos",mysql);
                //int maximo = Convert.ToInt32(queryID);
                //Consulta que llenara el comboBox de Clientes
                MySqlCommand clientes = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCliente FROM cliente JOIN persona ON cliente.Persona_ID=persona.ID_Persona",mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(clientes);
                DataTable dataTable= new DataTable();
                adapter.Fill(dataTable);
                cbClientes.DataSource = dataTable;
                cbClientes.ValueMember = "ID_Cliente";
                cbClientes.DisplayMember = "NombreCliente";
                //Consulta que llenara el comboBox de Membresia
                MySqlCommand membresias = new MySqlCommand("SELECT ID_Membresia,concat");
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                mysql.Close();
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetodo.SelectedItem)
            {
                case "Efectivo":

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ciclo foreach para agregar los elementos al datagridview
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //En base a la seleccion del comboBox de metodo de pago va tener diferentes procesos de pago
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Accion que elimina los datos del datagridview que se desea

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cbTipoMembresia.SelectedItem)
            {
                case "Visita":
                    dineroPagar= 50;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Semanal":
                    dineroPagar = 145;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Mensual":
                    dineroPagar= 500;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Quincenal":
                    dineroPagar = 300;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Semestral":
                    dineroPagar = 2500;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Mensual Estudiante":
                    dineroPagar = 230;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Semestral Estudiante":
                    dineroPagar = 2000;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                default:
                    dineroPagar = 0;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
