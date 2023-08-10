using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.ExtendedProperties;
using SQLite ;

namespace CevikMetalTeknik.Model
{
    public class Note
    {
        public Note()
        {
          
        }
        
        [PrimaryKey,AutoIncrement]public int id { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public double Fiyat { get; set; }
        public DateTime islemtarihi { get; set; }
         public string resim { get; set; }

        //[PrimaryKey, AutoIncrement] public int opid { get; set; }
        //public string opkodu { get; set; }
        //public string opadı { get; set; }


    }
  
}
