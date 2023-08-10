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
    public partial class Frmkisiekle : ContentPage
    {


        public class Kisi
        {
            public int Kisiid { get; set; }
            public string KisiAd { get; set; }
            public string KisiTc { get; set; }
            public string KisiCep { get; set; }
            public string KisiSGK { get; set; }
            public string KisiAdres { get; set; }

            public string Operasyonad { get; set; }

        }

       public class Operasyon
        {
            public int Operasyonid { get; set; }
            public string OperasyonKod { get; set; }
            public string OperasyonAd { get; set; }
        }
        // burda görmem lazım aslında orası ana menüde olması lazım //hata veren yere try atsana kapanmadan bakalım
        public Frmkisiekle()
        {
            InitializeComponent();
            doldur();
        }
        private async void kaydet(object sender, EventArgs e)
        {

            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {

                    bg.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Kisi VALUES( @KisiAd , @KisiTc , @KisiCep , @KisiSGK , @KisiAdres, @Operasyonad)", bg))
                    {

                        command.Parameters.Add(new SqlParameter("KisiAd", ad.Text));
                        command.Parameters.Add(new SqlParameter("KisiTc", tc.Text));
                        command.Parameters.Add(new SqlParameter("KisiCep", cep.Text));
                        command.Parameters.Add(new SqlParameter("KisiSGK", sgk.Text));
                        command.Parameters.Add(new SqlParameter("KisiAdres", adres.Text));
                        command.Parameters.Add(new SqlParameter("Operasyonad",op.SelectedItem.ToString()));
                        command.ExecuteNonQuery();
                    }
                    bg.Close();
                    await App.Current.MainPage.DisplayAlert("uyarı", "Başarılı", "tamam");
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("uyarı", ex.Message, "tamam");
                }

           
            
        }
        private void doldur()
        {
            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            SqlConnection bg = new SqlConnection(con);
                bg.Open();

                    string queryString = " Select OperasyonAd From dbo.Operasyon "; 
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Operasyon> operasyons = new List<Operasyon>();
                    while (reader.Read())
                    {

                operasyons.Add(new Operasyon
                {
                    OperasyonAd = reader["OperasyonAd"].ToString(),

                }
                         );



            }

                    reader.Close();
                    bg.Close();
                    op.ItemsSource = operasyons;
            

               
                
        }
    }
}