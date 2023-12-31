using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Personel_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con =new SqlConnection("Data Source=DESKTOP-EMFHEHV;Initial Catalog=muratY;Integrated Security=True;TrustServerCertificate=True;");
        
        void temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMeslek.Text = "";
            TxtPersonelid.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TblPersonel",con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dataTable= new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource= dataTable;
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut=new SqlCommand("insert into TblPersonel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", con);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            if (radioButton1.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6", "true");

            }
            else
            {
                komut.Parameters.AddWithValue("@p6", "false");
            }

            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Peronel eklendi"); 
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilendeger = dataGridView1.SelectedCells[0].RowIndex; 
            TxtPersonelid.Text = dataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilendeger].Cells[2].Value.ToString();

            CmbSehir.Text = dataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilendeger].Cells[4].Value.ToString();

            if (dataGridView1.Rows[secilendeger].Cells[5].Value.ToString() == "True") { 
                radioButton1.Checked= true;
            }
            else
            {
                radioButton2.Checked= true;
            }
            TxtMeslek.Text = dataGridView1.Rows[secilendeger].Cells[6].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand delete = new SqlCommand("delete from TblPersonel where Perid=@k1",con);

            delete.Parameters.AddWithValue("@k1", TxtPersonelid.Text);
            delete.ExecuteNonQuery(); 
            con.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TblPersonel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand guncelle = new SqlCommand("update TblPersonel set Perad=@a1,Persoyad=@a2,Persehir=@a3, PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", con);
            guncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            guncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            guncelle.Parameters.AddWithValue("@a4", MskMaas.Text);

            if (radioButton1.Checked)
            {
                guncelle.Parameters.AddWithValue("@a5", "True");
            }else
                guncelle.Parameters.AddWithValue("@a5", "False");

            guncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            guncelle.Parameters.AddWithValue("@a7", TxtPersonelid.Text);

            guncelle.ExecuteNonQuery();

            con.Close();
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            Form2 form2= new Form2();
            form2.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {

        }
    }
}