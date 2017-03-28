using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionCertificateGenerator
{
    public partial class PasswordBox : Form
    {
        public PasswordBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool test()
        {
            if (textBox1.Text == "p" && textBox2.Text == "p")
            {
                return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (test())
                this.Close();
            //this.Visible = false;
        }

        private void PasswordBox_Load(object sender, EventArgs e)
        {

        }
        public void Exit()
        {
            this.Close();
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void PasswordBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!test())
                e.Cancel = true;
        }
    }
}
