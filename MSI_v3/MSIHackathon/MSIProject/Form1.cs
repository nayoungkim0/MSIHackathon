using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace MSIProject
{
    public partial class Form1 : Form
    {
        string inputEmail;
        int passcode;
        int newRandomIdx;

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

            Random randomIdx = new Random();
            newRandomIdx = randomIdx.Next(0, 20);
            passcode = pwArray[newRandomIdx];
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputEmail = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputEmail.Substring(inputEmail.Length - 9) == "@ucsd.edu")
            {

                try
                {
                    SmtpClient TEC_customer = new SmtpClient();
                    TEC_customer.UseDefaultCredentials = false;
                    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("jibang@ucsd.edu", "114@Qkdwlgus04@");
                    TEC_customer.Credentials = basicAuthenticationInfo;

                    //Construct Email Message
                    MailAddress to = new MailAddress(inputEmail);
                    MailAddress from = new MailAddress("jibang@ucsd.edu");
                    MailMessage email = new System.Net.Mail.MailMessage(from, to);

                    //MailMessage email = new MailMessage(from, to);
                    email.Subject = "Passcode for UCSD TEC";
                    email.Body = "Your passcode: " + passcode.ToString();
                    TEC_customer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    TEC_customer.EnableSsl = true;

                    //sending the mail
                    TEC_customer.Send(email);

                }

                catch(SmtpException ex)
                {
                    throw new ApplicationException("SmtpException has occured : " + ex.Message);

                }

                catch(Exception ex)
                {
                    throw ex;
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
