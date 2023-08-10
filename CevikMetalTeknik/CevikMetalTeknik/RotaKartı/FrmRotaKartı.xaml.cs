using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik.RotaKartı
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmRotaKartı : ContentPage
    {
        string con = @"Data Source=192.168.1.100; Initial Catalog=CevikMetal_2; User Id=Cevik; Password=Q!w2e3r4t5;";
        public double SecilenCRID;
        public double SecilenOPERASYONID;
        public double SecilenDETAYID;
        public double SecilenISEMRIID;
        public double SecilenSTOKID;
        public double SecilenKullanıcıID;
        public class bolum2
        {
            public string ISLEMKODU { get; set; }
            public double ID { get; set; }
        }
        public class ıd
        {

            public double ID { get; set; }
        }
        public class bolum
        {
            public double BOLUMID { get; set; }
            public string BolumAd { get; set; }
            public string ADSOYAD { get; set; }
            public double SPERSONELID { get; set; }
            public string ISLEMKODU { get; set; }
        }
        public class Cari
        {
            public double CRID { get; set; }
            public string CRISIM { get; set; }
            public string CRKOD { get; set; }
        }
        public class Stok
        {
            public double SSTOKID { get; set; }
            public string STOKADI { get; set; }
            public double SCARIID { get; set; }
        }
        public class zorunlu1
        {
            public double ID { get; set; }


        }
        public class isemri
        {
            public double ISEMRI_ID { get; set; }
        }
        public class yenisemri
        {
            public double ID { get; set; }
        }
        public FrmRotaKartı()
        {
            InitializeComponent();
            doldurisemri();
            dolduroperasyon();
            
        }
        private async void kaydet(object sender, EventArgs e)
        {
            using (SqlConnection bg = new SqlConnection(con))
                try
                {
                    Stok bolid = comboBoxstok.SelectedItem as Stok;
                    SecilenCRID = bolid.SSTOKID;
                    bolum bolid2 = comboBoxkullanıcı.SelectedItem as bolum;
                    SecilenKullanıcıID = bolid2.SPERSONELID;
                    bg.Open();
                    string a = "INSERT INTO dbo.mrp_isemri_uretim (ID, ISEMRI_ID, DETAYID, SSTOKID,  PERSONELID, SALKIMADT, URETILENADET,ISLEMKODU,KAYITDATE,BITTAR ) VALUES (  ( select MAX(ID)+1 from mrp_isemri_uretim) , " + double.Parse(comboBoxisemri.Text) + ",  " + double.Parse(comboBoxdetay.Text) + "," + SecilenSTOKID + "," + SecilenKullanıcıID + "," + double.Parse(sAdet.Text) + "," + double.Parse(uAdet.Text) + ",'" + comboBoxoperasyon.Text + "','" + dateTimePickerbasla.Date.ToString() + "','" + dateTimePickerbitis.Date.ToString() + "')";
                    SqlCommand com = new SqlCommand(a, bg);
                    com.ExecuteNonQuery();
                    bg.Close();
                    await App.Current.MainPage.DisplayAlert("uyarı", "Başarılı", "tamam");
                    await Navigation.PushAsync(new FrmRotaKartı());

                }

                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Hata Mesajı", "Lütfen Boş Bırakılan Alanları Doldurun", "tamam");
                }
        }
        private void doldurisemri()
        {
            try
            {

                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = "select distinct[ID] from mrp_isemri ";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<yenisemri> deneme = new List<yenisemri>();
                while (reader.Read())
                {
                    deneme.Add(new yenisemri
                    {

                        ID = double.Parse(reader["ID"].ToString()),


                    }
                    );
                }

                reader.Close();
                bg.Close();
                comboBoxisemri.ItemsSource = deneme;


            }




            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen aaİş Emri Seçin", ex.Message, "tamam");
            }

        }
        private void doldurcari()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                //string queryString = " select CRID,CRISIM from scari where  CRID='" + SecilenISEMRIID + "'";
                string queryString = " select scari.CRID,scari.CRISIM from scari inner join mrp_isemri on scari.CRID =mrp_isemri.FIRMAID where mrp_isemri.ID=" + SecilenISEMRIID;
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Cari> caris = new List<Cari>();

                while (reader.Read())
                {
                    caris.Add(new Cari
                    {


                        CRID = double.Parse(reader["CRID"].ToString()),
                        CRISIM = comboBoxcari.Text=  reader["CRISIM"].ToString(),

                    }
                    );
                }

                reader.Close();
                bg.Close();
                comboBoxcari.ItemsSource = caris;

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Cari Seçin", ex.Message, "tamam");
            }


        }
        private void doldurdetay()
        {
            try
            {

                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select DISTINCT(ID) from mrp_isemri_detay where ISEMRI_ID= " +SecilenISEMRIID;
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<zorunlu1> zorunlus = new List<zorunlu1>();
                while (reader.Read())
                {
                    zorunlus.Add(new zorunlu1
                    {


                        ID = double.Parse(reader["ID"].ToString()),


                    }
                    );
                }

                reader.Close();
                bg.Close();
                comboBoxdetay.ItemsSource = zorunlus;
            }



            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Detay Seçin", ex.Message, "tamam");
            }

        }
        private void doldurStok()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                //string queryString = " select STOKADI,SSTOKID from sstok where SSTOKID='" + SecilenDETAYID + "'";
                string queryString = " select sstok.SSTOKID,sstok.STOKADI from sstok inner join mrp_isemri_detay on sstok.SSTOKID =mrp_isemri_detay.SSTOKID where ID="+SecilenDETAYID;
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Stok> stok = new List<Stok>();
                while (reader.Read())
                {
                    stok.Add(new Stok
                    {


                        SSTOKID = double.Parse(reader["SSTOKID"].ToString()),
                        STOKADI = comboBoxstok.Text= reader["STOKADI"].ToString(),

                    }
                     );
                }

                reader.Close();
                bg.Close();

                comboBoxstok.ItemsSource = stok;
                
            }
            catch
            {

            }
        }
        private void dolduroperasyon()

        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                //string queryString = "select  DISTINCT (sb.BOLUM_ID )BOLUMID,pb.BolumAd from spersonel_bolumatama sb left join mrp_PersonelBolum pb  on  sb.BOLUM_ID =pb.PersonelBolumID inner join spersonel sp on sb.SPERSONEL_ID = sp.SPERSONELID  where  pb.PersonelBolumID is not null";
                //string queryString = "select ISLEMKODU from mrp_islem_kodu";
                string queryString = "select distinct(mrp_islem_kodu.ID),mrp_islem_kodu.ISLEMKODU from spersonel_bolumatama sb left join mrp_PersonelBolum pb  on sb.BOLUM_ID = pb.PersonelBolumID inner join spersonel sp on sb.SPERSONEL_ID = sp.SPERSONELID left join mrp_islem_kodu on pb.IslemKodu = mrp_islem_kodu.ISLEMKODU where mrp_islem_kodu.ISLEMKODU is not null";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<bolum2> bolums = new List<bolum2>();
                while (reader.Read())
                {
                    bolums.Add(new bolum2
                    {


                        ISLEMKODU = reader["ISLEMKODU"].ToString(),
                        ID = double.Parse(reader["ID"].ToString()),
                        

                    }
                     );
                }

                reader.Close();
                bg.Close();
                comboBoxoperasyon.ItemsSource = bolums;
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Operasyon Seçin", ex.Message, "tamam");
            }


        }
        private void doldurkullanıcı()

        {
            try
            {
                
                SqlConnection bg = new SqlConnection(con);
                bg.Open(); 
                string queryString = "select distinct(sp.ADSOYAD),sp.SPERSONELID from spersonel_bolumatama sb left join mrp_PersonelBolum pb  on sb.BOLUM_ID = pb.PersonelBolumID inner join spersonel sp on sb.SPERSONEL_ID = sp.SPERSONELID left join mrp_islem_kodu on pb.IslemKodu=mrp_islem_kodu.ISLEMKODU where mrp_islem_kodu.ID = " + SecilenOPERASYONID;
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<bolum> bolums = new List<bolum>();
                while (reader.Read())
                {
                    bolums.Add(new bolum
                    {


                        SPERSONELID = double.Parse(reader["SPERSONELID"].ToString()),
                        ADSOYAD = reader["ADSOYAD"].ToString(),

                    }
                     );
                }

                reader.Close();
                bg.Close();
                comboBoxkullanıcı.ItemsSource = bolums;
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Kullanıcı Seçin", ex.Message, "tamam");
            }

        }
        private void COMisemri(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = comboBoxisemri.SelectedItem;
                yenisemri zor = comboBoxisemri.SelectedItem as yenisemri;
                SecilenISEMRIID = zor.ID;
                doldurdetay();
                doldurcari();

                
            }
            catch
            {

            }

        }
        private void COMdetay(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = comboBoxdetay.SelectedItem;
                zorunlu1 detayid = comboBoxdetay.SelectedItem as zorunlu1;
                SecilenDETAYID = detayid.ID;

                doldurStok();
               
            }
            catch
            {

            }

        }
        private void COMoperasyon(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = comboBoxoperasyon.SelectedItem;
                bolum2 bolid = comboBoxoperasyon.SelectedItem as bolum2;
                SecilenOPERASYONID = bolid.ID;
                doldurkullanıcı();

                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select ID,ISLEMKODU from mrp_islem_kodu where mrp_islem_kodu.SALKIMGOSTER='1'";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<bolum2> a = new List<bolum2>();

                while (reader.Read())
                {
                    a.Add(new bolum2
                    {

                        ISLEMKODU = reader["ISLEMKODU"].ToString(),
                        ID = double.Parse(reader["ID"].ToString()),


                    }
                    );
                }

                var list = a.ToList();
                reader.Close();
                bg.Close();


                if (list.FirstOrDefault(x => x.ID == SecilenOPERASYONID) != null)
                {
                    checkbox1.IsVisible = true;
                    sad.IsVisible = true;
                    sAdet.IsVisible = true;
                }
                else
                {
                    checkbox1.IsVisible = false;
                    sad.IsVisible = false;
                    sAdet.IsVisible = false;
                }
            }
            catch
            {

            }

        }
        private void checkbox_IsCheckedChanged(object sender, Telerik.XamarinForms.Primitives.CheckBox.IsCheckedChangedEventArgs e)
        {
            try
            {
                if (checkbox.IsChecked == true)
                {
                    uAdet.IsEnabled = true;
                }
                else
                {
                    uAdet.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Üretim Adeti Girin", ex.Message, "tamam");
            }

        }
        private void checkbox_IsCheckedChanged1(object sender, Telerik.XamarinForms.Primitives.CheckBox.IsCheckedChangedEventArgs e)
        {
            try
            {
                if (checkbox1.IsChecked == true)
                {
                    sAdet.IsEnabled = true;
                }
                else
                {
                    sAdet.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Salkım Adet Girin", ex.Message, "tamam");
            }


        }
    }
}