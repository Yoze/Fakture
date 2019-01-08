using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fakture.UI
{
    public partial class test : Form
    {
        public decimal BezPDV { get; set; }
        public decimal SaPDV { get; set; }




        public test()
        {
            InitializeComponent();
        }





        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                textBox1.Text = SaPDV.ToString("N2");
            }
           else
            {
                textBox1.Text = BezPDV.ToString("N2");
            }

        }


        private void kalk()
        {
            if (checkBox1.Checked == true)
            {
                SaPDV = Convert.ToDecimal(textBox1.Text);
                BezPDV = Convert.ToDecimal(textBox1.Text) / (decimal)1.2;
            }
            else
            {
                SaPDV = Convert.ToDecimal(textBox1.Text) * (decimal)1.2;
                BezPDV = Convert.ToDecimal(textBox1.Text);
            }            
            labelSaPDV.Text = SaPDV.ToString("N2");



            //BezPDV = Convert.ToDecimal(textBox1.Text);
            labelBezPDV.Text = BezPDV.ToString("N2");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //kalk();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            kalk();
        }
    }
}
