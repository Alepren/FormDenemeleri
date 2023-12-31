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
using System.Data.Common;

namespace OkulSistemi
{
    public partial class OgrenciNotlar : Form
    {
        public OgrenciNotlar()
        {
            InitializeComponent();
        }
        System.Data.SqlClient.SqlConnection bgl = new("Data Source=DESKTOP-EMFHEHV;Initial Catalog=OkulSistemi;Integrated Security=True;TrustServerCertificate=True");

        public string numara;
        private void OgrenciNotlar_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand commadn = new("Select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from TBL_DERSLER inner join TBL_NOTLAR on TBL_DERSLER.DERSID=TBL_NOTLAR.DERSID where OGRID=@p1", bgl);
            commadn.Parameters.AddWithValue("@p1", numara);
            System.Data.SqlClient.SqlDataAdapter dt= new(commadn);
            DataTable dataTable= new DataTable();
            dt.Fill(dataTable);
            dataGridView1.DataSource= dataTable;


            System.Data.SqlClient.SqlCommand command2 = new("Select OGRAD,OGRSOYAD from TBL_OGRENCI", bgl);
            bgl.Open();
            System.Data.SqlClient.SqlDataReader rd= command2.ExecuteReader();
            if(rd.Read() != null) {
                this.Text=rd[0].ToString()+ " " + rd[1].ToString();
            }

            bgl.Close();


            
            //this.Text = numara;
        }
    }
}
