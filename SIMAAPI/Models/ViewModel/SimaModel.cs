using SIMAAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMAAPI.Models.ViewModel
{
    public class SimaModel
    {
        [Key]
        public int ID { get; set; }
        public string NEWSTITLE { get; set; }
        public string NEWSCONTENT { get; set; }
        public string ISDELETED { get; set; }
        public string ISARCHIVED { get; set; }
        public string IMG { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATEPOSTED { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATEMODIFIED { get; set; }
        public SimaModel SIMA_NEWS_List { get; set; }
        public SimaFAQ SIMA_FAQ_List { get; set; }
    }
}