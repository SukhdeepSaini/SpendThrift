using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using System.Net;

namespace SpendThriftWebsite.Controllers
{
    public class FeedbackController : Controller
    {
        STEntities context = new STEntities();

        [HttpPost]
        public ActionResult Save(Feedback feedback)
        {

            if(feedback != null)
            {
                context.Feedbacks.Add(feedback);
                context.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK); 
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
        }

    }
}
