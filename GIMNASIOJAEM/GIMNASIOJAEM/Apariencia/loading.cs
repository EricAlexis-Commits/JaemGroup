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
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
            pbLoading.Load(@"D:\Documentos\Semestre 4\Ingenieria Software I\imagenes\loadingGif.gif");
            //pbLoading.Location = new Point(this.Width/2-pbLoading.Width/2, this.Height/2-pbLoading.Height/2);
            int x = (this.ClientSize.Width - pbLoading.Width) / 2;
            int y = (this.ClientSize.Height - pbLoading.Height) / 2;

            pbLoading.Location = new Point(x, y);
        }
    }
}
