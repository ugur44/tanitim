using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SatisMVC.Models
{
    public class Telefon
    {

        public int telefon_id { get; set; }
        public string telefon_marka { get; set; }
        public string telefon_model { get; set; }
        public string telefon_isletim_sistemi { get; set; }
        public string telefon_cozunurluk { get; set; }
        public string telefon_boyut { get; set; }
        public string telefon_arka_kamera { get; set; }
        
        public string telefon_on_kamera { get; set; }
        public string telefon_ram { get; set; }
        public string telefon_hafiza { get; set; }
        public string telefon_garanti { get; set; }
        public string telefon_resim { get; set; }

    }
}