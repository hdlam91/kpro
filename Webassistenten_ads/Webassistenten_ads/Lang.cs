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
    
    public partial class Lang
    {
        public Lang()
        {
            this.StatiskTeksts = new HashSet<StatiskTekst>();
        }
    
        public string LangID { get; set; }
        public string LanguageName { get; set; }
    
        public virtual ICollection<StatiskTekst> StatiskTeksts { get; set; }
    }
}
