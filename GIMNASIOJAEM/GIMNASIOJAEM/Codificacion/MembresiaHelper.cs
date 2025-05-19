using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIMNASIOJAEM.Codificacion
{
    public static class MembresiaHelper
    {
        static string conexion = "server = 127.0.0.1; user=root; database=gimnasios; password=;";
        //Metodo que cambia el campo de Estado_Membresia una vez cargado el Form Principal
        //Se coloco el metodo en una clase estatica unicamente para ser utilizada sin necesidad de crear un objeto

        public static void actualizarEstadosMembresia()
        {
            using (MySqlConnection mysql = new MySqlConnection(conexion))
            {
                mysql.Open();
                // 1. Obtener todas las membresías con fecha de vencimiento
                MySqlCommand cmd = new MySqlCommand("SELECT ID_Membresia,Fecha_Vencimiento FROM membresia", mysql);
                MySqlDataReader dr = cmd.ExecuteReader();
                List<(int id, DateTime vencimiento)> membresias = new List<(int, DateTime)>();
                while (dr.Read())
                {
                    int id = dr.GetInt32("ID_Membresia");
                    DateTime vencimiento = dr.GetDateTime("Fecha_Vencimiento");
                    membresias.Add((id, vencimiento));

                }
                dr.Close();
                // 2. Evaluar y actualizar estado
                foreach (var m in membresias)
                {
                    string nuevoEstado = m.vencimiento < DateTime.Now ? "Inactiva" : "Activa";
                    MySqlCommand actualizar = new MySqlCommand("UPDATE membresia SET Estatus_Membresia=@estado WHERE ID_Membresia=@id", mysql);
                    actualizar.Parameters.AddWithValue("@estado", nuevoEstado);
                    actualizar.Parameters.AddWithValue("@id", m.id);
                    actualizar.ExecuteNonQuery();
                }
                mysql.Close();
            }
        }
    }
}
