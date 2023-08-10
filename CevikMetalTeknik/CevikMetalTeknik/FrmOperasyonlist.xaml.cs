using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmOperasyonlist : ContentPage
    {
        public class Operasyon
        {
            public int Operasyonid { get; set; }
            public string OperasyonKod { get; set; }
            public string OperasyonAd { get; set; }

        }
        public FrmOperasyonlist()
        {
            InitializeComponent();

           
            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;  ";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {

                    List<Operasyon> operasyons = new List<Operasyon>();
                    bg.Open();
                    string queryString = " Select * From dbo.Operasyon ";
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        operasyons.Add(new Operasyon
                        {
                            OperasyonAd = reader["OperasyonAd"].ToString(),
                            OperasyonKod = reader["OperasyonKod"].ToString(),
                        }
                        );
                        }

                    reader.Close();
                    bg.Close();
                    getir.ItemsSource = operasyons;

                       }
                    catch
                   {

                   }
        }
        async void ekle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmOperasyonlar());
        }
    }
}