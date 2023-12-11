using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace BEAM_Project
{
    public partial class Form4 : Form
    {
        
       

        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Load data into the DataGridView when the form is loaded

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.Show();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();  
            form2.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
    
    
