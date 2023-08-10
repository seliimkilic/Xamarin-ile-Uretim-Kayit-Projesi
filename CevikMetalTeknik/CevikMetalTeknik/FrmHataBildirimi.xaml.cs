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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmHataBildirimi : ContentPage
    {
        private MediaFile _mediaFile;
        string direktori_lokal = "";
        string direktori_server = "";
        string name_file = "";
        private Stream stream;

        public FrmHataBildirimi()
        {
            InitializeComponent();

        }




















        private async void btnPickPhoto_Clicked(object sender, EventArgs e)
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
            resim.Source = ImageSource.FromStream(() =>

            {
                return _mediaFile.GetStream();
            }

                );


            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"",
                $"\"{_mediaFile.Path}\"");

                    var response = await httpClient.PostAsync(@"\\192.168.1.100\Havuz\TOPLANTI", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Resim başarıyla sunucuya yüklendi
                    }
                    else
                    {
                        // Hata oluştu
                    }
                }



                //await CrossMedia.Current.Initialize();
                //if (!CrossMedia.Current.IsPickPhotoSupported)
                //{
                //    await DisplayAlert("HATA", "Maalesef telefonunuz fotoğraf seçmeyi desteklemiyor", "TAMAM");
                //    return;
                //}
                //_mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { });
                //if (_mediaFile == null)
                //    return;
                //direktori_lokal = _mediaFile.Path;
                //name_file = Path.GetFileName(direktori_lokal);
                //_ = DisplayAlert("Dosya bilgisi", name_file, "TAMAM");
                //resim.Source = ImageSource.FromStream(() =>

                //{
                //    return _mediaFile.GetStream();
                //}

                //    );


                //////////////////////////////////////////////
                //

                ////var result = await MediaPicker.PickPhotoAsync();
                //if (result != null)
                //{
                //    var stream = await result.OpenReadAsync();
                //    // Resim dosyasının sunucuya yüklenmesi için stream'i kullanabilirsiniz
                //}
                //using (var httpClient = new HttpClient())
                //{
                //    using (var content = new MultipartFormDataContent())
                //    {
                //        content.Add(new StreamContent(stream), "file", "image.jpg");

                //        var response = await httpClient.PostAsync(@"\\192.168.1.100\Havuz\TOPLANTI", content);

                //        if (response.IsSuccessStatusCode)
                //        {
                //            // Resim başarıyla sunucuya yüklendi
                //        }
                //        else
                //        {
                //            // Hata oluştu
                //        }
                //    }
                //}







                ///////////////////////////////////////////////////////////////
                //await CrossMedia.Current.Initialize();
                //if (!CrossMedia.Current.IsPickPhotoSupported)
                //{
                //    await DisplayAlert("HATA", "Maalesef telefonunuz fotoğraf seçmeyi desteklemiyor", "TAMAM");
                //    return;
                //}
                //_mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { });
                //if (_mediaFile == null)
                //    return;
                //direktori_lokal = _mediaFile.Path;
                //name_file = Path.GetFileName(direktori_lokal);
                //_ = DisplayAlert("Dosya bilgisi", name_file, "TAMAM");
                //resim.Source = ImageSource.FromStream(() =>

                //{
                //    return _mediaFile.GetStream();
                //}

                //    );
                //var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { });
                //string filePath = file.Path;
                //string targetFolderPath = @"\\192.168.1.100\Havuz\TOPLANTI";
                ////string targetFolderPath = @"//192.168.1.100/Havuz/FIRMA MUM RESİMLERİ/UrunGorselleri";
                //string targetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(filePath));
                //File.Copy(filePath, targetFilePath, true);
                ///////////////////////////////////
                ///


                //// Galeriyi açmak için izin iste
                //if (await Permissions.CheckStatusAsync<Permissions.Photos>() != PermissionStatus.Granted)
                //{
                //    await Permissions.RequestAsync<Permissions.Photos>();
                //}

                //// Galeri aç
                //Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();

                //// Resmi kaydetmek için belirtilen metodu çağır
                //SaveImage(stream);

                ///////////////////////////////////////////////////////////
                //FileData fileData = await FilePicker.PickAsync();
                //string filePath = fileData.FilePath;
                /////////////////////////

                //var mediaPicker = await MediaPicker.CreateAsync();
                //var options = new MediaPickerOptions
                //{
                //    Title = "Select Image",
                //    ModalPresentationStyle = MediaPickerModalPresentationStyle.OverFullScreen
                //};
                //var file = await mediaPicker.PickPhotoAsync(options);
                //string filePath = file.FullPath;

                //////////////////////////////////////////////

                //var content = new MultipartFormDataContent();

                //content.Add(new StreamContent(_mediaFile.GetStream()),
                //    "\"file\"",
                //    $"\"{_mediaFile.Path}\"");

                //var httpClient = new HttpClient();

                //var uploadServicBaseAdress = Constants.UploadBaseAddress;

                //var httpResponseMessage = await httpClient.PostAsync(uploadServicBaseAdress, content);
                //////////////////////////
                //var photo = await MediaPicker.CapturePhotoAsync(mpo);
                //var photoFullPath = photo.FullPath;

                //Capture = photoFullPath;

                //var image = await Image.FromFileAsync(photoFullPath);
                //}
                //async void kaydet(object sender, EventArgs e)
                //{

                //MemoryStream stream = new MemoryStream();
                //using (FileStream fileStream = new FileStream((resim.Source as FileImageSource).File, FileMode.Open, FileAccess.Read))
                //{
                //    await fileStream.CopyToAsync(stream);
                //}
                //byte[] bytes = stream.ToArray();

                //string con = @"Data Source=192.168.1.39; Initial Catalog=CevikTeknikMetal; User Id=sa; Password=1234;";
                //using (SqlConnection bg = new SqlConnection(con))
                //{
                //    bg.Open();
                //          string a = "INSERT INTO dbo.img (ImagePath) VALUES (" + resim + ")";

                //    SqlCommand com = new SqlCommand(a, bg);
                //com.ExecuteNonQuery();
                //bg.Close();
                //}
                //string folderPath = @"C:\myFolder"; // Kaydedilecek klasörün yolu
                //string filePath = Path.Combine(folderPath, "myImage.jpg");

                //// Stream'i FileStream'e kopyala
                //using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                //{
                //    stream.CopyTo(fileStream);
                //}
                ///////////////////////

                //}




















                //private void SaveImage(Stream stream)
                //{
                //    string folderPath = @"C:\myFolder"; // Kaydedilecek klasörün yolu
                //    string filePath = Path.Combine(folderPath, "myImage.jpg");

                //    // Stream'i FileStream'e kopyala
                //    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                //    {
                //        stream.CopyTo(fileStream);
                //    }
                //}


                ///////////////////////////////////////////////////////









            }
            //public async Task<string> UploadPhotoAsync(MediaFile photo)
            //{
            //    var httpClient = new HttpClient();

            //    var content = new MultipartFormDataContent();
            //    content.Add(new StreamContent(photo.GetStream()), "\"file\"", $"\"{photo.Path}\"");

            //    var response = await httpClient.PostAsync(@"\\192.168.1.100\Havuz\TOPLANTI", content);

            //    var result = await response.Content.ReadAsStringAsync();

            //    return result;

            //}


        }
    }
}
