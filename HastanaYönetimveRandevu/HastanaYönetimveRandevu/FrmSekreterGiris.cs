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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti con=new SqlBaglanti();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select SekreterTc,SekreterSifre from Sekreterler where sekretertc=@p1 and sekretersifre=@p2", con.baglanti());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader rd= command.ExecuteReader();


            if (rd.Read()) { 
              FrmSekreterDetay frm=new FrmSekreterDetay();
                frm.TCnum=MskTc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre veya Tc yanlış.");
            }
            con.baglanti().Close();

        }
    }
}
