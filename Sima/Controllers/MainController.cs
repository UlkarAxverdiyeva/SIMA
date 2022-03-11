using Sima.Models;
using SIMAAPI.Models;
using SIMAAPI.Models.DataModel;
using SIMAAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sima.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            APIModels apiModels = null;
            IEnumerable<SimaModel> news = null;
            IEnumerable<SimaFAQ> faq = null;
            using (HttpClient hc = new HttpClient())
            {
                try
                {
                    HttpResponseMessage webResponse = hc.GetAsync(ConfigurationManager.AppSettings["SimaAPI"].ToString()).Result;
                    news = webResponse.Content.ReadAsAsync<IEnumerable<SimaModel>>().Result.Where(s => s.ISARCHIVED == (('N').ToString()) && s.ISDELETED == (('N').ToString())).OrderBy(s => s.ID).ToList();
                    HttpResponseMessage webResponseFAQ = hc.GetAsync(ConfigurationManager.AppSettings["SimaFAQ_API"].ToString()).Result;
                    faq = webResponseFAQ.Content.ReadAsAsync<IEnumerable<SimaFAQ>>().Result.Where(s => s.ISARCHIVED == (('N').ToString()) && s.ISDELETED == (('N').ToString())).OrderBy(s => s.ID).ToList();
                    apiModels = new APIModels
                    {
                        SIMA_FAQ_LIST = (List<SimaFAQ>)faq,
                        SIMA_NEWS_LIST = (List<SimaModel>)news
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(apiModels);
        }

        public ActionResult News(int news_id)
        {
            IEnumerable<SimaModel> news = null;
            using (HttpClient hc = new HttpClient())
            {
                try
                {
                    HttpResponseMessage webResponse = hc.GetAsync(ConfigurationManager.AppSettings["SIMAAPI"].ToString()).Result;
                    news = webResponse.Content.ReadAsAsync<IEnumerable<SimaModel>>().Result.Where(s => (s.ISDELETED == ('N').ToString()) && (s.ISARCHIVED == ('N').ToString()) && (s.ID == news_id));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(news);
        }

        public ActionResult FAQ()
        {
            IEnumerable<SimaFAQ> faq = null;
            using (HttpClient hc = new HttpClient())
            {
                try
                {
                    HttpResponseMessage webResponse = hc.GetAsync(ConfigurationManager.AppSettings["SimaFAQ_API"].ToString()).Result;
                    faq = webResponse.Content.ReadAsAsync<IEnumerable<SimaFAQ>>().Result.Where(s => (s.ISDELETED == ('N').ToString()) && (s.ISARCHIVED == ('N').ToString())).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(faq);
        }
    }
}