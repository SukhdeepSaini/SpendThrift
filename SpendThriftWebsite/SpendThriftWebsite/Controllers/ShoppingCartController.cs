using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using SpendThriftWebsite.Models.ShoppingCart;
using SpendThriftWebsite.ViewModels;

namespace SpendThriftWebsite.Controllers
{
    public class ShoppingCartController : Controller
    {
        STEntities context = new STEntities();

        public ActionResult Index()
        {
            var currentCustomer = TempData["CurrentUser"].ToString();
            var cart = ShoppingCart.GetCart(this.HttpContext, currentCustomer);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            TempData["CurrentUser"] = currentCustomer;
            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {
            var currentCustomer = TempData["CurrentUser"].ToString();
            // Retrieve the album from the database
            var addedProduct = context.Products
                               .Single(product => product.Product_ID == id);

            var cart = ShoppingCart.GetCart(this.HttpContext, currentCustomer);

            cart.AddToCart(addedProduct);

            TempData["CurrentUser"] = currentCustomer;
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            string currentCustomer;
            if (TempData.ContainsKey("CurrentUser"))
            {
                currentCustomer = TempData["CurrentUser"].ToString();
                var cart = ShoppingCart.GetCart(this.HttpContext, currentCustomer);
                ViewData["CartCount"] = cart.GetCount();
                TempData["CurrentUser"] = currentCustomer;
                return PartialView("CartSummary");
            }
            ViewData["CartCount"] = 0;
            return PartialView("CartSummary");
        }

    }
}
