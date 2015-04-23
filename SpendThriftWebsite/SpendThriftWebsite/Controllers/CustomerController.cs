using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using System.Net;

namespace SpendThriftWebsite.Controllers
{
    public class CustomerController : Controller
    {
        STEntities context = new STEntities();
        public ActionResult Index()
        {
            var customers = context.CUSTOMERs;
            return View(customers);
        }

        public ActionResult Edit(string username)
        {
            var customer = context.CUSTOMERs.First(c => c.USERNAME == username);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CUSTOMER customer)
        {
            if(ModelState.IsValid)
            {
                var existingCustomer = context.CUSTOMERs.First(c => c.USERNAME == customer.USERNAME);
                existingCustomer.USERNAME = customer.USERNAME;
                existingCustomer.FIRSTNAME = customer.FIRSTNAME;
                existingCustomer.LASTNAME = customer.LASTNAME;
                existingCustomer.DOB = customer.DOB;
                existingCustomer.PHONE_NUMBER = customer.PHONE_NUMBER;
                existingCustomer.EMAIL = customer.EMAIL;
                existingCustomer.PASSWORD = customer.PASSWORD;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
        }

        public ActionResult Delete(string username)
        {
            var customer = context.CUSTOMERs.First(c => c.USERNAME == username);
            return View(customer);
        }

        public ActionResult DeleteCustomer(string username)
        {
            return View();
        }
    }
}
