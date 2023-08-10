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
    public partial class Anasayfa : ContentPage
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        async void Stok(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmStokListe());
        }
        async void Cari(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frmCari());
        }
        async void ope(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmOperasyonlist());
        }
        async void kisi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmKisilerList());
        }
        async void hata(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmHata());
        }
    }
}