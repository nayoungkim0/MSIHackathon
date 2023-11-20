using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http.Results;
using NetFwTypeLib;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MSI_v5
{

    public partial class Form1 : Form
    {

        string inputEmail;
        int passcode;
        int passcodeIdx;
        string passcodeInput;
        bool isLoginSuccessful = false;
        string pcNumber;
        DateTime startTime;



        public Form1() { 
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            passcodeInput = textBox2.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (passcodeInput == passcode.ToString())
            {
                isLoginSuccessful = true;
                MessageBox.Show("Log in Successful.");
                this.Hide();
                
                using(PerformanceCounter pc = new PerformanceCounter("System", "System Up Time"))
                {
                    //pc.NextValue();
                    //label1.Text = TimeSpan.FromSeconds(pc.NextValue()).ToString();
                    //startTime = new DateTime(DateTime.Now.TimeOfDay.Ticks);
                    startTime = DateTime.Now;
                    MessageBox.Show("Start Time: " + startTime);
                }
             
            }
            else
            {
                MessageBox.Show("Your passcode is incorrect. Try again.");
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pcNumber = textBox3.Text;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        
        }

        
    }
}
