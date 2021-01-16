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
    public partial class UpdateData : Form
    {
        CRUDS db = new CRUDS();

        public UpdateData()
        {
            InitializeComponent();
            db.read(dataGridView);
            
            txtKodeBarang.Enabled = false;
            txtNamaBarang.Enabled = false;
            txtJenisBarang.Enabled = false;
            txtJumlahBarang.Enabled = false;
            txtBeratBarang.Enabled = false;
            
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home bk = new Home();
            bk.Show();
            this.Hide();
        }

        public void refreshform()
        {
            txtKodeBarang.Text = txtNamaBarang.Text = txtJenisBarang.Text = txtJumlahBarang.Text = txtBeratBarang.Text = "";
            db.read(dataGridView);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string kodebarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            string namabarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            string jenisbarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[2].Value);
            string beratbarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[3].Value);
            string jumlahbarang = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            
            txtKodeBarang.Text = kodebarang;
            txtNamaBarang.Text = namabarang;
            txtJenisBarang.Text = jenisbarang;
            txtBeratBarang.Text = beratbarang;
            txtJumlahBarang.Text = jumlahbarang;
            
            txtKodeBarang.Enabled = true;
            txtNamaBarang.Enabled = true;
            txtJenisBarang.Enabled = true;
            txtJumlahBarang.Enabled = true;
            txtBeratBarang.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string kodebarang = txtKodeBarang.Text.ToString();
            string namabarang = txtNamaBarang.Text.ToString();
            string jenisbarang = txtJenisBarang.Text.ToString();
            string beratbarang = txtBeratBarang.Text.ToString();
            string jumlahbarang = txtJumlahBarang.Text.ToString();
            
            DialogResult dialogResult = MessageBox.Show("Apakah ada yang ingin mengupdate ?", "Update Data !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db.UpdateData(kodebarang, namabarang, jenisbarang, beratbarang, jumlahbarang);
                db.read(dataGridView);

                txtKodeBarang.Enabled = false;
                txtNamaBarang.Enabled = false;
                txtJenisBarang.Enabled = false;
                txtJumlahBarang.Enabled = false;
                txtBeratBarang.Enabled = false;

                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                refreshform();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtKodeBarang.Enabled = false;
            txtNamaBarang.Enabled = false;
            txtJenisBarang.Enabled = false;
            txtJumlahBarang.Enabled = false;
            txtBeratBarang.Enabled = false;
            
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            refreshform();
        }
    }
}
