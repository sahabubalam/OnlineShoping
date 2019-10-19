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
    public class UpdateProductController : Controller
    {
        ProductUpdateOperation productUpdateOperation = new ProductUpdateOperation();
        // GET: UpdateProduct
        //Update Price Info
        public ActionResult UpdatePriceInfo()
        {
            ProductPriceUpdateModel productPriceUpdateModel = new ProductPriceUpdateModel();
           
            using(var context=new OnlineShopingEntities())
            {
                productPriceUpdateModel.products = context.Products.ToList();
            }
            return View(productPriceUpdateModel);
        }
        [HttpPost]
        public ActionResult UpdatePriceInfo(ProductPriceUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                int id = productUpdateOperation.UpdateProduct(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Updated!";

                }
                else
                {
                    ViewBag.Success = "Failed!";
                }
            }
            ProductPriceUpdateModel productPriceUpdateModel = new ProductPriceUpdateModel();
           
            using (var context = new OnlineShopingEntities())
            {
                productPriceUpdateModel.products = context.Products.ToList();
            }
            return View(productPriceUpdateModel);
        }
    }
}