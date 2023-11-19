using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MSIProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        static void Main() { } 

        string inputEmail;
        int[] pwArray;

        private void pwGenerated(object sender, EventArgs s)
        {
            pwArray = new int[20];

            for (int i = 0; i < pwArray.Length; i++)
            {
                Random random = new Random();
                pwArray[i] = random.Next(100000, 999999);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputEmail = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputEmail.Substring(inputEmail.Length - 9) == "@ucsd.edu")
            {
                    
            }
            else
            {
                MessageBox.Show("Invalid UCSD email. Try Again.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

     
    }
}
