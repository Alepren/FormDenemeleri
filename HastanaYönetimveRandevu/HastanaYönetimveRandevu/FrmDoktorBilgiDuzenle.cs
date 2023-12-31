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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglanti con= new SqlBaglanti();
        public string TcNO;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = TcNO;

            SqlCommand command= new SqlCommand("Select * from Doktorlar where DoktorTc=@p1",con.baglanti());
            command.Parameters.AddWithValue("@p1",MskTc.Text);
            SqlDataReader rd= command.ExecuteReader();
            while(rd.Read())
            {
                TxtAd.Text = rd[1].ToString();
                TxtSoyad.Text = rd[2].ToString();
                CmbBrans.Text = rd[3].ToString();
                TxtSifre.Text = rd[5].ToString();
            }
            con.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand commandG = new SqlCommand("update Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", con.baglanti());
            commandG.Parameters.AddWithValue("@p1",TxtAd.Text);
            commandG.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            commandG.Parameters.AddWithValue("@p3",CmbBrans.Text);
            commandG.Parameters.AddWithValue("@p4",TxtSifre.Text);
            commandG.Parameters.AddWithValue("@p5",MskTc.Text);

            commandG.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Bilgiler güncellendi");
        }
    }
}
