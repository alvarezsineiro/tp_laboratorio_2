using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Practico_N_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero A = new Numero(txtNumero1.Text);
            Numero B = new Numero(txtNumero2.Text);
            Calculadora calculadora= new Calculadora();
            cmbOperacion.Text = calculadora.validarOperador(cmbOperacion.Text);
            lblResultado.Text = Convert.ToString(calculadora.operar(A, B, cmbOperacion.Text));
              
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "Resultado";
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperacion.Text = " ";
            
        }
    }
}
