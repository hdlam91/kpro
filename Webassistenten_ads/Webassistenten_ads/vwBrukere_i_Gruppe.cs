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
    
    public partial class vwBrukere_i_Gruppe
    {
        public int BrukerID { get; set; }
        public byte RolleID { get; set; }
        public byte PartnerID { get; set; }
        public byte AvdelingID { get; set; }
        public string LangID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Initialer { get; set; }
        public string Tittel { get; set; }
        public string Epost { get; set; }
        public string Passord { get; set; }
        public string Telefon { get; set; }
        public string Bildefil { get; set; }
        public string Mobil { get; set; }
        public Nullable<byte> Sortering { get; set; }
        public Nullable<bool> Aktiv { get; set; }
        public Nullable<bool> Leverandør { get; set; }
        public Nullable<bool> Nyhetsskriv { get; set; }
        public Nullable<int> Gruppe { get; set; }
    }
}
