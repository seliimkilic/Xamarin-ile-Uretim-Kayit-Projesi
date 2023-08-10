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
    public partial class FrmDetay : ContentPage
    {
        public FrmDetay()
        {
            InitializeComponent();
            //var note = new Note();
            //ad.Text = note.StokAdi;
            //kod.Text = note.StokKodu;
        }
        
        async void üretim(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmÜretimKaydı());
        }
        async void hata(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmHata());
        }
        async void parca(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmParçaİmage());
        }
    }
}