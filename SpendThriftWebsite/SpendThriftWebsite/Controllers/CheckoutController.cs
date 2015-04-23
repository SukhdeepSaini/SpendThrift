using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using SpendThriftWebsite.Models.ShoppingCart;

namespace SpendThriftWebsite.Controllers
{
    public class CheckoutController : Controller
    {
        STEntities context = new STEntities();
        public ActionResult AddressAndPayment()
        {
            var currentCustomer = TempData["CurrentUser"].ToString();
            var customer = context.CUSTOMERs.FirstOrDefault(c => c.USERNAME == currentCustomer);
            var address = context.ADDRESS_BOOK.FirstOrDefault(c => c.CUSTOMER == currentCustomer);
            var cart = ShoppingCart.GetCart(this.HttpContext, currentCustomer);

            var newOrder = new Order
                            {
                                CustUsername = currentCustomer,
                                CustomerName = customer.FIRSTNAME + " " + customer.LASTNAME,
                                Street_Address = address.STREET_ADDRESS,
                                Apartment = address.APARTMENT,
                                State = address.STATE,
                                Country = address.COUNTRY,
                                ZipCode = address.ZIPCODE,
                                OrderStatus = "Finalized"
                            };

            var cartItems = cart.GetCartItems();

            foreach (var item in cartItems)
            {
                var orderProduct = new OrderProduct
                                    {
                                        ProductsID = item.ProductID,
                                        ProductName = item.Product.Name,
                                        ProductPrice = item.Product.Price,
                                        ProductQuantity = item.ProductCount
                                    };

                newOrder.OrderProducts.Add(orderProduct);
            }

            TempData["NewOrder"] = newOrder;
            TempData["CurrentUser"] = currentCustomer;
            return View(newOrder);
        }


        public ActionResult BillingInformation()
        {
            var currentUser = TempData["CurrentUser"].ToString();
            var newBillingInformation = new BillingInformation
                                        {
                                            CustUserName = currentUser
                                        };

            TempData["CurrentUser"] = currentUser;
            return View(newBillingInformation);
        }


        [HttpPost]
        public ActionResult BillingInformation(BillingInformation billingInfo)
        {
            if(ModelState.IsValid)
            {
                var checkIfExistingInfo = context.BillingInformations.Single(b => b.CustUserName == billingInfo.CustUserName);

                if(checkIfExistingInfo == null)
                {
                    context.BillingInformations.Add(billingInfo);
                    context.SaveChanges();
                }
            }
            TempData["CurrentUser"] = billingInfo.CustUserName;
            return RedirectToAction("SubmitOrder");
        }

        public ActionResult SubmitOrder()
        {
            var neworder = (Order) TempData["NewOrder"];
            context.Orders.Add(neworder);

            //Update the product Quantity
            foreach (var orderItem in neworder.OrderProducts)
            {
                var product = context.Products.Single(p => p.Product_ID == orderItem.ProductsID);
                product.Quantity = product.Quantity - orderItem.ProductQuantity;

                if(product.Quantity == 0)
                {
                    product.Status = 0; // If the product is out of quantity then set the status to 0
                }
            }

            context.SaveChanges();
            TempData["OrderID"] = neworder.ID;
            return RedirectToAction("OrderConfirmed");
            
        }

        public ActionResult OrderConfirmed()
        {
            //Clear the cart for the current Customer once he has confirmed the order
            var currentCustomer = TempData["CurrentUser"].ToString();

            context.Carts.Where(cart => cart.CustUserName == currentCustomer)
                        .ToList().ForEach(item => context.Carts.Remove(item));

            context.SaveChanges();
            return View();
        }

    }
}
