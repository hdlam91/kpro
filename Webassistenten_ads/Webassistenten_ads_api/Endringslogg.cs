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
    
    public partial class Endringslogg
    {
        public long LoggID { get; set; }
        public Nullable<System.DateTime> DatoReg { get; set; }
        public Nullable<long> ProspektID { get; set; }
        public string Beskrivelse { get; set; }
        public string VerdiGml { get; set; }
        public string VerdiNy { get; set; }
        public Nullable<bool> Endret { get; set; }
    }
}