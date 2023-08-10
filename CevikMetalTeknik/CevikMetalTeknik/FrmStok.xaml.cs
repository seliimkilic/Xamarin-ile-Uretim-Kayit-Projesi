using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevikMetalTeknik.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmStok : ContentPage
    {
        
        public FrmStok()
        {
            InitializeComponent();
        }
         async void Kaydet (object sender,EventArgs e)
        {
            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {

                    bg.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Stok VALUES( @StokAdi, @StokKodu)", bg))
                    {

                        command.Parameters.Add(new SqlParameter("StokAdi", Ad.Text));
                        command.Parameters.Add(new SqlParameter("StokKodu", Kod.Text));
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

       

        void Sil(object sender, EventArgs e)
        {

        }
    }
}