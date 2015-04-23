using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;

namespace SpendThriftWebsite.Controllers
{
    public class StoreController : Controller
    {
        STEntities context = new STEntities();

        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult Browse(string category)
        {
            var model = context.Categories.Include("Products").Single(c => c.CategoryName == category);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = context.Products.FirstOrDefault(p => p.Product_ID == id);
            return View(model);
        }

    }
}
