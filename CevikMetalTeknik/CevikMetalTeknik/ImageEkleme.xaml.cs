using Android;
using Android.Content.PM;
using CevikMetalTeknik.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using ObjCRuntime;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageEkleme : ContentPage
    {

       
       




        public ImageEkleme()
        {
            InitializeComponent();

        }
        private MediaFile _mediaFile;







        private async void FileUploadClick(object sender,EventArgs e)
        {


            var file = await FilePicker.PickAsync(); // Dosya seçme işlemini gerçekleştirin
            if (file != null)
            {
                Page1 yourClass = new Page1();
                string result = await yourClass.UploadImage(file);
                await DisplayAlert("Sonuç", result, "OK");
            }





            //var file = await MediaPicker.PickPhotoAsync();
            //if (file == null)
            //    return;
            //var content = new MultipartFormDataContent();
            //content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);
            //var httpClient = new HttpClient();
            //string url = "https://localhost:44345/swagger/index.html";
            //httpClient.BaseAddress = new Uri(url);
            //var response = await httpClient.PostAsync("", content);






            //var content = new MultipartFormDataContent();

            //content.Add(new StreamContent(_mediaFile.GetStream()),
            //    "\"file\"",
            //    $"\"{_mediaFile.Path}\"");

            //var httpClient = new HttpClient();

            //var uploadServicBaseAdress = Constants.AdServicesLibrary;

            //var httpResponseMessage = await httpClient.PostAsync(uploadServicBaseAdress, content);


            //var file = await CrossMedia.Current.PickPhotoAsync();
            //if (file != null)
            //{
            //    var fileName = Path.GetFileName(file.Path);
            //    var destinationPath = Path.Combine("y:\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\"+fileName);
            //    //Directory.CreateDirectory(destinationPath);
            //    //var destinationFile = Path.Combine(destinationPath, fileName);
            //    File.Copy(file.Path, destinationPath, true);
            //}
            //else
            //{
            //    deneme.Text = "başarısız";
            //}










            //var file = await MediaPicker.PickPhotoAsync();
            //if (file == null)
            //    return;
            //var content = new MultipartFormDataContent();
            //content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);
            //var httpClient = new HttpClient();
            //string url = "https://localhost:44345/api/images";
            //httpClient.BaseAddress = new Uri(url);
            //var response = await httpClient.PostAsync("", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    deneme.Text = "başarılı";
            //}
            //else
            //{

            //    deneme.Text = "başarısız";
            //}



            //System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

            //////var file = await CrossMedia.Current.PickPhotoAsync(); 
            //////   string folderName =Path.GetFileName(file.Path);
            //////   string folderPath = Path.Combine("resimler" + folderName);


            //////   File.Copy(file.Path, folderPath, true);
            //string filePath = file.Path;
            //string fileName = Path.GetFileName(filePath);
            //string newFilePath = folderPath + "/" + fileName;



            //if (File.Exists(newFilePath))
            //{
            //    File.Delete(newFilePath);
            //}

            //File.Move(filePath, newFilePath);



            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == Permission.Granted)
            //{
            //    // Hedef klasöre erişim izni zaten var
            //    // Resmi kaydetme işlemine devam edin
            //}
            //else
            //{
            //    // Hedef klasöre erişim izni yok
            //    // Kullanıcıya izin isteği gösterin
            //    ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
            //}

            //var file = await CrossMedia.Current.PickPhotoAsync();
            // suan baktığım yer xamarin değil mi ? evet apiyi xamarine nasıl yapcağımı bilmiyorum denedim de olmadı bende tekrardan dosya üzerinden kaydetmeye alısıyrum web api bıraktım ama web api resim ekledim 



            // bak simdi mvc ile resim eklemek ile web api ile resim eklemeyi karıştırıyorsun gibi geliyor 
            // sen bana bir video gsterdin bi dk 




            //string folderPath = @"C:\Users\Fatih Kurt\Desktop\CevikMetalTeknikAndroid\CevikMetalTeknik\CevikMetalTeknik\CevikMetalTeknik\resimler";
            // string fileName = Path.GetFileName(file.Path);
            // string newFilePath = Path.Combine(folderPath, fileName);
            // File.Copy(file.Path, folderPath, true);




            //if (file != null)
            //{

            //    //byte[] fileBytes = File.ReadAllBytes(file.Path);
            //    //File.WriteAllBytes(newFilePath, fileBytes);
            //}

        }
    }
}
