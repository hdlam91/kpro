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
    
    public partial class vwProduktUtgivelse
    {
        public byte ProduktID { get; set; }
        public System.DateTime DatoUtgivelse { get; set; }
        public string Hovedordrenr { get; set; }
        public bool Aktiv { get; set; }
        public Nullable<short> Frist { get; set; }
        public Nullable<short> LåsStart { get; set; }
        public Nullable<short> LåsSlutt { get; set; }
        public Nullable<short> BookingFristStart { get; set; }
        public Nullable<short> BookingFristSlutt { get; set; }
        public Nullable<short> AntallSider { get; set; }
        public string Dokument { get; set; }
    }
}
