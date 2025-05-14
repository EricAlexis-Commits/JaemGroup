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
    public partial class Entrenador : Form
    {
        public Entrenador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrarEntrenador registro = new registrarEntrenador();
            registro.ShowDialog();
        }
    }
}
