using SpendThriftModel;
using SpendThriftWebsite.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SpendThriftWebsite.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Save(CustomerVm customer)
        {
            var context = new STEntities();

            //check if there is any existing customer with the given username
            var existingUserName = context.CUSTOMERs.Any(c => c.USERNAME == customer.username);

            if(existingUserName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable); 
            }
            else
            {
                var newCustomer = new CUSTOMER
                {
                    USERNAME = customer.username,
                    FIRSTNAME = customer.firstName,
                    LASTNAME = customer.lastName,
                    DOB = Convert.ToDateTime(customer.dob),
                    EMAIL = customer.email,
                    PHONE_NUMBER = int.Parse(customer.phonenumber),
                    PASSWORD = customer.password
                };

                var newAddress = new ADDRESS_BOOK
                {
                    STREET_ADDRESS = customer.streetaddress,
                    APARTMENT = customer.apartment,
                    STATE = customer.state,
                    COUNTRY = customer.country,
                    ZIPCODE = customer.zipcode
                };

                context.CUSTOMERs.Add(newCustomer);  // ADD CUSTOMER TO DATABASE
                newCustomer.ADDRESS_BOOK.Add(newAddress); //ADD ITS ADDRESS TO DATABASE
                context.SaveChanges();

                return new HttpStatusCodeResult(HttpStatusCode.OK); 
            }
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
