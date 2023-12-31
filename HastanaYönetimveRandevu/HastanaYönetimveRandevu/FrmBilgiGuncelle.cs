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
    public partial class FrmBilgiGuncelle : Form
    {
        public FrmBilgiGuncelle()
        {
            InitializeComponent();
        }
        SqlBaglanti con = new SqlBaglanti();
        public string TCno;
        private void FrmBilgiGuncelle_Load(object sender, EventArgs e)
        {
            MskTc.Text = TCno;
            SqlCommand VeriCek=new SqlCommand("Select * from Hastalar where HastaTc="+TCno , con.baglanti());
            SqlDataReader HastaVeri=VeriCek.ExecuteReader();

            while(HastaVeri.Read())
            {
                TxtAd.Text = HastaVeri[1].ToString();
                TxtSoyad.Text = HastaVeri[2].ToString();
                MskTelefon.Text = HastaVeri[4].ToString();
                CmbCinsiyet.Text = HastaVeri[6].ToString();
            }
            con.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("Update Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3,HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTc=@p6", con.baglanti());
            update.Parameters.AddWithValue("@p1",TxtAd.Text);
            update.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            update.Parameters.AddWithValue("@p3",MskTelefon.Text);
            update.Parameters.AddWithValue("@p4",TxtSifre.Text);
            update.Parameters.AddWithValue("@p5",CmbCinsiyet.Text);
            update.Parameters.AddWithValue("@p6",MskTc.Text);
            update.ExecuteNonQuery();
            con.baglanti().Close(); 
        }
        
    }
}
