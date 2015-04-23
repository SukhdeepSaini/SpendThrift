using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpendThriftModel;

namespace SpendThriftWebsite.Models.ShoppingCart
{
    public class ShoppingCart
    {
        STEntities storeDB = new STEntities();

        public const string CartSessionKey = "CartId";
        string ShoppingCartId { get; set; }

        public static ShoppingCart GetCart(HttpContextBase context, string customerUserName)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context,customerUserName);
            return cart;
        }


        public string GetCartId(HttpContextBase context, string customerUsername)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(customerUsername))
                {
                    context.Session[CartSessionKey] = customerUsername;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }


        public void AddToCart(Product product)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                            c => c.CustUserName == ShoppingCartId
                            && c.ProductID == product.Product_ID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductID = product.Product_ID,
                    CustUserName = ShoppingCartId,
                    ProductCount = 1,
                    DateCreated = DateTime.Now
                };

                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.ProductCount++;
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(cart => cart.CustUserName == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CustUserName == ShoppingCartId
                          select (int?)cartItems.ProductCount).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CustUserName == ShoppingCartId
                              select (int?)cartItems.ProductCount * cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;
        }
    }
}