//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

////namespace CevikMetalTeknik
////{
////    [XamlCompilation(XamlCompilationOptions.Compile)]
////    public partial class FrmCariEkle : ContentPage
////    {
////        public FrmCariEkle()
////        {
////            InitializeComponent();
////        }

////        async void Kaydet(object sender, EventArgs e)
////        {
////            if (string.IsNullOrWhiteSpace(Ad.Text) || string.IsNullOrWhiteSpace(Kod.Text) )
////            {
////                await DisplayAlert("Uyarı", "Boş Değer Geçersiz", "Tamam");
////            }
////            else
////            {
////                YeniStokEkle();

////            }

////        }

////        async void YeniStokEkle()
////        {


////        //    await App.Database.yeniNote(new Model.Note
////        //    {
////        //        CariAdi = Ad.Text,
////        //        CariKodu = Kod.Text,
               

////        //    });
////        //    await Navigation.PopAsync();
////        //}
////    }
////}