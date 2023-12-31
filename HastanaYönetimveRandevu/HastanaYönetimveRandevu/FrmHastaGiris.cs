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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti con=new SqlBaglanti();

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmHastaKayit=new FrmHastaKayit();
            frmHastaKayit.Show();
            
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand command= new SqlCommand("Select * from Hastalar where HastaTc=@p1 and HastaSifre=@p2",con.baglanti());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr= command.ExecuteReader();
            if(dr.Read())
            {
                FrmHastaDetay fr =new FrmHastaDetay();
                fr.HastaTC= MskTc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya şifre girdiniz.");
            }

            con.baglanti().Close();
        }
    }
}
