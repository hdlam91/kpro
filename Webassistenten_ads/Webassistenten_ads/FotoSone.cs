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
    
    public partial class FotoSone
    {
        public FotoSone()
        {
            this.Fotooppdrags = new HashSet<Fotooppdrag>();
        }
    
        public byte FotoSoneID { get; set; }
        public byte StedID { get; set; }
        public string FotoSonenavn { get; set; }
        public string FotoSonenavnFork { get; set; }
        public int Pris { get; set; }
    
        public virtual ICollection<Fotooppdrag> Fotooppdrags { get; set; }
    }
}