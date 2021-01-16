using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBarang
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-A10O2PP; Initial Catalog=DBDaftarDataBarang; User ID = sa; password=deckyap24");

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE Username='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Home hm = new Home();
                this.Hide();
                hm.Show();
            }
            else
                MessageBox.Show("Invalid username or password");
        }

        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            this.Hide();
        }
    }
}
