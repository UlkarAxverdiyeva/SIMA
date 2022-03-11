using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMAAPI.Models.ViewModel
{
    public class SimaFAQ
    {
        public decimal ID { get; set; }
        public string QUESTION { get; set; }
        public System.DateTime CREATEDAT { get; set; }
        public System.DateTime MODIFIEDAT { get; set; }
        public string ANSWER { get; set; }
        public string ISDELETED { get; set; }
        public string ISARCHIVED { get; set; }
    }
}