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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            dynamic result = MessageBox.Show("Do You Want To Exit?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            if (result == DialogResult.No)
            {
                result = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewData dv = new ViewData();
            dv.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData ad = new AddData();
            ad.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData ud = new UpdateData();
            ud.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData dd = new DeleteData();
            dd.Show();
            this.Hide();
        }
    }
}
