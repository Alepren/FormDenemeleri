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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SqlBaglanti con=new SqlBaglanti(); 
        private void BtnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand command= new SqlCommand("insert into Hastalar (HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",con.baglanti());
            command.Parameters.AddWithValue("@p1", TxtAd.Text);
            command.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            command.Parameters.AddWithValue("@p3",MskTc.Text);
            command.Parameters.AddWithValue("@p4",MskTelefon.Text);
            command.Parameters.AddWithValue("@p5",TxtSifre.Text);
            command.Parameters.AddWithValue("@p6",CmbCinsiyet.Text);
            command.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir Şifreniz: " + TxtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
