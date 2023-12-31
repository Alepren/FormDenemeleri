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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnum;
        SqlBaglanti con=new SqlBaglanti();  

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = TCnum;
            
            //Ad- Soyad çekme
            SqlCommand command1=new SqlCommand("Select SekreterAdSoyad from Sekreterler where SekreterTc="+TCnum,con.baglanti());
            SqlDataReader rd=command1.ExecuteReader();

            if(rd.Read())
            {
                LblAdSoyad.Text = rd[0].ToString();
            }
            con.baglanti().Close();

            //Bransları datagride aktarma
            DataTable dataTable= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Branslar",con.baglanti());

            da.Fill(dataTable);
            dataGridView1.DataSource= dataTable;

            con.baglanti().Close();

            //doktorları çekme
            DataTable dataTable2= new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Doktorlar", con.baglanti());
            da2.Fill(dataTable2);

            dataGridView2.DataSource= dataTable2;

            con.baglanti().Close();

            //cmbleri doldurma


            SqlCommand komut4 = new SqlCommand("Select BransAd from Branslar", con.baglanti());
            SqlDataReader rdDb = komut4.ExecuteReader();

            while(rdDb.Read())
            {
                CmbBrans.Items.Add(rdDb[0].ToString());

            }

            con.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) " +
                " values (@p1,@p2,@p3,@p4)",con.baglanti());

            komutKaydet.Parameters.AddWithValue("@p1", MskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@p2", MskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@p4", CmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            con.baglanti().Close();
            MessageBox.Show("Randevu olusturuldu.");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();


            SqlCommand komut3 = new SqlCommand("Select DoktorAd from Doktorlar", con.baglanti());
            SqlDataReader rdD = komut3.ExecuteReader();

            while (rdD.Read())
            {
                CmbDoktor.Items.Add(rdD[0].ToString());

            }

            con.baglanti().Close();

        }



        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand command5 = new SqlCommand("insert into Duyurular (duyuru) values (@p1)", con.baglanti());
            command5.Parameters.AddWithValue("@p1", RchDuyuru.Text);
            command5.ExecuteNonQuery();

            con.baglanti().Close();

            MessageBox.Show("Duyuru oluştu.");
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frm = new FrmDoktorPaneli();
            frm.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans frmb = new FrmBrans(); 
            frmb.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frmran=new FrmRandevuListesi();
            frmran.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmduy=new FrmDuyurular();
            frmduy.Show();
        }
    }
}
