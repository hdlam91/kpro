//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webassistenten_ads_api
{
    using System;
    using System.Collections.Generic;
    
    public partial class InHouse_Bruker
    {
        public InHouse_Bruker()
        {
            this.Produkts = new HashSet<Produkt>();
        }
    
        public int BrukerID { get; set; }
        public string Brukernavn { get; set; }
        public string Passord { get; set; }
        public string Navn { get; set; }
    
        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}
