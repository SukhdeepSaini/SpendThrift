using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendThriftModel;
using System.Net;

namespace SpendThriftWebsite.Controllers
{
    public class ProductController : Controller
    {
        STEntities context = new STEntities();

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product model,Category category)
        {
            if(ModelState.IsValid)
            {
                var newProduct = new Product
                                {
                                    Product_ID = model.Product_ID,
                                    Name = model.Name,
                                    Quantity = model.Quantity,
                                    Price = model.Price,
                                    Status = model.Status,
                                    Description = model.Description,
                                    ImageUrl = model.ImageUrl
                                };


                var productCategory = context.Categories.First(c => c.CategoryName == category.CategoryName);
                productCategory.Products.Add(newProduct);
                context.SaveChanges();
                return RedirectToAction("ViewProducts"); 
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult ViewProducts()
        {
            var allProducts = context.Products;
            return View(allProducts);
        }


        public ActionResult Edit(int productID)
        {
            var product = context.Products.FirstOrDefault(p => p.Product_ID == productID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                var existingProduct = context.Products.FirstOrDefault(p => p.Product_ID == product.Product_ID);

                existingProduct.Name = product.Name;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.Status = product.Status;
                existingProduct.ImageUrl = product.ImageUrl;
                context.SaveChanges();
                return RedirectToAction("ViewProducts");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Delete(int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.Product_ID == productId);
            return View(product);
        }


        public ActionResult DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                var categories = context.Categories;

                var productCategories = from category in categories
                                        from product in category.Products
                                        where product.Product_ID == productId
                                        select category;

                foreach (var category in productCategories)
                {
                    var product = category.Products.FirstOrDefault(p => p.Product_ID == productId);

                    if(product != null)
                    {
                        category.Products.Remove(product);
                    }                  
                }

                var reviews = context.Reviews;

                var productReviews = from review in reviews
                                    where review.ProductID == productId
                                    select review;

                foreach (var review in productReviews)
                {
                    context.Reviews.Remove(review);
                }

                var existingProduct = context.Products.FirstOrDefault(p => p.Product_ID == productId);
                context.Products.Remove(existingProduct);
                context.SaveChanges();
                return RedirectToAction("ViewProducts");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Review(int id)
        {
            var review = new Review
                            {
                                ProductID = id,
                                CustUserName = TempData["CurrentUser"].ToString(),
                                DateAdded = DateTime.Now
                            };

            TempData["CurrentUser"] = review.CustUserName;

            return View(review);
        }

        [HttpPost]
        public ActionResult Review(Review review)
        {
            if(review != null)
            {
                var customer = context.CUSTOMERs.FirstOrDefault(c => c.USERNAME == review.CustUserName);
                var product = context.Products.FirstOrDefault(p => p.Product_ID == review.ProductID);

                var newReview = new Review
                {
                    ProductID = review.ProductID,
                    CustUserName = review.CustUserName,
                    Rating = review.Rating,
                    DateAdded = review.DateAdded,
                    Description = review.Description
                };

                TempData["CurrentUser"] = newReview.CustUserName;

                context.Reviews.Add(newReview);
                context.SaveChanges();
                return RedirectToAction("Details","Store", new {id = review.ProductID});
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

    }
}
