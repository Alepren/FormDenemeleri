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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        SqlBaglanti con=new SqlBaglanti();

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dataTable= new DataTable();
            SqlDataAdapter dp= new SqlDataAdapter("Select * from Branslar",con.baglanti());
            dp.Fill(dataTable);
            dataGridView1.DataSource= dataTable;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand command1= new SqlCommand("insert into Branslar (BransAd) values (@p1)",con.baglanti());
            command1.Parameters.AddWithValue("@p1",TxtAd.Text);
            command1.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Brans eklendi.");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand commandSil = new SqlCommand("delete from Branslar where Bransad=@p1", con.baglanti());
            commandSil.Parameters.AddWithValue("@p1", TxtAd.Text);
            commandSil.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Brans silindi.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand commandGun = new SqlCommand("update Branslar set BransAd=@p1 where bransid=@p2",con.baglanti());
            commandGun.Parameters.AddWithValue("@p1", TxtAd.Text);
            commandGun.Parameters.AddWithValue("@p2", TxtId.Text);
            commandGun.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Brans güncellendi.");
        }
    }
}
