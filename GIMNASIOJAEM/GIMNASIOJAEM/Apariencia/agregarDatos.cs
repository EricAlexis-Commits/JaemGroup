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
    public partial class agregarDatos : Form
    {
        public agregarDatos()
        {
            InitializeComponent();
        }
        static string conexionSQL= "server = 127.0.0.1; user=root; database=gimnasio; password=";
        MySqlConnection conexion = new MySqlConnection(conexionSQL);
        //Metodo para insertar datos dentro del boton
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Si cada uno de estos es diferente a vacio se entra al try
            if (tbID.Text!="" && tbNombre.Text != "" && tbApellidoP.Text != "" && tbApellidoM.Text != "" && dtpFechaNacimiento.Text != "" && tbPeso.Text != "" && tbEstatura.Text != "")
            {
                //Manejo de errores en caso de problemas a la hora de insertar datos en la DB
                try
                {
                    //Declaramos un objeto tipo Datetime convertirmos el valor de la fecha a un string
                    //Con formato de dd-mm-yyyy
                    DateTime mifecha = Convert.ToDateTime(dtpFechaNacimiento.Value.Date.ToString("dd-MM-yyyy"));
                    conexion.Open();
                    MySqlCommand queryInsert = new MySqlCommand($"INSERT INTO persona(ID_Persona,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento,Peso,Estatura)" +
                        $"VALUES(@id,@nombre,@apellidoP,@apellidoM,@fechaN,@peso,@estatura)",conexion);
                    queryInsert.Parameters.AddWithValue("@id",tbID.Text);
                    queryInsert.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    queryInsert.Parameters.AddWithValue("@apellidoP", tbApellidoP.Text);
                    queryInsert.Parameters.AddWithValue("@apellidoM", tbApellidoM.Text);
                    queryInsert.Parameters.AddWithValue("@fechaN",mifecha);
                    //queryInsert.Parameters.AddWithValue("@fechaN", SqlDbType.Date).Value=dtpFechaNacimiento.Value.Date;
                    queryInsert.Parameters.AddWithValue("@peso", tbPeso.Text);
                    queryInsert.Parameters.AddWithValue("@estatura", tbEstatura.Text);
                    queryInsert.ExecuteNonQuery();
                    conexion.Close();
                    
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
                MessageBox.Show("Campos vacios");
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tbID.Text != "" && tbNombre.Text != "" && tbApellidoP.Text != "" && tbApellidoM.Text != "" && dtpFechaNacimiento.Text != "" && tbPeso.Text != "" && tbEstatura.Text != "")
            {
                try
                {
                    DateTime mifecha = Convert.ToDateTime(dtpFechaNacimiento.Value.Date.ToString("dd-MM-yyyy"));
                    conexion.Open();
                    MySqlCommand edit = new MySqlCommand("UPDATE persona SET Nombre=@name,Apellido_Paterno=@apellidoP,Apellido_Materno=@apellidoM," +
                        "Fecha_Nacimiento=@fechaN,Peso=@peso,Estatura=@estatura WHERE ID_Persona=@id",conexion);
                    edit.Parameters.AddWithValue("@id",tbID.Text);
                    edit.Parameters.AddWithValue("@name", tbNombre.Text);
                    edit.Parameters.AddWithValue("@apellidoP", tbApellidoP.Text);
                    edit.Parameters.AddWithValue("@apellidoM",tbApellidoM.Text);
                    edit.Parameters.AddWithValue("@fechaN", mifecha);
                    edit.Parameters.AddWithValue("@peso", tbPeso.Text);
                    edit.Parameters.AddWithValue("@estatura", tbEstatura.Text);
                    edit.ExecuteNonQuery();
                    conexion.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    this.Close();
                    Personas persona = new Personas();
                    persona.Invalidate();
                    persona.Update();
                }
            }
        }
    }
}
