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
    
    public partial class Tegning
    {
        public long TegningID { get; set; }
        public long OppdragID { get; set; }
        public string Tegningnavn { get; set; }
        public string Tegningtekst { get; set; }
        public Nullable<byte> Sortering { get; set; }
        public System.DateTime DatoReg { get; set; }
    }
}