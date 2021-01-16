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
    public partial class AddData : Form
    {
        CRUDS db = new CRUDS();

        public AddData()
        {
            InitializeComponent();
            db.read(dataGridView);
            
            txtKodeBarang.Enabled = false;
            txtNamaBarang.Enabled = false;
            txtJenisBarang.Enabled = false;
            txtJumlahBarang.Enabled = false;
            txtBeratBarang.Enabled = false;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        public void refreshform()
        {
            txtKodeBarang.Text = txtNamaBarang.Text = txtJenisBarang.Text = txtJumlahBarang.Text = txtBeratBarang.Text = "";
            db.read(dataGridView);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home bk = new Home();
            bk.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string kodebarang = txtKodeBarang.Text.ToString();
            string namabarang = txtNamaBarang.Text.ToString();
            string jenisbarang = txtJenisBarang.Text.ToString();
            string jumlahbarang = txtJumlahBarang.Text.ToString();
            string beratbarang = txtBeratBarang.Text.ToString();

            txtKodeBarang.Enabled = true;
            txtNamaBarang.Enabled = true;
            txtJenisBarang.Enabled = true;
            txtJumlahBarang.Enabled = true;
            txtBeratBarang.Enabled = true;

            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            refreshform();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string kodebarang = txtKodeBarang.Text.ToString();
            string namabarang = txtNamaBarang.Text.ToString();
            string jenisbarang = txtJenisBarang.Text.ToString();
            string beratbarang = txtBeratBarang.Text.ToString();
            string jumlahbarang = txtJumlahBarang.Text.ToString();


            DialogResult dialogResult = MessageBox.Show("Apakah anda sudah yakin dengan data yang di masukan?", "Add Barang!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db.AddData(kodebarang, namabarang, jenisbarang, beratbarang, jumlahbarang);
                db.read(dataGridView);

                txtKodeBarang.Enabled = false;
                txtNamaBarang.Enabled = false;
                txtJenisBarang.Enabled = false;
                txtBeratBarang.Enabled = false;
                txtJumlahBarang.Enabled = false;

                btnNew.Enabled = true;
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

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            refreshform();
        }
    }
}
