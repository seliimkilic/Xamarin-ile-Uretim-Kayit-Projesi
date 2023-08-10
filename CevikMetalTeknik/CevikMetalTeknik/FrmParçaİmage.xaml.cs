using DocumentFormat.OpenXml.Bibliography;
using Google.Api.Ads.AdWords.v201809;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = Xamarin.Forms.Image;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmParçaİmage : ContentPage
    {

        public class Resim
        {

            public int resimid { get; set; }
            public string resimad { get; set; }

        }
        public FrmParçaİmage()
        {
            InitializeComponent();




            //string imagePath = "";
            //string con = @"Data Source=192.168.1.84; Initial Catalog=CevikTeknikMetal; User Id=fatih; Password=12477;  ";

            //using (SqlConnection connection = new SqlConnection(con))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand("SELECT resimadd FROM resim WHERE resimid=1", connection))
            //    {
            //        command.Parameters.AddWithValue("resimid", aaa.ToString());
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                imagePath = reader.GetString(reader.GetOrdinal("resimadd"));
            //            }
            //        }
            //    }
            //    Image image = new Image();
            //    image.Source = ImageSource.FromFile(imagePath);
            //    StackLayout stackLayout = new StackLayout();
            //    stackLayout.Children.Add(image);
            //}

            Getir();
            
        }


        public void   Getir()
        {
            

            string con = @"Data Source=192.168.1.84; Initial Catalog=CevikTeknikMetal; User Id=fatih; Password=12477;  ";
            using (SqlConnection bg = new SqlConnection(con))

                try
                {
                    List<Resim> resims = new List<Resim>();
                    bg.Open();
                    string queryString = " Select resimad From dbo.resim WHERE resimid=1";
                    SqlCommand command = new SqlCommand(queryString, bg);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        resims.Add(new Resim
                        {
                            resimad  = reader["resimad"].ToString(),
                            
                        }
                        );
                       
                    }

                    reader.Close();
                    bg.Close();
                   

                    //Image image = new Image();
                    //image.Source = ImageSource.FromFile("resimad");
                    //StackLayout stackLayout = new StackLayout();
                    //stackLayout.Children.Add(image);
                    //liste.ItemsSource = resims;

                }
                catch
                {

                }

            //string imagePath = "";
            ////int id = 1;
            //string con = @"Data Source=192.168.1.48; Initial Catalog=CevikTeknikMetal; User Id=fatih; Password=12477;  ";
            //using (SqlConnection bg = new SqlConnection(con))
            //{ 


            //        bg.Open();
            //        string queryString = " Select resimad From resim";
            //    using (SqlCommand command = new SqlCommand(queryString, bg))
            //    {

            //        //command.Parameters.AddWithValue( "@resim","1");
            //        using (SqlDataReader reader = command.ExecuteReader())
            //         {


            //            if (reader.Read())
            //        {

            //            imagePath = reader.GetString(reader.GetOrdinal("resimad"));

            //        }


            //        }

            //     }
            //        }    


            //        Image image = new Image();
            //        image.Source = ImageSource.FromFile(imagePath);
            //        StackLayout stackLayout = new StackLayout();
            //        stackLayout.Children.Add(image);


            //catch (Exception ex)
            //{
            //     App.Current.MainPage.DisplayAlert("uyarı", ex.Message, "tamam");
            //}





















            //try
            //{ // bütün connectionlarını actıktan sonra kapattığına emin olur musun tabi

            //    string imagePath = string.Empty;
            //    string con = @"Data Source=192.168.1.48; Initial Catalog=CevikTeknikMetal; User Id=fatih; Password=12477;  ";
            //    SqlConnection connection = new SqlConnection(con);
            //    if (connection.State == ConnectionState.Open)
            //    {
            //        connection.Close();
            //    }

            //    SqlCommand command = new SqlCommand("SELECT resimad FROM resim where resimid=1 ", connection); // bu kısmıla





            //    Resim resim = new Resim();
            //    //command.Parameters.AddWithValue("where resimid=1 and ", resim);
            //    //SqlDataReader reader = command.ExecuteReader())
            //    //  {
            //    //SqlDataReader reader = command.ExecuteReader();

            //  //  connection.Open();
            //    imagePath = "C://Users//Fatih Kurt//Desktop//CevikMetalTeknikAndroid//CevikMetalTeknik//CevikMetalTeknik//CevikMetalTeknik//resimler//indir.jpeg"; // amaç buydu

            //   //if (reader.Read())
            //   // {
            //   //     imagePath = reader.GetString(reader.GetOrdinal("resimad"));
            //   // } 

            //    //}
            //    // geliyorum

            //    Image image = new Image(); // bunu sen seç hangisi lazım bilmiyorum
            //    image.Source = ImageSource.FromFile(imagePath);


            //    Image embeddedImage = new Image
            //    {



            //};



            //    StackLayout stackLayout = new StackLayout();
            //    stackLayout.Children.Add(image);

            //}


            //catch (Exception e)
            //{
            //    throw (e);
            //}

        }



    }

}