//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SatisMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Televizyon
    {
        public Televizyon()
        {
            this.Urunlers = new HashSet<Urunler>();
        }
    
        public int tv_id { get; set; }
        public string tv_marka { get; set; }
        public string tv_model { get; set; }
        public string tv_ekran_boyut { get; set; }
        public string tv_cozunurluk { get; set; }
        public string tv_resim { get; set; }
    
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
