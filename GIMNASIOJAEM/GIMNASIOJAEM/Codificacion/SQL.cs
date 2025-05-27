using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GIMNASIOJAEM.Codificacion
{
    internal class SQL
    {
        public MySqlConnection conexion;
        public SQL(MySqlConnection Conexion)
        {
            this.conexion = Conexion;
        }
        //Metodo para llenar el datatable
        public DataTable fillDVG(string table,DataGridView dgv)
        {
            DataTable dt = new DataTable();
            if (conexion.State != ConnectionState.Open)
            {
                try
                {
                    conexion.Open();
                    MySqlCommand mysqlcommand = new MySqlCommand($"SELECT * FROM {table}", conexion);
                    MySqlDataAdapter mysqldataAdapter = new MySqlDataAdapter(mysqlcommand);
                    mysqldataAdapter.Fill(dt);
                    dgv.DataSource = dt;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    
                    
                        conexion.Close();
                    
                }
                
            }
            return dt;
        }

    }
}
