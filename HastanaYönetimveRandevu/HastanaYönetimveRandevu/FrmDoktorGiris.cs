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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti con=new SqlBaglanti();

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand commadn = new SqlCommand("Select DoktorTc,DoktorSifre from Doktorlar where DoktorTc=@p1 and DoktorSifre=@p2",con.baglanti());
            commadn.Parameters.AddWithValue("@p1", MskTc.Text);
            commadn.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader rd = commadn.ExecuteReader();
            if (rd.Read())
            {
                FrmDoktorDetay frm= new FrmDoktorDetay();
                frm.Tc=MskTc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı şifre veya Tc kimlik numarası girdiniz.");
            }

            con.baglanti().Close(); 
        }
    }
}
