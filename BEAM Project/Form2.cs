﻿using System;
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
    public partial class Form2 : Form
    {
        private Form4 form4Reference;
        public Form2()
        {
            InitializeComponent();
            form4Reference = new Form4();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin_Login form3 = new Admin_Login();
            form3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
