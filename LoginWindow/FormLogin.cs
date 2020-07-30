using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginWindow
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brian Kenny\source\repos\LoginApp\Database\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from TableLogin Where username = '" + txtUsername.Text.Trim() + "' and password = '"+ txtPassword.Text.Trim() +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if(dtbl.Rows.Count == 1)
            {
                FormMain objFormMain = new FormMain();
                this.Hide();
                objFormMain.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
