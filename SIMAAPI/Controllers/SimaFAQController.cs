using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIMAAPI.Models.DataModel;
using SIMAAPI.Models.ViewModel;

namespace SIMAAPI.Controllers
{
    public class SimaFAQController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SimaFAQ()
        {
            List<SimaFAQ> faq = null;

            using(SimaEntities db = new SimaEntities())
            {
                db.Database.Connection.Open();
                faq = db.SIMA_FAQ.Select(s => new SimaFAQ()
                {
                    ID = (int)s.ID,
                    QUESTION = s.QUESTION,
                    ANSWER = s.ANSWER,
                    ISARCHIVED = s.ISDELETED,
                    ISDELETED = s.ISDELETED
                }).ToList<SimaFAQ>();
            }
            return Ok(faq);
        }
    }
}
