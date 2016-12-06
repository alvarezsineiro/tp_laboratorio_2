using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// lee el historial y lo carga en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            
            List<string> aux;

            if (archivos.leer(out aux))
            {
                foreach (String item in aux)
                {
                    this.lstHistorial.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No se pudo abrir archivo");
            }
            
        }
    }
}
