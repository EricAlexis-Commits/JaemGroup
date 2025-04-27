using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace GIMNASIOJAEM.Codificacion
{
    internal class SQL
    {
        public MySqlConnection conexion;
        public SQL(MySqlConnection Conexion)
        {
            Conexion = conexion;
        }
        public void fillDVG()
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM ",conexion);

            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

            DataTable tabla = new DataTable();

            adaptador.Fill(tabla);
        }

    }
}
