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
    public partial class asignarClase : Form
    {
        public asignarClase()
        {
            InitializeComponent();
        }
        static string conexion = "server = 127.0.0.1; user = root; database = gimnasios; password =;";
        MySqlConnection mysql = new MySqlConnection(conexion);
        int cantidaddePersonas;
        int capacidadMaximadeClientes;
        string fechaHoy = DateTime.Now.ToString("yyyy:MM:dd");
        private void asignarClase_Load(object sender, EventArgs e)
        {
            try
            {
                
                //Llena el comboBox con una consulta de las clases disponibles, seleccionado su ID y mostrandolo como nombre y tipo de clase
                mysql.Open();
                MySqlCommand query = new MySqlCommand("SELECT ID_Clase,concat(Nombre_Clase,' ',Tipo_Clase)AS NombredeClase FROM clase",mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbClases.DataSource = dt;
                cbClases.ValueMember = "ID_Clase";
                cbClases.DisplayMember = "NombredeClase";
                mysql.Close();
                //Llenar el otro comboBox de Clientes para asignar clase dentro de la tabla clase
                //Se prefiere usar consulta JOIN de clientes y persona
                mysql.Open();
                query = new MySqlCommand("SELECT ID_Cliente,concat(persona.Nombre,' ',persona.Apellido_Paterno)AS NombreCompleto FROM cliente JOIN persona on persona.ID_Persona=cliente.Persona_ID",mysql);
                adapter = new MySqlDataAdapter(query);
                dt = new DataTable();
                adapter.Fill(dt);
                cbClientes.DataSource = dt;
                cbClientes.ValueMember = "ID_Cliente";
                cbClientes.DisplayMember = "NombreCompleto";
                mysql.Close();
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                int idClase = Convert.ToInt32(cbClases.SelectedValue);
                int idCliente = Convert.ToInt32(cbClientes.SelectedValue);
                mysql.Open();
                using (MySqlCommand comando = new MySqlCommand("SELECT COUNT(*)FROM clase_cliente WHERE Clase_ID=@idClase", mysql))
                {

                    comando.Parameters.AddWithValue("@idClase", idClase);
                    cantidaddePersonas = Convert.ToInt32(comando.ExecuteScalar());
                }
                using (MySqlCommand capacidadMaxima = new MySqlCommand("SELECT Capacidad_Maxima FROM clase WHERE ID_Clase=@idClase", mysql))
                {
                    capacidadMaxima.Parameters.AddWithValue("@idClase", idClase);
                    capacidadMaximadeClientes = Convert.ToInt32(capacidadMaxima.ExecuteScalar());

                }

                if (cantidaddePersonas >= capacidadMaximadeClientes)
                {
                    MessageBox.Show("La clase que estas intentado asignar esta llena, asigne otra");
                    using (MySqlCommand cambioEstadoClase = new MySqlCommand("UPDATE clase SET Vacante='No Disponible' WHERE ID_Clase=@idClase",mysql))
                    {
                        cambioEstadoClase.Parameters.AddWithValue("@idClase",idClase);
                        cambioEstadoClase.ExecuteNonQuery();
                    }
                        mysql.Close();
                    return;
                }
                else
                {

                    using (MySqlCommand asignarclienteaClase = new MySqlCommand("INSERT INTO clase_cliente(Clase_ID,Cliente_ID,Fecha_Asignacion)" +
                        "VALUES(@clase,@cliente,@fecha)", mysql))
                    {
                        asignarclienteaClase.Parameters.AddWithValue("@clase", idClase);
                        asignarclienteaClase.Parameters.AddWithValue("@cliente", idCliente);
                        asignarclienteaClase.Parameters.AddWithValue("@fecha", fechaHoy);
                        asignarclienteaClase.ExecuteNonQuery();
                    }
                }
                mysql.Close();
                MessageBox.Show("Cliente asignado a clase correctamente");
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
