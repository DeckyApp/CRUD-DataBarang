using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBarang
{
    public partial class ViewData : Form
    {
        CRUDS db = new CRUDS();

        public ViewData()
        {
            InitializeComponent();
            db.read(dataGridView);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home bk = new Home();
            bk.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewData dv = new ViewData();
            dv.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cari = txtSearch.Text.ToString();
            db.search(cari, dataGridView);
        }
    }
}
