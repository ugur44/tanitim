using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SatisMVC.Models
{
    public class Bilgisayar
    {
        public int bilgisayar_id { get; set; }
        public string bilgisayar_marka { get; set; }
        public string bilgisayar_model { get; set; }
        public Nullable<int> bilgisayar_ram { get; set; }
        public Nullable<double> bilgisayar_boyut { get; set; }
        public Nullable<int> bilgisayar_hafiza { get; set; }
        public string bilgisayar_isletim_sistemi { get; set; }
        public string bilgisayar_ekrankarti_model { get; set; }
        public Nullable<int> bilgisayar_ekrankarti_boyut { get; set; }
        public Nullable<int> bilgisayar_garanti { get; set; }
        public string bilgisayar_resim { get; set; }
    }
}