using CevikMetalTeknik.Planlama;
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
    public partial class yenianasayfa : ContentPage
    {
        public yenianasayfa()
        {
            InitializeComponent();
        }
        async void üretim(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmÜretim());
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frmveri());
        }
        async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmPlanlama());
        }
        async void hata(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageEkleme());
        }
        async void mesaj(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new denememesaj());
        }
    }
}