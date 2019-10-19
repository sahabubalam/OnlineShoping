using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyyApp.Models;

namespace Myapp.Db.DbOperation
{
    public class ProductUpdateOperation
    {
        public int UpdateProduct(ProductPriceUpdateModel model)
        {
            using(var context=new OnlineShopingEntities())
            {
                var product = context.Products.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Price = model.price;
                }
                else
                {
                    return -1;
                }
      
                context.SaveChanges();
                return product.ProductId;
            }
        }
    }
}
