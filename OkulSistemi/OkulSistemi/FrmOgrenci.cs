using OkulSistemi.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OkulSistemi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            System.Data.SqlClient.SqlConnection bgl = new("Data Source=DESKTOP-EMFHEHV;Initial Catalog=OkulSistemi;Integrated Security=True;TrustServerCertificate=True");

            bgl.Open();

            SqlCommand command = new SqlCommand("Select * from TBL_KULUPLER",bgl);
            SqlDataReader rd= command.ExecuteReader();
            while(rd.Read()) {
                CmbKulüp.Items.Add(rd[1].ToString());
            }
        }
        string ca = " ";

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked==true)
            {
                ca = "Kız";

            }
            if (radioButton2.Checked==true)
            {
                ca = "Erkek";

            }
            ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulüp.Text) , (string)ca);
            MessageBox.Show("Öğrenci eklendi.");

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSİl(byte.Parse(Txtid.Text));
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulüp.Text),(string)ca);
        }
    }
}
