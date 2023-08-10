using CevikMetalTeknik.Data;
using CevikMetalTeknik.Model;
using SQLite;
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
    public partial class FrmStokListe : ContentPage
    {
        public class Stok
        {

            public int Stokid { get; set; }
            public string StokAdi { get; set; }
            
        }
        public FrmStokListe()
        {
            InitializeComponent();








            string con = @"Data Source=5.180.184.131\MSSQLSERVER2019; Initial Catalog=ceviktek_; User Id=ceviktek; Password=Q!w2e3r4t5;";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {
                    List<Stok> stoks = new List<Stok>();
                    bg.Open();
                    string queryString = " Select * From dbo.Stok ";
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        stoks.Add(new Stok
                        {
                            StokAdi = reader["StokAdi"].ToString(),

                        }
                        );
                    }

                    reader.Close();
                    bg.Close();
                    liste.ItemsSource = stoks;

                }
                catch
                {

                }






































        }
        async void Stokk(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmStok());
        }
        //protected override async void OnAppearing()
        //{
        //    try
        //    {
        //        base.OnAppearing();
            
        //       liste.ItemsSource= await App.Database.GetNotesAsync();
        //    }
        //    catch
        //    {

        //    }
        //}

        
        //private void Sil(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var note = (Note) liste.SelectedItem;
        //        App.Database.SilNote(note);
                
               
        //    }
        //    catch
        //    {

        //    }
            
        //}


      async void sec(object sender, SelectedItemChangedEventArgs e)
        {


            if (e.SelectedItem!=null)
            {
                await Navigation.PushAsync(new FrmDetay()
                    {
                    BindingContext=e.SelectedItem as Note
                });
            }

        }
      

    }
}