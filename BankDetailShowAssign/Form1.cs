using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;

namespace BankDetailShowAssign
{
    public partial class Form1: Form
    {
        public Microsoft.Data.SqlClient.SqlConnection con { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void accnotxt_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RJ7FDJE\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            // Define connection properly
            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM accdetails WHERE accNo = @accNo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Use TryParse to prevent runtime errors
                        if (int.TryParse(accnotxt.Text, out int accNo))
                        {
                            cmd.Parameters.AddWithValue("@accNo", accNo);

                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            sda.Fill(ds, "Accdetails");

                            dataGridView1.DataSource = ds.Tables["Accdetails"].DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Account Number. Please enter a numeric value.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            } 
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            accnotxt.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            accnotxt.ReadOnly = true;

        }
    }
}
