using SpendThriftWebsite.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;

namespace SpendThriftWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerVm  customer)
        {
            var context = new STEntities();

            var checkExistingCustomer = context.CUSTOMERs.Any(c => c.USERNAME == customer.username && c.PASSWORD == customer.password);

            if(checkExistingCustomer)
            {
                TempData["CurrentUser"] = customer.username;

                return new HttpStatusCodeResult(HttpStatusCode.OK);            
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            
        }
    }
}
