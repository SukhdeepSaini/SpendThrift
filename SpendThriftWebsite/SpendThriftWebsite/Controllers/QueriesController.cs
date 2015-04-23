using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;

namespace SpendThriftWebsite.Controllers
{
    public class QueriesController : Controller
    {
        STEntities context = new STEntities();
        public ActionResult Index()
        {
            var feedbacks = context.Feedbacks;
            return View(feedbacks);
        }

    }
}
