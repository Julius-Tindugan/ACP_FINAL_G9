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
    public partial class Form1 : Form
    {
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            
            InitializeTimer();
        }
        private void InitializeProgressBar()
        {
            progressBar1 = new ProgressBar();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            Controls.Add(progressBar1);
            progressBar1.Dock = DockStyle.Bottom;
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 500; // Set the interval (in milliseconds) for the timer
            timer.Tick += Timer_Tick; // Attach an event handler for the timer tick event
            timer.Start(); // Start the timer
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.PerformStep();
            }
            else
            {
                timer.Stop(); // Stop the timer when the progress bar reaches its maximum value
                MessageBox.Show("Loading completed!");
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
        }
    }
}
