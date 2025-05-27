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
    public partial class Rutinas : Form
    {
        public Rutinas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearRutina rutina = new crearRutina();
            rutina.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            asignamientoEntrenador asignamiento = new asignamientoEntrenador();
            asignamiento.ShowDialog();
        }
    }
}
