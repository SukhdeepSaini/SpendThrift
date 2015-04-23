using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using SpendThriftWebsite.Models.Customer;
using System.Net;

namespace SpendThriftWebsite.Controllers
{
    public class ProfileController : JsonController
    {
        public ActionResult Index()
        {
            string currentUser = TempData["CurrentUser"].ToString();

            if(currentUser == null)
            {
                return null;
            }
            else
            {
                var context = new STEntities();
                var cust = context.CUSTOMERs.FirstOrDefault(c => c.USERNAME == currentUser);
                var address = cust.ADDRESS_BOOK.FirstOrDefault();
                var customer = new CustomerVm
                                {
                                    username = cust.USERNAME,
                                    firstName = cust.FIRSTNAME,
                                    lastName = cust.LASTNAME,
                                    dob = cust.DOB.ToString(),
                                    email = cust.EMAIL,
                                    phonenumber = cust.PHONE_NUMBER.ToString(),
                                    password = cust.PASSWORD,
                                    streetaddress = address.STREET_ADDRESS,
                                    apartment = address.APARTMENT,
                                    state = address.STATE,
                                    country = address.COUNTRY,
                                    zipcode = address.ZIPCODE
                                };

                TempData["CurrentUser"] = customer.username;
                var jsonCust = Json(customer, JsonRequestBehavior.AllowGet);
                return jsonCust;
            }
            
        }

        [HttpPost]
        public ActionResult Update(CustomerVm customer)
        {
            using(var context = new STEntities())
            {
                var existingCustomer = context.CUSTOMERs.FirstOrDefault(c => c.USERNAME == customer.username);
                var address = existingCustomer.ADDRESS_BOOK.First();
                if(existingCustomer != null)
                {
                    existingCustomer.FIRSTNAME = customer.firstName;
                    existingCustomer.LASTNAME = customer.lastName;
                    existingCustomer.DOB = Convert.ToDateTime(customer.dob);
                    existingCustomer.EMAIL = customer.email;
                    existingCustomer.PHONE_NUMBER = int.Parse(customer.phonenumber);
                    existingCustomer.PASSWORD = customer.password;
                    address.STREET_ADDRESS = customer.streetaddress;
                    address.APARTMENT = customer.apartment;
                    address.STATE = customer.state;
                    address.COUNTRY = customer.country;
                    address.ZIPCODE = customer.zipcode;
                    context.SaveChanges();

                    TempData["CurrentUser"] = customer.username;
                    return new HttpStatusCodeResult(HttpStatusCode.OK);  
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound); 
        }

    }
}
