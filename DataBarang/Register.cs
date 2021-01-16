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
    public partial class Register : Form
    {
        SqlConnection koneksi = new SqlConnection("Data Source = DESKTOP-A10O2PP; Initial Catalog=DBDaftarDataBarang; User ID = sa; password=deckyap24");
        public SqlCommand cmd;

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Isi Data Dengan Lengkap");
            }
            else if (txtPassword.Text != txtConfPass.Text)
            {
                MessageBox.Show("Password Tidak Cocok");
            }
            else
            {
                koneksi.Open();
                string sql = "insert into Users (Username, Password) values ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                cmd = new SqlCommand(sql, koneksi);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Register Berhasil Dibuat");
                Clear();
            }
        }

        void Clear()
        {
            txtUsername.Text = txtPassword.Text = txtConfPass.Text = "";
        }

        private void btnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
