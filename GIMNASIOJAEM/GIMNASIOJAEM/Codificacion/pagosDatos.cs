using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIMNASIOJAEM.Codificacion
{
    public class pagosDatos
    {
        public int clienteID { get; set; }
        public  int membresiaID { get; set; }
        public  int usuarioID { get; set; }
        public DateTime fechaPago { get; set; }
        public float monto { get; set; }
        public string tipoPago { get; set; }
        public string estatusPago { get; set; }
        public string Concepto { get; set; }
        public pagosDatos()
        {
           
        }
    }
}
