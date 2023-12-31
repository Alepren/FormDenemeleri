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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglanti con=new SqlBaglanti();
        public string Tc;
        string doktorAd;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LbLTc.Text = Tc;
            

            //Doktor Ad Soyad query
            SqlCommand commandAd = new SqlCommand("Select DoktorAd,DoktorSoyad from Doktorlar where DoktorTc=@p1",con.baglanti());
            commandAd.Parameters.AddWithValue("@p1", LbLTc.Text);
            SqlDataReader rd = commandAd.ExecuteReader();
            if(rd.Read())
            {
                LblAdSoyad.Text = rd[0]+ " " + rd[1];
                doktorAd = rd[0].ToString();

            }
            con.baglanti().Close();
             

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from randevular where RandevuDoktor='" + doktorAd + "'", con.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frm=new FrmDoktorBilgiDuzenle();
            frm.TcNO=LbLTc.Text;
            frm.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm=new FrmDuyurular();
            frm.Show();
        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text= dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
