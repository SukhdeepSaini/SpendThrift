using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using SpendThriftWebsite.Models.Dashboard;

namespace SpendThriftWebsite.Controllers
{
    public class DashboardController : JsonController
    {
        STEntities context = new STEntities();

        public ActionResult Index()
        {
            var categoris = context.Categories.
                            Select( categorycount =>
                                    new 
                                    {
                                        categoryname = categorycount.CategoryName,
                                        products = categorycount.Products.Count()
                                    });

            Dashboard[] categorycounts = new Dashboard[categoris.Count()];

            int i = 0;
            foreach(var item in categoris)
            {
                var newDashboard = new Dashboard { categoryname = item.categoryname, productscount = item.products };
                categorycounts[i] = newDashboard;
                i++;
            }
            var jsonResult = Json(categorycounts, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

    }
}
