using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataBarang
{
    class CRUDS
    {

        public void read(DataGridView dgv)
        {
            string koneksi = "Data Source=DESKTOP-A10O2PP;Initial Catalog=DBDaftarDataBarang;User ID=sa;Password=deckyap24";

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Barang ORDER BY KodeBarang ASC", koneksi);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Barang");
            dgv.DataSource = ds.Tables["Barang"].DefaultView;
        }

        public void AddData(string kodebarang, string namabarang, string jenisbarang, string beratbarang, string jumlahbarang)
        {
            string koneksi = "Data Source=DESKTOP-A10O2PP;Initial Catalog=DBDaftarDataBarang;User ID=sa;Password=deckyap24";

            string str = "Insert into Barang values (@Kodebarang, @Namabarang, @Jenisbarang, @Beratbarang, @Jumlahbarang)";

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = koneksi;

            if ((kodebarang == "") || (namabarang == "") || (jenisbarang == "") || (beratbarang == "") || (jumlahbarang == ""))
            {
                MessageBox.Show("Silahkan isi semua kolom!");
            }
            else
            {
                sc.Open();

                SqlCommand cmd = new SqlCommand(str, sc);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.Add(new SqlParameter("Kodebarang", kodebarang));
                cmd.Parameters.Add(new SqlParameter("Namabarang", namabarang));
                cmd.Parameters.Add(new SqlParameter("Jenisbarang", jenisbarang));
                cmd.Parameters.Add(new SqlParameter("Beratbarang", beratbarang));
                cmd.Parameters.Add(new SqlParameter("Jumlahbarang", jumlahbarang));
                cmd.ExecuteNonQuery();

                sc.Close();
            }
        }

        public void UpdateData(string kodebarang, string namabarang, string jenisbarang, string beratbarang, string jumlahbarang)
        {
            string koneksi = "Data Source=DESKTOP-A10O2PP;Initial Catalog=DBDaftarDataBarang;User ID=sa;Password=deckyap24";

            string str = "Update Barang set NamaBarang=@Namabarang, JenisBarang=@Jenisbarang, BeratBarang=@Beratbarang, JumlahBarang=@Jumlahbarang where KodeBarang=@Kodebarang";
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = koneksi;
            sc.Open();

            SqlCommand cmd = new SqlCommand(str, sc);
            cmd.CommandType = CommandType.Text;
            
            cmd.Parameters.Add(new SqlParameter("Kodebarang", kodebarang));
            cmd.Parameters.Add(new SqlParameter("Namabarang", namabarang));
            cmd.Parameters.Add(new SqlParameter("Jenisbarang", jenisbarang));
            cmd.Parameters.Add(new SqlParameter("Beratbarang", beratbarang));
            cmd.Parameters.Add(new SqlParameter("Jumlahbarang", jumlahbarang));

            cmd.ExecuteNonQuery();

            sc.Close();
        }

        public void deleteData(string kodebarang)
        {
            string koneksi = "Data Source=DESKTOP-A10O2PP;Initial Catalog=DBDaftarDataBarang;User ID=sa;Password=deckyap24";

            string str = "Delete Barang where KodeBarang=@Kodebarang";

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = koneksi;

            sc.Open();
            SqlCommand cmd = new SqlCommand(str, sc);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Kodebarang", kodebarang));
            cmd.ExecuteNonQuery();
            sc.Close();
        }

        public void search(string cari, DataGridView dgv)
        {
            string koneksi = "Data Source=DESKTOP-A10O2PP;Initial Catalog=DBDaftarDataBarang;User ID=sa;Password=deckyap24";

            string str = "SELECT * FROM Barang WHERE KodeBarang LIKE '%" + cari + "%'";

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = koneksi;

            sc.Open();
            SqlCommand cmd = new SqlCommand(str, sc);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
        }
    }
}
