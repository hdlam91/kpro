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
    
    public partial class Firma
    {
        public Firma()
        {
            this.FirmaBrukers = new HashSet<FirmaBruker>();
            this.FirmaHarProdukts = new HashSet<FirmaHarProdukt>();
        }
    
        public int FirmaID { get; set; }
        public string Firmanavn { get; set; }
        public string Adresse { get; set; }
        public string Postadresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
    
        public virtual ICollection<FirmaBruker> FirmaBrukers { get; set; }
        public virtual ICollection<FirmaHarProdukt> FirmaHarProdukts { get; set; }
    }
}
