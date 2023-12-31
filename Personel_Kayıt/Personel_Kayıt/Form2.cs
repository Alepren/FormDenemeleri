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
using Microsoft.Data.SqlClient;

namespace Personel_Kayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EMFHEHV;Initial Catalog=muratY;Integrated Security=True;TrustServerCertificate=True;");

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from TblPersonel", con);
            SqlDataReader read=komut1.ExecuteReader();
            while (read.Read())
            {
                LblToplamPersonel.Text = read[0].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from TblPersonel where PerDurum=1 ", con);
            SqlDataReader read2=komut2.ExecuteReader();
            while (read2.Read())
            {
                LblEvliPersonel.Text = read2[0].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from TblPersonel where Perdurum=0", con);
            SqlDataReader read3 = komut3.ExecuteReader();
            while (read3.Read())
            {
                LblBekarPersonel.Text = read3[0].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) from TblPersonel", con);
            SqlDataReader read4 = komut4.ExecuteReader();
            while (read4.Read())
            {
                LblSehirSayisi.Text = read4[0].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) from TblPErsonel", con);
            SqlDataReader read5 = komut5.ExecuteReader();
            while (read5.Read())
            {
                LblToplamMaas.Text = read5[0].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from TblPErsonel", con);
            SqlDataReader read6 = komut6.ExecuteReader();
            while (read6.Read())
            {
                LblOrtalamaMaas.Text = read6[0].ToString();
            }
            con.Close();
        }
    }
}
