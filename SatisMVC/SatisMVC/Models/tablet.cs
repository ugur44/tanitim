using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SatisMVC.Models
{
    public class Tablet
    {
        public int tablet_id { get; set; }
        public string tablet_marka { get; set; }
        public string tablet_model { get; set; }
        public string tablet_isletim_sistemi { get; set; }
        public string tablet_hafiza { get; set; }
        public string tablet_ekran_cozunurluk { get; set;}
        public string table_kamera { get; set; }
        public string tablet_bluetooth { get; set; }
        public string tablet_garanti { get; set; }
        public string tablet_resim { get; set; }


    }
}