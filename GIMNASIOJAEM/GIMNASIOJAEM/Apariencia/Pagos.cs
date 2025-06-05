using GIMNASIOJAEM.Codificacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        DateTime fechaHoy = DateTime.Now;
        List<pagosDatos> pagosdeDatos;
        private void Pagos_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            lblUsuario.Text = Sension.usuarioActual;
            
            try
            {
                mysql.Open();
                //Obtener el identificador maximo para incrementar y usar ese mismo que sigue
                MySqlCommand queryID = new MySqlCommand("SELECT MAX(ID_Pagos)FROM pagos",mysql);
                //int maximo = Convert.ToInt32(queryID.ExecuteScalar());
                //Consulta que llenara el comboBox de Clientes
                MySqlCommand clientes = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCliente FROM cliente JOIN persona ON cliente.Persona_ID=persona.ID_Persona",mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(clientes);
                DataTable dataTable= new DataTable();
                adapter.Fill(dataTable);
                cbClientes.DataSource = dataTable;
                cbClientes.ValueMember = "ID_Cliente";
                cbClientes.DisplayMember = "NombreCliente";
               
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
            mysql.Open();
            //Ciclo foreach para agregar los elementos al datagridview
            pagosdeDatos = new List<pagosDatos>();
            string consulta = "SELECT ID_Usuario FROM usuario WHERE Nombre_Usuario=@name";
            MySqlCommand comando = new MySqlCommand(consulta,mysql);
            comando.Parameters.AddWithValue("@name",lblUsuario.Text);
            int idUsuario = 0;

            MySqlDataReader read = comando.ExecuteReader();
            if (read.Read())
            {
                idUsuario = read.GetInt32("ID_Usuario");
            }
            read.Close();
            try
            {


                pagosDatos datos = new pagosDatos
                {
                    clienteID = Convert.ToInt32(cbClientes.SelectedValue),

                    membresiaID = Convert.ToInt32(cbMembresia.SelectedItem),

                    usuarioID = idUsuario,

                    fechaPago = fechaHoy.Date,


                    monto = float.Parse(lblPagar.Text),

                    tipoPago = cbTipoMembresia.SelectedItem.ToString(),

                    estatusPago = "Pendiente",

                    Concepto = tbConcepto.Text

                }; //La cadena de entrada no tiene el formato correcto
                pagosdeDatos.Add(datos);
                dgvPagos.DataSource = null;
                dgvPagos.Rows.Add(
                    datos.clienteID,
                     datos.membresiaID,
                     datos.usuarioID,
                     datos.fechaPago,
                     datos.monto,
                     datos.tipoPago,
                    datos.estatusPago,
                    datos.Concepto
                    );
                mysql.Close();
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Error de formato en los datos" + ex.ToString());
            }
        }
        private void pagoEfectivo(pagosDatos datospagos)
        {
            
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand cargar=new MySqlCommand("INSERT INTO pagos(Cliente_ID,Membresia_ID,Usuario_ID,Fecha_Pago,Monto,Tipo_Pago,Estatus_Pago,Concepto) " +
                    "VALUES(@clienteID,@membresiaID,@usuarioID,@fechaPago,@monto,@tipoPago,@estatusPago,@conceptoPago)",mysql))
                {
                    cargar.Parameters.AddWithValue("@clienteID",datospagos.clienteID);
                    cargar.Parameters.AddWithValue("@membresiaID",datospagos.membresiaID);
                    cargar.Parameters.AddWithValue("@usuarioID", datospagos.usuarioID);
                    cargar.Parameters.AddWithValue("@fechaPago", datospagos.fechaPago);
                    cargar.Parameters.AddWithValue("@monto", datospagos.monto);
                    cargar.Parameters.AddWithValue("@tipoPago", datospagos.tipoPago);
                    cargar.Parameters.AddWithValue("@estatusPago", datospagos.estatusPago);
                    cargar.Parameters.AddWithValue("@conceptoPago", datospagos.Concepto);
                    cargar.ExecuteNonQuery();

                }
            }
        }
        private void pagoTarjeta(pagosDatos datospagos)
        {
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand cargar=new MySqlCommand("INSERT INTO pagos(Cliente_ID,Membresia_ID,Usuario_ID,Fecha_Pago,Monto,Tipo_Pago,Estatus_Pago,Concepto) " +
                    "VALUES(@clienteID,@membresiaID,@usuarioID,@fechaPago,@monto,@tipoPago,@estatusPago,@conceptoPago)", mysql))
                {
                    cargar.Parameters.AddWithValue("@clienteID", datospagos.clienteID);
                    cargar.Parameters.AddWithValue("@membresiaID", datospagos.membresiaID);
                    cargar.Parameters.AddWithValue("@usuarioID", datospagos.usuarioID);
                    cargar.Parameters.AddWithValue("@fechaPago", datospagos.fechaPago);
                    cargar.Parameters.AddWithValue("@monto", datospagos.monto);
                    cargar.Parameters.AddWithValue("@tipoPago", datospagos.tipoPago);
                    cargar.Parameters.AddWithValue("@estatusPago", datospagos.estatusPago);
                    cargar.Parameters.AddWithValue("@conceptoPago", datospagos.Concepto);
                    cargar.ExecuteNonQuery();
                }
            }
        }
        private void pagoTransferencia(pagosDatos datospagos)
        {
            using (MySqlConnection mysql = new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand cargar = new MySqlCommand("INSERT INTO pagos(Cliente_ID,Membresia_ID,Usuario_ID,Fecha_Pago,Monto,Tipo_Pago,Estatus_Pago,Concepto) " +
                    "VALUES(@clienteID,@membresiaID,@usuarioID,@fechaPago,@monto,@tipoPago,@estatusPago,@conceptoPago)", mysql))
                {
                    cargar.Parameters.AddWithValue("@clienteID", datospagos.clienteID);
                    cargar.Parameters.AddWithValue("@membresiaID", datospagos.membresiaID);
                    cargar.Parameters.AddWithValue("@usuarioID", datospagos.usuarioID);
                    cargar.Parameters.AddWithValue("@fechaPago", datospagos.fechaPago);
                    cargar.Parameters.AddWithValue("@monto", datospagos.monto);
                    cargar.Parameters.AddWithValue("@tipoPago", datospagos.tipoPago);
                    cargar.Parameters.AddWithValue("@estatusPago", datospagos.estatusPago);
                    cargar.Parameters.AddWithValue("@conceptoPago", datospagos.Concepto);
                    cargar.ExecuteNonQuery();
                }
            }
        }
        private async void btnPagar_Click(object sender, EventArgs e)
        {
            if (pagosdeDatos == null || pagosdeDatos.Count < 1)
            {
                MessageBox.Show("No has agregado ningun dato");
                return;
            }
            loading cargar = new loading();
            Task showLoading = Task.Run(() => cargar.ShowDialog());
            
                
                await Task.Delay(20000);
            
                //En base a la seleccion del comboBox de metodo de pago va tener diferentes procesos de pago
            switch (cbMetodo.SelectedItem?.ToString())
            {
                case "Efectivo":
                    foreach (var pago in pagosdeDatos)
                    {
                        pago.estatusPago = "Pagado";
                        pagoEfectivo(pago);

                    }
                    MessageBox.Show("Pago efectivo realizado");
                    dgvPagos.Rows.Clear();
                    actualizarEstadoMembresia();
                    break;
                case "Tarjeta":

                    foreach (var pago in pagosdeDatos)
                    {
                        pago.estatusPago = "Pagado";
                        pagoTarjeta(pago);
                    }
                    MessageBox.Show("Pago por tarjeta realizado");
                    actualizarEstadoMembresia();
                    dgvPagos.Rows.Clear();
                    break;

                case "Transferencia":
                    foreach (var pago in pagosdeDatos)
                    {
                        pago.estatusPago = "Pagado";
                        pagoTransferencia(pago);
                    }
                    MessageBox.Show("Pago por transferencia realizado");
                    actualizarEstadoMembresia();
                    dgvPagos.Rows.Clear();
                    break;
                default:
                break;
            }
            if (cargar.InvokeRequired)
            {
                cargar.Invoke(new Action(() => cargar.Close()));
            }
            else
            {
                cargar.Close();
            }
        }
            
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Accion que elimina los datos del datagridview que se desea
            dgvPagos.Rows.Clear();

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
                case "Mensual Es":
                    dineroPagar = 230;
                    lblPagar.Text = dineroPagar.ToString();
                    break;
                case "Semestral Es":
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
        private void actualizarEstadoMembresia()
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(conexion))
                {
                    mysql.Open();
                    using (MySqlCommand actualizarEstado = new MySqlCommand("UPDATE membresia SET Estatus_Membresia='Activa'WHERE ID_Membresia=@idMembresia", mysql))
                    {
                        actualizarEstado.Parameters.AddWithValue("@idMembresia", cbMembresia.SelectedItem);
                        actualizarEstado.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientes.SelectedValue == null)
            {
                return;
            }
            int membresiaId;
            string resultadosTipo;
            using (MySqlConnection mysql=new MySqlConnection(conexion))
            {
                mysql.Open();
                using (MySqlCommand select=new MySqlCommand("SELECT ID_Membresia FROM membresia WHERE Cliente_ID=@clienteID",mysql))
                {
                    select.Parameters.AddWithValue("@clienteID",cbClientes.SelectedValue);
                    object resultado= select.ExecuteScalar();
                    if (resultado != null)
                    {
                        membresiaId = Convert.ToInt32(resultado);
                        cbMembresia.Items.Clear();
                        cbMembresia.Items.Add(membresiaId);
                        cbMembresia.SelectedIndex = 0;
                    }
                    else
                    {
                        cbMembresia.Items.Clear();
                    }

                }
                using (MySqlCommand tipoMembresia=new MySqlCommand("SELECT Tipo_Membresia FROM membresia WHERE Cliente_ID=@clienteiD",mysql))
                {
                    tipoMembresia.Parameters.AddWithValue("@clienteID",cbClientes.SelectedValue);
                    object results = tipoMembresia.ExecuteScalar();
                    if (results != null)
                    {
                        resultadosTipo = Convert.ToString(results);
                        cbTipoMembresia.Items.Clear();
                        cbTipoMembresia.Items.Add(resultadosTipo);
                        cbTipoMembresia.SelectedIndex = 0;
                    }
                    else
                    {
                        cbTipoMembresia.Items.Clear();
                    }
                }
            }
        }
    }
}
