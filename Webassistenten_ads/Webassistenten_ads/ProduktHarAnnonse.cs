//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webassistenten_ads
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProduktHarAnnonse
    {
        public int AnnonseID { get; set; }
        public byte ProduktID { get; set; }
        public Nullable<System.DateTime> DatoUtgivelse { get; set; }
        public int Kategori { get; set; }
        public int Bredde { get; set; }
        public int Høyde { get; set; }
        public string Filnavn { get; set; }
        public string Beskrivelse { get; set; }
        public bool Aktiv { get; set; }
        public bool Dirty { get; set; }
        public bool HasErrors { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Produkt Produkt { get; set; }
    }
}
