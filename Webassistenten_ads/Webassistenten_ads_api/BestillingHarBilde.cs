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
    
    public partial class BestillingHarBilde
    {
        public long BestillingHarBildeId { get; set; }
        public long ProspektID { get; set; }
        public System.DateTime DatoBest { get; set; }
        public int ProduktID { get; set; }
        public long BildeID { get; set; }
        public string SourceFile { get; set; }
        public string DestFile { get; set; }
        public string Label { get; set; }
        public Nullable<bool> Dirty { get; set; }
        public Nullable<decimal> CropX { get; set; }
        public Nullable<decimal> CropY { get; set; }
        public Nullable<decimal> CropW { get; set; }
        public Nullable<decimal> CropH { get; set; }
        public Nullable<decimal> Rotate { get; set; }
        public Nullable<decimal> Scale { get; set; }
        public Nullable<decimal> PositionX { get; set; }
        public Nullable<decimal> PositionY { get; set; }
    
        public virtual Bilde Bilde { get; set; }
    }
}
