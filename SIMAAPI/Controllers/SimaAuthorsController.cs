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
    public class SimaAuthorsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Authors()
        {
            IList<Authors> authors = null;
            using (SimaEntities db = new SimaEntities())
            {
                db.Database.Connection.Open();
                authors = db.SIMAAUTHORS.Select(c => new Authors()
                {
                    EMAIL = c.EMAIL,
                    PASSWORD = c.PASSWORD
                }).ToList<Authors>();
            }
            return Ok(authors);
        }
    }
}
