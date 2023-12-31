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

namespace HastanaYönetimveRandevu
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        SqlBaglanti con = new SqlBaglanti();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dadap =new  SqlDataAdapter("Select * from Doktorlar", con.baglanti());
            dadap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.baglanti().Close();


            //brans çek
            SqlCommand bransCek = new SqlCommand("Select BransAd from Branslar");
            SqlDataReader rr = bransCek.ExecuteReader();

            while (rr.Read())
            {
                CmbBrans.Items.Add(rr[0]);
            }
            con.baglanti().Close();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand EkleBut = new SqlCommand("insert into Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", con.baglanti());
            EkleBut.Parameters.AddWithValue("@p1", TxtAd.Text);
            EkleBut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            EkleBut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            EkleBut.Parameters.AddWithValue("@p4", MskTC.Text);
            EkleBut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            EkleBut.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Doktor kaydedildi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand commandUn = new SqlCommand("Delete from Doktorlar where DoktorTc=@p1", con.baglanti());
            commandUn.Parameters.AddWithValue("@p1", MskTC.Text);
            commandUn.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Doktor silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand commandGun = new SqlCommand("Update Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTc=@p4", con.baglanti());
            commandGun.Parameters.AddWithValue("@p1", TxtAd.Text);
            commandGun.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            commandGun.Parameters.AddWithValue("@p3", CmbBrans.Text);
            commandGun.Parameters.AddWithValue("@p4", MskTC.Text);
            commandGun.Parameters.AddWithValue("@p5", TxtSifre.Text);
            commandGun.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Doktor güncellendi");
        }
    }
}
