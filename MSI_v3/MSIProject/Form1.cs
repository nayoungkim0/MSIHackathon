using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Mail ;
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
        string inputEmail;
        int passcode;
        int passcodeIdx;

        public Form1()
        {
            InitializeComponent();
        }

        private void pwGenerated()
        {
            int[] pwArray = new int[20];
            

            for (int i = 0; i < pwArray.Length; i++)
            {
                Random random = new Random();
                pwArray[i] = random.Next(100000, 999999);
            }

            Random newrandomIdx = new Random();
            passcodeIdx = newrandomIdx.Next(0, 20);
            passcode = pwArray[passcodeIdx];    

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputEmail = textBox1.Text;
            pwGenerated();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputEmail.Length > 9 && inputEmail.Substring(inputEmail.Length - 9) == "@ucsd.edu")
            {
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    mailMessage.From = new MailAddress("myk001@ucsd.edu");
                    mailMessage.To.Add(inputEmail);
                    mailMessage.Subject = "TEC passcode";
                    mailMessage.Body = "Your passcode for TEC: " + passcode.ToString();
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("myk001@ucsd.edu", "xcao eeos gthq pypv");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    MessageBox.Show("Your passcode is sent to your email.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

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
