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
    
    public partial class FotoOppdragType
    {
        public FotoOppdragType()
        {
            this.Fotooppdrags = new HashSet<Fotooppdrag>();
        }
    
        public byte OppdragTypeID { get; set; }
        public string OppdragTypenavn { get; set; }
        public string OppdragTypenavnFork { get; set; }
        public Nullable<int> Pris { get; set; }
        public Nullable<int> PrisFoto { get; set; }
    
        public virtual ICollection<Fotooppdrag> Fotooppdrags { get; set; }
    }
}
