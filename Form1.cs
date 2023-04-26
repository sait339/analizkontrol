using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analizkontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=HPSERVER\\ETA;Initial Catalog=ETA_MARKET_2023;user id=sa;password=eta_123456;");
        SqlConnection baglanti2 = new SqlConnection("Data Source=HPSERVER\\ETA;Initial Catalog=ETA_RAPORLAR;user id=sa;password=eta_123456 ");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            string tarih = "0";
            string alistop = "0", satistop = "0", topkar = "0", karyuzde = "0";
            SqlCommand raporal = new SqlCommand("SELECT *FROM SAIT_GUNLUKRAPOR", baglanti);
            SqlDataReader dr2 = raporal.ExecuteReader();
            if (dr2.Read())
            {
                tarih = dr2["TARIH"].ToString();
                alistop = dr2["ALISTOPLAM"].ToString();
                satistop = dr2["SATISTOPLAM"].ToString();
                topkar = dr2["TOPLAMKAR"].ToString();
                karyuzde = dr2["KARYUZDE"].ToString();
            }
            baglanti.Close();
            baglanti2.Close();
            baglanti2.Open();
            SqlCommand gunlukraporkayit = new SqlCommand("INSERT INTO GUNLUKRAPOR(gun_tarih,gun_kartutar,gun_cirotutar,gun_karyuzde) " +
                "values(" + tarih + "," + topkar + "," + satistop + "," + karyuzde + ")", baglanti2);
            gunlukraporkayit.ExecuteNonQuery();
            baglanti2.Close();
        }
    }
}
