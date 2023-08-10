using CevikMetalTeknik.Model;
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
    public partial class frmCari : ContentPage
    {

        public class Cari
        {

            public int Cariid { get; set; }
            public string CariAdi { get; set; }
            public int Parabirimiid { get; set; }
            public string CariKodu { get; set; }
            public string Cariislem { get; set; }
            public DateTime Cariislemtarih { get; set; }
        }

       







        public frmCari()
        {
            InitializeComponent();





            string con = @"Data Source=192.168.1.78; Initial Catalog=CevikTeknikMetal; User Id=sa; Password=1234;  ";
            //string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {
                    List<Cari> caris = new List<Cari>();
                    bg.Open();
                    string queryString = " Select * From dbo.Cari ";
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        caris.Add(new Cari
                        {
                            CariAdi = reader["CariAdi"].ToString(),
                            
                        }
                        );
                    }

                    reader.Close();
                    bg.Close();
                    getir.ItemsSource = caris;

                }
                catch
                {

                }














        }
        async void carii(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmCariEkle());
        }


        

        async void sec(object sender, SelectedItemChangedEventArgs e)
        {


            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new FrmDetay()
                {
                    BindingContext = e.SelectedItem as Note
                });
            }

        }
        //private void Sil(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var note = (Note)liste.SelectedItem;
        //        App.Database.SilNote(note);


        //    }
        //    catch
        //    {

        //    }

        //}
    }
}