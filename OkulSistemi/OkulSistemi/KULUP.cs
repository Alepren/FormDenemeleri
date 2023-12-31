using Microsoft.Data.SqlClient;
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

namespace OkulSistemi
{
    public partial class KULUP : Form
    {
        public KULUP()
        {
            InitializeComponent();
        }

        System.Data.SqlClient.SqlConnection bgl = new("Data Source=DESKTOP-EMFHEHV;Initial Catalog=OkulSistemi;Integrated Security=True;TrustServerCertificate=True");


         public void listele()
        {
            System.Data.SqlClient.SqlDataAdapter da = new("Select * from TBL_KULUPLER ", bgl);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void KULUP_Load(object sender, EventArgs e)
        {
            listele();   
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            System.Data.SqlClient.SqlCommand komut = new("insert into TBL_Kulupler (KULUPAD) values (@p1)",bgl);
            komut.Parameters.AddWithValue("@p1",TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp eklendi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKlupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); 
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            System.Data.SqlClient.SqlCommand komut = new("Delete from TBL_KULUPLER where Kulupid=@p1", bgl);
            komut.Parameters.AddWithValue("@p1",TxtKlupid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp silindi.");
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            System.Data.SqlClient.SqlCommand komut = new("update TBL_KULUPLER set kulupad=@p1 where kulupid=@p2", bgl);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKlupid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp silindi");
            listele();  
        }
    }
}
