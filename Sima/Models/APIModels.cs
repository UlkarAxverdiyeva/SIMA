using SIMAAPI.Models.DataModel;
using SIMAAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sima.Models
{
    public class APIModels
    {
        public List<SimaModel> SIMA_NEWS_LIST { get; set; }
        public List<SimaFAQ> SIMA_FAQ_LIST { get; set; }
    }
}