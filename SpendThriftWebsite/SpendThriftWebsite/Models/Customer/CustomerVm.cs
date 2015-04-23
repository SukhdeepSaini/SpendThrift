using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpendThriftWebsite.Models.Customer
{
    public class CustomerVm
    {
        [RequiredAttribute (ErrorMessage = ("Please Enter UserName")) ]
        public string username { get; set; }

        [RequiredAttribute(ErrorMessage = ("Please First UserName"))]
        public string firstName { get; set; }

        [RequiredAttribute(ErrorMessage = ("Please Last UserName"))]
        public string lastName { get; set; }

        [RequiredAttribute(ErrorMessage = ("Please Email"))]
        public string email { get; set; }

        [RequiredAttribute(ErrorMessage = ("Please Enter Password"))]
        public string  password { get; set; }

        public string dob { get; set; }
        public string phonenumber { get; set; }
        public string streetaddress { get; set; }
        public int apartment { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
    }
}