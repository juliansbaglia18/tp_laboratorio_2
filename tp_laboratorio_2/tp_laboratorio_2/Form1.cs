using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_laboratorio_2
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Iniciar();
        
        }

        Numero num1 = new Numero();

        Numero num2 = new Numero();

        string oper;

        bool flag;

        /// <summary>
        /// Guarda el numero escrito en num1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
        
            num1.SetNumero(txtNum1.Text);
        
        }

        /// <summary>
        /// Guarda el numero escrito en num2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNum2_TextChanged(object sender, EventArgs e)
        {
        
            num2.SetNumero(txtNum2.Text);
        
        }

        /// <summary>
        /// Guarda el operador seleccionado en oper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            oper = comboBox1.Text;
        
        }

        /// <summary>
        /// Realiza el calculo y lo muestra en lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        { 
        
            lblResultado.Text = Calculadora.Operar(num1, num2, oper);

            flag = false;
        
        }

        /// <summary>
        /// Reinicia los textbox, combobox y label a su origen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
        
            Iniciar();
        
        }

        /// <summary>
        /// Finaliza el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
        
            Close();
        
        }

        /// <summary>
        /// En caso de ser false flag, convierte el lblResultado
        /// en binario y lo muestra por el mismo. Pone a flag en true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinario_Click(object sender, EventArgs e)
        {

            if(!flag)
            {
        
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);

                 flag = true;
            
            }
        }

        /// <summary>
        /// En caso de ser true flag, convierte el lblResultado
        /// en decimal y lo muestra por el mismo. Pone a flag en false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            
            if (flag)
            {
            
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                
                flag = false;
            
            }
        }

        /// <summary>
        /// Se borra lo que este en txtNum1 y txtNum2.
        /// Se pone el lblResultado en 0.
        /// </summary>
        private void Iniciar()
        {
            
            flag = false;

            lblResultado.Text = "0";

            txtNum1.Text = "";

            txtNum2.Text = "";

            comboBox1.SelectedIndex = -1;
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
