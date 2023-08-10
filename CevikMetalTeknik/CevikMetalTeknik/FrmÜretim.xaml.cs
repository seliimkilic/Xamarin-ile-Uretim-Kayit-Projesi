using CevikMetalTeknik.RotaKartı;
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
    public partial class FrmÜretim : ContentPage
    {
        public FrmÜretim()
        {
            InitializeComponent();
            
        }
        async void fırma(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmÜretimEkle());
        }
        async void rota(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmRotaKartı());
        }
        async void barkod(object sender, EventArgs e)
        {
            await DisplayAlert("HATA", "Malesef Yapım Aşamasında", "TAMAM");
            return;
        }
    }
}