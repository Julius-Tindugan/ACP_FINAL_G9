using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace BEAM_Project
{

    public partial class Form5 : Form
    {
        private string lastNameFilter = "";
        public Guna.UI2.WinForms.Guna2DataGridView GetDataGridView()
        {
            return guna2DataGridView1;
        }
        private int elapsedTimeInSeconds = 0;
        public Form5()
        {
           InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=concordia; charset=utf8;convert zero datetime=True"))
                {
                    con.Open();

                    string sql = "INSERT INTO add_employee (fname, lname, age, position, s_years) " +
                                 "VALUES (@FirstName, @LastName, @Age, @Position, @ServiceYears)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", employeefName.Text);
                        cmd.Parameters.AddWithValue("@LastName", emplname.Text);
                       
                        cmd.Parameters.AddWithValue("@Age", guna2ComboBox2.Text);
                        cmd.Parameters.AddWithValue("@Position", guna2ComboBox1.Text);
                        cmd.Parameters.AddWithValue("@ServiceYears", guna2ComboBox3.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // Clear input controls
                    ClearInputControls();

                    // Refresh the DataGridView with the updated data
                    LoadData(guna2DataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving data: " + ex.Message);
            }
        }

        private void ClearInputControls()
        {
            employeefName.Clear();
            emplname.Clear();
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
        }
        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                    // Assuming "id" is the column name for the unique identifier in your DataGridView
                    int selectedID = Convert.ToInt32(selectedRow.Cells["id"].Value);

                    // Delete the record from the DataGridView
                    guna2DataGridView1.Rows.Remove(selectedRow);

                    // Now, if you want to delete the record from the database as well, you can call your DeleteRecord method
                    // DeleteRecord(selectedID);

                    MessageBox.Show("Record deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}");
            }
        }
        private int GetSelectedID()
        {
            try
            {
                int selectedID = 0;

                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                    // Replace "ID" with the actual column name in your DataTable or DataGridView
                    DataGridViewCell cell = selectedRow.Cells["id"];

                    if (cell != null && cell.Value != null)
                    {
                        selectedID = Convert.ToInt32(cell.Value);
                    }
                }

                return selectedID;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting selected ID: {ex.Message}");
                return 0; // Return a default value or handle the exception accordingly
            }
        }


        private void DeleteRecord(int recordID)
        {
            // Implement this method to delete the record with the given ID from the database
            // Example SQL: DELETE FROM employees_info WHERE IDColumnName = @ID
            using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=barangay_officials; charset=utf8;convert zero datetime=True"))
            {
                con.Open();

                string sql = "DELETE FROM add_employee WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", recordID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData(guna2DataGridView1);
            UpdateDateTimeLabel();
            timer1.Start();


        }
        private void UpdateDateTimeLabel()
        {
            date_time_lbl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Display elapsed time in seconds
            
        }

        public void LoadData(DataGridView dataGridView)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=concordia; charset=utf8;convert zero datetime=True"))
                {
                    con.Open();

                    // Assuming you have a table named 'add_employee'
                    string sql = "SELECT * FROM add_employee";

                    if (!string.IsNullOrEmpty(lastNameFilter))
                    {
                        sql += $" WHERE lname LIKE '{lastNameFilter}%'";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Set the DataTable as the DataSource for the provided DataGridView
                            dataGridView.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateTimeInByFirstName(string firstName, string dateTimeIn)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=concordia; charset=utf8;convert zero datetime=True"))
                {
                    con.Open();

                    // Assuming "add_employee" is the table name
                    string sql = "UPDATE add_employee SET date_timein = @DateTimeIn WHERE fname = @FirstName";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@DateTimeIn", dateTimeIn);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Timein: {ex.Message}");
            }
        }
        public void UpdateTimeOutByFirstName(string firstName, string dateTimeOut)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;userid=root;password=;database=concordia; charset=utf8;convert zero datetime=True"))
                {
                    con.Open();

                    // Assuming "add_employee" is the table name
                    string sql = "UPDATE add_employee SET date_timeout = @DateTimeIn WHERE fname = @FirstName";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@DateTimeIn", dateTimeOut);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Timein: {ex.Message}");
            }
        }
        public int FindUserRowIndex(string userName)
    {
        try
        {
            // Assuming "fname" is the column name in your DataGridView
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["fname"].Value != null && row.Cells["fname"].Value.ToString() == userName)
                {
                    return row.Index;
                }
            }

            return -1; // User not found
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in FindUserRowIndex: {ex.Message}");
            return -1; // Return a default value or handle the exception accordingly
        }
    }
        public void UpdateTimeIn(string userName)
        {
            int rowIndex = FindUserRowIndex(userName);

            if (rowIndex != -1)
            {
                // Assuming "time_in" is the column name for the time_in field in your DataTable or DataGridView
                guna2DataGridView1.Rows[rowIndex].Cells["date_timein"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        } 


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeefName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void currentdate_time_display_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login form3 = new Admin_Login();
            form3.Show();
        }

        public void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                // You can now access the data in the selected row
                // For example, if you have an ID column, you can get the ID like this:
                // int selectedID = Convert.ToInt32(selectedRow.Cells["IDColumnName"].Value);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
           
            elapsedTimeInSeconds++;
        }
        public void UpdateDataGridView()
        {
            LoadData(guna2DataGridView1);
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}