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
    public partial class DeleteData : Form
    {
        CRUDS db = new CRUDS();
        string kodebarang;

        public DeleteData()
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
            DeleteData dd = new DeleteData();
            dd.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this record ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.deleteData(kodebarang);
                db.read(dataGridView);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kodebarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
