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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DataSet1TableAdapters.TBL_DERSLERTableAdapter ds = new DataSet1TableAdapters.TBL_DERSLERTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource= ds.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersEkle(TxtKulupAd.Text);
            dataGridView1.DataSource = ds.DersListesi();

            MessageBox.Show("Ders eklendi");

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtKulupAd.Text));
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(TxtKulupAd.Text, byte.Parse(TxtKlupid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKlupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
