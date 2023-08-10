using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmHata : ContentPage
    {


        private MediaFile _mediaFile;
        string direktori_lokal = "";
        string direktori_server = "";
        string name_file = "";


        public FrmHata()
        {
            InitializeComponent();
        }

        private async void btnPickPhoto_Clicked(object sender,EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("HATA", "Maalesef telefonunuz fotoğraf seçmeyi desteklemiyor", "TAMAM");
                return;
            }
            _mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { });
            if (_mediaFile == null)
                return;
            direktori_lokal = _mediaFile.Path;
            name_file = Path.GetFileName(direktori_lokal);
            _ = DisplayAlert("Dosya bilgisi", name_file, "TAMAM");
            image.Source = ImageSource.FromStream(() =>

            {
                return _mediaFile.GetStream();
            }

                );
        }



        private async void kaydet(object sender, EventArgs e)
        {
            //string imagefile = Path.GetFileName();
            
        }



       
                 
        










    }
}