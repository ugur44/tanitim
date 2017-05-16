using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SatisMVC.Models
{
    public class Fotograf_Makinesi
    {
        public int fotograf_id { get; set; }
        public string fotograf_marka { get; set; }
        public string fotograf_model { get; set; }
        
        public string fotograf_cozunurluk { get; set; }
        public string fotograf_boyut { get; set; }
       
        public string fotograf_garanti { get; set; }
        public string fotograf_resim { get; set; }

    }
}