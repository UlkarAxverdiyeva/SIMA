using Sima.Models;
using SIMAAPI.Models.DataModel;
using SIMAAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Sima.Controllers
{
    public class AdminController : Controller
    {
        SimaEntities db = new SimaEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Check(Login login)
        {
            string Message = "Fail";
            IList<Authors> authors;
            try
            {
                using (HttpClient webClient = new HttpClient())
                {
                    HttpResponseMessage webResponse = webClient.GetAsync(ConfigurationManager.AppSettings["SimaAuthors"].ToString()).Result;
                    authors = webResponse.Content.ReadAsAsync<IEnumerable<Authors>>().Result.Where(s => s.EMAIL == login.EMAIL && s.PASSWORD == login.PASSWORD).ToList();
                    if (authors.Any())        // != null get error
                        Message = "Success";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json( Message, JsonRequestBehavior.AllowGet);
        }
    }
}