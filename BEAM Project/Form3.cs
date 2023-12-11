using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEAM_Project
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (textBox1.ForeColor != Color.DarkGray)
                {
                    textBox1.Text = "Enter Username";
                    textBox1.ForeColor = Color.DarkGray; // Set placeholder text color
                    panel4.Visible = false;
                }
            } 
            catch 
            { 
            
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.ForeColor != Color.DarkGray)
                {
                    textBox2.Text = "Password";
                    textBox2.ForeColor = Color.DarkGray; // Set placeholder text color
                    panel6.Visible = false;
                }
            
            }
            catch
            {

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(27, 58, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Enter Username") 
            {
                panel4.Visible = true;
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "Password")
            {
                panel6.Visible = true;
                textBox2.Focus();
                return;
            }
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                // Successful login, navigate to the next page (replace 'NextPage' with your actual form/page)
                
                this.Hide();
                Form5 form5 = new Form5();
                form5.Show();
                this.Close();
            }
            else
            {
                panel4.Visible = true;
                panel6.Visible = true;
                textBox1.Focus();
            }
        }

        private void Admin_Login_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username")
            {
                panel4.Visible = true;
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "Password")
            {
                panel6.Visible = true;
                textBox2.Focus();
                return;
            }
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                // Successful login, navigate to the next page (replace 'NextPage' with your actual form/page)

                this.Hide();
                Form5 form5 = new Form5();
                form5.Show();
                this.Close();
            }
            else
            {
                panel4.Visible = true;
                panel6.Visible = true;
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
