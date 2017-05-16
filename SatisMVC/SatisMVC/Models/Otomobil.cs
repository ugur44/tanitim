using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SatisMVC.Models
{
    public class Otomobil
    {
        public int otomobil_id { get; set; }
        public string otomobil_marka { get; set; }
        public string otomobil_model { get; set; }
        public string otomobil_yil { get; set; }
        public string otomobil_vites{ get; set; }
        public string otomobil_km { get; set; }
        public string otomobil_kasatipi { get; set; }

        public string otomobil_renk { get; set; }
        public string otomobil_motorgucu { get; set; }
        
        public string otomobil_resim { get; set; }
    }
}