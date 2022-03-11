using SIMAAPI.Models.DataModel;
using SIMAAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMAAPI.Controllers
{
    public class GetNewsController : ApiController
    {
        public IHttpActionResult GetNews()
        {
            List<SimaModel> model = null;
            using (SimaEntities db = new SimaEntities())
            {
                db.Database.Connection.Open();
                model = db.SIMA_NEWS.Select(s => new SimaModel()
                {
                    ID = (int)s.ID,
                    NEWSTITLE = s.NEWS_TITLE,
                    NEWSCONTENT = s.NEWS_CONTENT,
                    ISARCHIVED = s.ISARCHIVED,
                    ISDELETED = s.ISDELETED,
                    DATEMODIFIED = (DateTime)s.DATEMODIFIED,
                    DATEPOSTED = (DateTime)s.DATEPOSTED,
                    IMG = s.IMG
                }).ToList<SimaModel>();
                return Ok(model);
            }

        }
    }
}
