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
    
    public partial class sp_HentOppdrag_Result
    {
        public long OppdragID { get; set; }
        public System.DateTime DatoReg { get; set; }
        public byte PartnerID { get; set; }
        public int BrukerID { get; set; }
        public Nullable<int> FotografID { get; set; }
        public byte StatusID { get; set; }
        public byte OppdragTypeID { get; set; }
        public string Oppdragsnr { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public string TilleggsInformasjon { get; set; }
        public string Kommentar { get; set; }
        public Nullable<System.DateTime> DatoBooking { get; set; }
        public Nullable<byte> FakturaOK { get; set; }
        public string Katalog { get; set; }
    }
}