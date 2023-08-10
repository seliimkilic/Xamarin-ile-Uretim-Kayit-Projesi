using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik.Image
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        public async Task<string> UploadImage(FileResult imageFile)
        {
            try
            {
                if (imageFile == null)
                {
                    return "Invalid image file.";
                }

                // Resim dosyasını kaydetmek istediğiniz klasör yolunu belirtin
                string uploadPath = "Y:/Fatih";

                // Eşsiz bir dosya adı oluşturun
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                // Klasör yolunu ve dosya adını birleştirin
                string filePath = Path.Combine(uploadPath, fileName);

                // Resim dosyasını kaydedin
                using (var stream = await imageFile.OpenReadAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }

                return "Başarıyla yüklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata oluştu: {ex.Message}";
            }
        }
    }
}