//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIMAAPI.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SIMA_NEWS
    {
        public decimal ID { get; set; }
        public string NEWS_TITLE { get; set; }
        public string NEWS_CONTENT { get; set; }
        public Nullable<System.DateTime> DATEPOSTED { get; set; }
        public Nullable<System.DateTime> DATEMODIFIED { get; set; }
        public string ISDELETED { get; set; }
        public string ISARCHIVED { get; set; }
        public string IMG { get; set; }
    }
}
