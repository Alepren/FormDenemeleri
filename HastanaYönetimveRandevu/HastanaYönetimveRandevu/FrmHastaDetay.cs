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
using System.Data.Common;

namespace HastanaYönetimveRandevu
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string HastaTC = "";

        SqlBaglanti con= new SqlBaglanti();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = HastaTC;
            //ad-soyad çekme
            SqlCommand command= new SqlCommand("Select HastaAD,HastaSoyad from Hastalar where HastaTc=@p1",con.baglanti());
            command.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader rd=command.ExecuteReader();
            while(rd.Read())
            {
                LblAdSoyad.Text = rd[0] +" "+ rd[1];
            }
            con.baglanti().Close();

            //randevu geçmişi
            DataTable dt =new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Randevular where HastaTc=" + LblTc.Text ,con.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            //branscekme
            SqlCommand bransCek = new SqlCommand("Select BransAd from Branslar", con.baglanti());
            SqlDataReader drBrans= bransCek.ExecuteReader();
            for(int i=0; drBrans.Read();i++)
            {
                CmbBrans.Items.Add(drBrans[0]);

            }
            con.baglanti().Close();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktorlar.Items.Clear();
            SqlCommand doktorListeler= new SqlCommand("Select Doktorad from Doktorlar where DoktorBrans=@p1" ,con.baglanti());
            doktorListeler.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader readDoktor= doktorListeler.ExecuteReader();
            while (readDoktor.Read())
            {
                CmbDoktorlar.Items.Add(readDoktor[0]);
            }

        }

        private void CmbDoktorlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtrand=new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * from Randevular where RandevuBrans='" + CmbBrans.Text + "' and RandevuDoktor='"+CmbDoktorlar.Text+"'"+" and RandevuDurum=0 and randevudurum=0", con.baglanti());
            da.Fill(dtrand);
            dataGridView2.DataSource= dtrand;
            con.baglanti().Close();

        }

        private void LnkGuncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiGuncelle frm=new FrmBilgiGuncelle();
            frm.TCno = LblTc.Text;
            frm.Show();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtRandevuId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevu_Click(object sender, EventArgs e)
        {
            SqlCommand commandRande= new SqlCommand("update randevular set randevudurum=1, hastaTc=@p1, Hastasikayet=@p2 where randevuid=@p3" ,con.baglanti());
            commandRande.Parameters.AddWithValue("@p1",LblTc.Text);
            commandRande.Parameters.AddWithValue("@p2",RchSikayet.Text);
            commandRande.Parameters.AddWithValue("@p3",TxtRandevuId.Text);
            commandRande.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Randevu alındı");

        }
    }
}
