using MySql.Data.MySqlClient;
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
    public partial class Form7 : Form
    {
         private Form5 form5Instance;
        public Form7()
        {
            InitializeComponent();
            form5Instance = Application.OpenForms.OfType<Form5>().FirstOrDefault() ?? new Form5();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            guna2TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=concordia; charset=utf8;convert zero datetime=True"))
                {
                    con.Open();

                    // Assuming you have a table named 'add_employee'
                    string sql = "SELECT * FROM add_employee WHERE fname = @UserName";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", guna2TextBox1.Text.Trim());

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];
                                string firstName = row["fname"].ToString();

                                // Get the current date and time
                                string dateTimeOut = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                // Update the Timein column in Form5's DataGridView
                                Form5 form5Instance = Application.OpenForms.OfType<Form5>().FirstOrDefault() ?? new Form5();
                                form5Instance.UpdateTimeOutByFirstName(firstName, dateTimeOut);

                                MessageBox.Show($"User found: {firstName}");
                            }
                            else
                            {
                                MessageBox.Show("User not found. Please check the name.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error querying database: {ex.Message}");
            }

            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }
       

    }
}
