using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyyApp.Models;
using Myapp.Db;
using Myapp.Db.DbOperation;

namespace OnlineShopingApplication.Controllers
{
    public class DetailsController : Controller
    {
        InsertDetails insertDetails = new InsertDetails();
        // GET: Details
        public ActionResult InsertUserInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertUserInfo(UserInformation model)
        {
            if (ModelState.IsValid)
            {
                int id = insertDetails.InsertUserInfo(model, (string)Session["UserName"]);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Your data has been recorded";
                }
                else
                {
                    ViewBag.Success = "Failed";
                }
            }
            return RedirectToAction("About", "Home");
        }

       
      
        public ActionResult InsertCategoryInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCategoryInfo(Category model)
        {
            if (ModelState.IsValid)
            {
                int id = insertDetails.InsertCategory(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Inserted successfull";
                }
                else
                {
                    ViewBag.Successfull = "Failed!";
                }
            }
            return View();
        }

        public ActionResult InsertProductInfo()
        {
            ProductModel productModel = new ProductModel();
            
            using(var context=new OnlineShopingEntities())
            {
                productModel.categories = context.Categories.ToList();
            }
            return View(productModel);
        }
        [HttpPost]
        public ActionResult InsertProductInfo(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                int id = insertDetails.InsertProduct(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Inserted successfull";
                }
                else
                {
                    ViewBag.Success = "Failed!";
                }
            }
            ProductModel productModel = new ProductModel();

            using (var context = new OnlineShopingEntities())
            {
                productModel.categories = context.Categories.ToList();
            }
            return View(productModel);
        }
    }
}

