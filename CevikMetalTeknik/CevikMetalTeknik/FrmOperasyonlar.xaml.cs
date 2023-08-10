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
    public partial class FrmOperasyonlar : ContentPage
    {


        public class Operasyon
        {
            public int Operasyonid { get; set; }
            public string OperasyonKod { get; set; }
            public string OperasyonAd { get; set; }

        }


        public FrmOperasyonlar()
        {
            InitializeComponent();
            
        }


        private async void kaydet(object sender, EventArgs e)
        {

            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                { 
                
                bg.Open();
                
            using (SqlCommand command =new SqlCommand("INSERT INTO dbo.Operasyon VALUES( @OperasyonKod, @OperasyonAd)",bg))
            {
                  
                command.Parameters.Add(new SqlParameter("OperasyonAd", ad.Text));
                command.Parameters.Add(new SqlParameter("OperasyonKod", kod.Text));
                command.ExecuteNonQuery();
            }
            bg.Close();
                await App.Current.MainPage.DisplayAlert("uyarı", "Başarılı", "tamam");
            }
                catch(Exception ex)
                {
                await App.Current.MainPage.DisplayAlert("uyarı", "hatalı", "tamam");
            }


        }

    }
}