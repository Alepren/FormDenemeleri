using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // her projede nugetten  bir daha mı indiricem?

namespace HastanaYönetimveRandevu
{
    internal class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-EMFHEHV;Initial Catalog=HastaneProje;Integrated Security=True");//TrustServerCertificate=True;
            con.Open();
            return con;
        }
    }
}
