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
    
    public partial class Modul
    {
        public Modul()
        {
            this.ModulRessurs = new HashSet<ModulRessur>();
            this.ModulStandards = new HashSet<ModulStandard>();
            this.ProduktHarModuls = new HashSet<ProduktHarModul>();
            this.XmlTags = new HashSet<XmlTag>();
        }
    
        public int ModulID { get; set; }
        public string Modulnavn { get; set; }
        public string Modulkode { get; set; }
        public string Modulfilnavn { get; set; }
        public decimal Modulstørrelse { get; set; }
        public Nullable<int> Bredde { get; set; }
        public Nullable<int> Høyde { get; set; }
        public string Mål { get; set; }
        public byte Antallbilder { get; set; }
    
        public virtual ICollection<ModulRessur> ModulRessurs { get; set; }
        public virtual ICollection<ModulStandard> ModulStandards { get; set; }
        public virtual ICollection<ProduktHarModul> ProduktHarModuls { get; set; }
        public virtual ICollection<XmlTag> XmlTags { get; set; }
    }
}
