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
    public partial class FrmKisilerList : ContentPage
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
        public FrmKisilerList()
        {
            InitializeComponent();



            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {
                    List<Kisi> kisis = new List<Kisi>();
                    bg.Open();
                    string queryString = " Select * From dbo.kisi ";
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        kisis.Add(new Kisi
                        {
                            KisiAd = reader["KisiAd"].ToString(),

                        }
                        );
                    }

                    reader.Close();
                    bg.Close();
                    a.ItemsSource = kisis;

                }
                catch
                {

                }
        }

        async void kisi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Frmkisiekle());
        }
    }
}