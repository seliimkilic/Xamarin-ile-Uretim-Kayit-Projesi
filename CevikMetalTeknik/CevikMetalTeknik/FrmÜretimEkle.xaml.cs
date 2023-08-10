using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmÜretimEkle : ContentPage
    {
        string con = @"Data Source=192.168.1.100; Initial Catalog=CevikMetal_2; User Id=Cevik; Password=Q!w2e3r4t5;";
        public double SecilenCRID;
        public string secilenkod;
        public double SecilenPERID;
        public double SecilenDetayID;
        public double SecilenStokID;
        public double SecilenOpID;
        public string SecilenCariKodu;
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
        public FrmÜretimEkle()
        {
            InitializeComponent();
            comboBoxisemri.IsEnabled = false;
            comboBoxdetay.IsEnabled = false;
            comboBoxstok.IsEnabled = false;
            MetodCari();
            dolduroperasyon();
            doldurisemri();
        }
        public void MetodCari()
        {
              if (comboBoxcari.SelectedItem==null)
            {
                doldurCariKod2();
                doldurCari2();
                comboBoxcari.Text = null;
                comboBoxcarikodu.Text = null;
                //comboBoxcari.IsEnabled
            }
            
                else
            {
                doldurcarikod();doldurcari();
            }
        }
        public void MetodStok()
        {
            if (comboBoxisemri.SelectedItem == null)
            {
                doldurismeri2();
                doldurdetay2();
                doldurStok2();
                comboBoxisemri.Text = null;
                comboBoxdetay.Text = null;
                comboBoxstok.Text = null;
            }

            else
            {
                doldurismeri2(); doldurdetay2(); doldurStok2();
            }
        }
       public void İsemriGüvenlik()

        {

            if (comboBoxcari.SelectedItem != null)
            {
                comboBoxisemri.IsEnabled = true;
            }
            

        }
        private void doldurCari2()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select CRID,ALICI,CRISIM from scari ";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Cari> caris = new List<Cari>();

                while (reader.Read())
                {
                    caris.Add(new Cari
                    {


                        CRID = double.Parse(reader["CRID"].ToString()),
                        CRISIM = comboBoxcari.Text = reader["CRISIM"].ToString(),

                    }
                    );
                }

                reader.Close();
                bg.Close();
                //cr.ItemsSource = caris;
                comboBoxcari.ItemsSource = caris;

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Cari Seçin", ex.Message, "tamam");
            }
        }
        private void doldurcari()
        {
            try
            { 
            SqlConnection bg = new SqlConnection(con);
            bg.Open();
                string queryString = " select CRID,ALICI,CRISIM from scari where ALICI='1' and PERSONEL='0' and CRKOD='" + SecilenCariKodu+"'";
                SqlCommand command = new SqlCommand(queryString, bg);
            SqlDataReader reader = command.ExecuteReader();
            List<Cari> caris = new List<Cari>();

            while (reader.Read())
            {
                caris.Add(new Cari
                {


                    CRID = double.Parse(reader["CRID"].ToString()),
                    CRISIM =comboBoxcari.Text= reader["CRISIM"].ToString(),

                }
                );
            }

            reader.Close();
            bg.Close();
            //cr.ItemsSource = caris;
            //comboBoxcari.ItemsSource = caris;

            }
            catch (Exception ex)
            {
                 App.Current.MainPage.DisplayAlert("Lütfen Cari Seçin", ex.Message, "tamam");
            }


        }
        private void doldurCariKod2()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select CRKOD from scari";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Cari> caris = new List<Cari>();

                while (reader.Read())
                {
                    caris.Add(new Cari
                    {


                        //CRID = double.Parse(reader["c"].ToString()),
                        CRKOD = comboBoxcarikodu.Text = reader["CRKOD"].ToString(),

                    }

                    );

                }

                reader.Close();
                bg.Close();

                comboBoxcarikodu.ItemsSource = caris;



            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Cari Kodu Seçin", ex.Message, "tamam");
            }
        }
        private void doldurcarikod()
        {




            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select CRKOD from scari where CRID="+SecilenCRID;
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Cari> caris = new List<Cari>();

                while (reader.Read())
                {
                    caris.Add(new Cari
                    {
                        

                        //CRID = double.Parse(reader["c"].ToString()),
                        CRKOD =comboBoxcarikodu.Text= reader["CRKOD"].ToString(),
                        
                    }
                    
                    );
                    
                }

                reader.Close();
                bg.Close();
                
                //comboBoxcarikodu.ItemsSource = caris;
               
               

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Cari Kodu Seçin", ex.Message, "tamam");
            }





        }
        private void doldurStok2()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select SSTOKID,STOKADI from sstok ";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<Stok> stok = new List<Stok>();
                while (reader.Read())
                {
                    stok.Add(new Stok
                    {


                        SSTOKID = double.Parse(reader["SSTOKID"].ToString()),
                        STOKADI = reader["STOKADI"].ToString(),

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
        private void doldurStok()
        {
            try
            {
                SqlConnection bg = new SqlConnection(con);
                bg.Open();

                string queryString = " select sstok.SSTOKID,sstok.STOKADI from sstok inner join mrp_isemri_detay on sstok.SSTOKID =mrp_isemri_detay.SSTOKID where ID=" + SecilenDetayID;
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
                //comboBoxstok.SelectedItem = SecilenCRID;
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
                    //BolumAd = reader["BolumAd"].ToString(),

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
 //string con = @"Data Source=192.168.1.58; Initial Catalog=CevikMetal_2; User Id=fatih; Password=1234;";
            SqlConnection bg = new SqlConnection(con);
            bg.Open();
            //string queryString = " select DISTINCT(sp.ADSOYAD),BOLUM_ID,sp.SPERSONELID from spersonel_bolumatama sb left join mrp_PersonelBolum pb  on  sb.BOLUM_ID =pb.PersonelBolumID inner join spersonel sp on sb.SPERSONEL_ID = sp.SPERSONELID  where BOLUMID=" +SecilenCRID;
            string queryString = "select distinct(sp.ADSOYAD),sp.SPERSONELID from spersonel_bolumatama sb left join mrp_PersonelBolum pb  on sb.BOLUM_ID = pb.PersonelBolumID inner join spersonel sp on sb.SPERSONEL_ID = sp.SPERSONELID left join mrp_islem_kodu on pb.IslemKodu=mrp_islem_kodu.ISLEMKODU where mrp_islem_kodu.ID = " + SecilenCRID;
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
        private void doldurisemri()
        {
            try
            {
              
            SqlConnection bg = new SqlConnection(con);
            bg.Open();
            string queryString = "select distinct[ID] from mrp_isemri where FIRMAID="+SecilenCRID;
            SqlCommand command = new SqlCommand(queryString, bg);
            SqlDataReader reader = command.ExecuteReader();
            List<zorunlu1> deneme = new List<zorunlu1>();
            while (reader.Read())
            {
                deneme.Add(new zorunlu1
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
        private void doldurismeri2()
        {
            try
            {

                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                //string queryString = " select DISTINCT(ID) from mrp_isemri_detay where ISEMRI_ID = " + SecilenCRID;
                string queryString = " select DISTINCT(ISEMRI_ID) from mrp_isemri_detay ";
                SqlCommand command = new SqlCommand(queryString, bg);
                SqlDataReader reader = command.ExecuteReader();
                List<isemri> deneme = new List<isemri>();
                while (reader.Read())
                {
                    deneme.Add(new isemri
                    {


                       ISEMRI_ID = double.Parse(reader["ISEMRI_ID"].ToString()),


                    }
                    );
                }

                reader.Close();
                bg.Close();
                comboBoxisemri.ItemsSource = deneme;
            }



            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Lütfen Detay Seçin", ex.Message, "tamam");
            }
        }
        private void doldurdetay()
        {
            try
            {

            SqlConnection bg = new SqlConnection(con);
            bg.Open();
            //string queryString = " select DISTINCT(ID) from mrp_isemri_detay where ISEMRI_ID = " + SecilenCRID;
            string queryString = " select DISTINCT(ID) from mrp_isemri_detay where ISEMRI_ID="  + SecilenCRID;
            SqlCommand command = new SqlCommand(queryString, bg);
            SqlDataReader reader = command.ExecuteReader();
            List<zorunlu1> zorunlus = new List<zorunlu1>();
            while (reader.Read())
            {
                zorunlus.Add(new zorunlu1
                {


                    ID = double.Parse( reader["ID"].ToString()),


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
        private void doldurdetay2()
        {
            try
            {
                //string con = @"Data Source=192.168.1.58; Initial Catalog=CevikMetal_2; User Id=fatih; Password=1234;";
                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string queryString = " select DISTINCT(ID) from mrp_isemri_detay ";
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
        private void comboBox_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
                
            var selectedItem = comboBoxcari.SelectedItem;
            Cari crid = comboBoxcari.SelectedItem as Cari;
            SecilenCRID = crid.CRID;
            
            doldurcarikod();
            doldurisemri();

            if(comboBoxcari.SelectedItem!=null)
                {
                    comboBoxisemri.IsEnabled = true;
                }
                
            }
            catch
            {

            }
            
        }
        private void comboBoxDetay_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
            var selectedItem = comboBoxdetay.SelectedItem;
            zorunlu1 detayid = comboBoxdetay.SelectedItem as zorunlu1;
            SecilenDetayID = detayid.ID;

            doldurStok();
           if(comboBoxdetay.SelectedItem!=null)
                {
                    comboBoxstok.IsEnabled = true;
                }
            }
            catch
            {

            }
            
        }
        private void comboBoxStok_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            //try
            //{
            //var selectedItem = comboBoxstok.SelectedItem;
            //Stok stid = comboBoxstok.SelectedItem as Stok;
            //SecilenStokID = stid.SSTOKID;
            //doldurisemri();
            //doldurdetay();
            //}
            //catch
            //{

            //}
            
        }
        private void comboBoxoperasyon_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)

        {
            try
            {
            var selectedItem = comboBoxoperasyon.SelectedItem;
            bolum2 bolid = comboBoxoperasyon.SelectedItem as bolum2;
            SecilenCRID =bolid.ID;
            doldurkullanıcı();

               

                SqlConnection bg = new SqlConnection(con);
                bg.Open();
                string  queryString = " select ID,ISLEMKODU from mrp_islem_kodu where mrp_islem_kodu.SALKIMGOSTER='1'";
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


                if (list.FirstOrDefault(x=> x.ID==SecilenCRID)!=null)
                {
                    sAdet.IsVisible = true;
                    sad.IsVisible = true;
                    checkbox1.IsVisible = true;
                }
              else
                {
                    sAdet.IsVisible = false;
                    sad.IsVisible = false;
                    checkbox1.IsVisible = false;
                }
            }
             catch
            {

            }
        }
        private async void kaydet(object sender, EventArgs e)
        {

            
            
            using (SqlConnection bg = new SqlConnection(con))
                try
                {
            Stok bolid = comboBoxstok.SelectedItem as Stok;
            SecilenCRID = bolid.SSTOKID;
            bolum bolid2 = comboBoxkullanıcı.SelectedItem as bolum;
            SecilenPERID = bolid2.SPERSONELID;
                    bg.Open();
                    string a = "INSERT INTO dbo.mrp_isemri_uretim (ID, ISEMRI_ID, DETAYID, SSTOKID,  PERSONELID, SALKIMADT, URETILENADET,ISLEMKODU,KAYITDATE,BITTAR ) VALUES (  ( select MAX(ID)+1 from mrp_isemri_uretim) , " + double.Parse(comboBoxisemri.Text) + ",  "+ double.Parse(comboBoxdetay.Text) + ","+ SecilenCRID + ","+ SecilenPERID + ","+ double.Parse(sAdet.Text) + ","+ double.Parse(uAdet.Text) + ",'"+ comboBoxoperasyon.Text +"','"+ dateTimePickerbasla.Date.ToString()+ "','" + dateTimePickerbitis.Date.ToString() + "')";
                    SqlCommand com = new SqlCommand(a,bg);
                    com.ExecuteNonQuery();
                    bg.Close();
                    await App.Current.MainPage.DisplayAlert("uyarı", "Başarılı", "tamam");
                    await Navigation.PushAsync(new FrmÜretimEkle());

                }

                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Hata Mesajı", "Lütfen Boş Bırakılan Alanları Doldurun", "tamam");
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
        private void comboBoxisemri_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = comboBoxisemri.SelectedItem;
                zorunlu1 zor = comboBoxisemri.SelectedItem as zorunlu1;
                SecilenCRID = zor.ID;
                doldurdetay();
                if(comboBoxisemri.SelectedItem!=null)
                {
                    comboBoxdetay.IsEnabled = true;
                }
                

                //doldurStok();
            }
            catch
            {

            }

        }
        private void comboBoxCariKodu_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
        {
            try
            {
var selectedItem = comboBoxcarikodu.SelectedItem;
            Cari crm = comboBoxcarikodu.SelectedItem as Cari;
            SecilenCariKodu = crm.CRKOD;
            doldurcari();
            }
            catch
            { }
            
        }



      //  public void  denemeler()
      //  {
      //   //private void opSelectedIndexChanged(object sender, EventArgs e)
      //  //{
      //  //    Picker picker = sender as Picker;
      //  //    var selectedItem = picker.SelectedItem;
      //  //    bolum bolid = ope.SelectedItem as bolum;
      //  //    SecilenCRID = bolid.BOLUMID;
      //  //    doldurkullanıcı();

      //  //}



      //    //private void comboBoxdetay_SelectionChanged(object sender, Telerik.XamarinForms.Input.ComboBoxSelectionChangedEventArgs e)
      //   //{
      //  //    try
      //  //    {
      //  //        var selectedItem = comboBoxdetay.SelectedItem;
      //  //        zorunlu1 dene = comboBoxdetay.SelectedItem as zorunlu1;
      //  //        SecilenDetayID = dene.ID;
      //  //        doldurcari();
      //  //    }
      //  //    catch
      //  //    {

      //  //    }
      //  //}


      //    //private void deneme(object sender, TextChangedEventArgs e)
      //  //{
      //  //    List<Cari> caris = new List<Cari>();
      //  //    //cr.ItemsSource =(System.Collections.IList)caris.Where(s => s.CRISIM.StartsWith(e.NewTextValue));
      //  //    var kalvye = denme.Text;
      //  //    var deneme = caris.Where(x => x.CRISIM.Contains(kalvye.ToLower()));
      //  //    cr.ItemsSource = (System.Collections.IList)deneme;
      //  //}



      //   //private void fatih_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
      //  //{

      //  //}


      // //private void fatih_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
      //  //{

      //  //}


      ////private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
      //  //{
      //  //    Picker picker = sender as Picker;
      //  //    var selectedItem = picker.SelectedItem;
      //  //    Cari crid = cr.SelectedItem as Cari;
      //  //    SecilenCRID = crid.CRID;
      //  //    doldurStok();

      //  //}
      //  }


  



        }

}