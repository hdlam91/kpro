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
    
    public partial class XmlRule
    {
        public string RuleName { get; set; }
        public int RuleOrder { get; set; }
        public string RuleText { get; set; }
        public string Tag { get; set; }
        public byte PartnerID { get; set; }
    
        public virtual Partner Partner { get; set; }
        public virtual XmlTag XmlTag { get; set; }
    }
}
