using CevikMetalTeknik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmÜretimKaydı : ContentPage
    {
        public FrmÜretimKaydı()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                stok.ItemsSource = await App.Database.GetNotesAsync();
                cari.ItemsSource = await App.Database.GetNotesAsync();
            }
            catch
            {

            }
        }
        async void hata(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmHata());
        }
       
    }
}