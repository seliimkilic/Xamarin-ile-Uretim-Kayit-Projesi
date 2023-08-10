using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace CevikMetalTeknik
{
    public partial class MainPage : ContentPage
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public MainPage()
        {
            InitializeComponent();
        }


        async void giris(object sender, EventArgs e)
        {

            string user = userName.Text;
            string password = userPassword.Text;
            con = new SqlConnection (@"Data Source=192.168.1.62; Initial Catalog=CevikTeknikMetal; User Id=sa; Password=1234;");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * From Login where Kullanici='" + userName.Text + "'And Sifre='" + userPassword.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                await DisplayAlert("Giriş Mesajı", "Tebrikler Giriş Başarılı", "TAMAM");
               
                await Navigation.PushAsync(new yenianasayfa()); return;
            }
            else
            {
                await DisplayAlert("Giriş Mesajı", "Hatalı Kullanıcı Adı Veya Şifre", "TAMAM");
                return;
            }
            con.Close();
        }

    }
}
