using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyyApp.Models;
using Myapp.Db;

namespace Myapp.Db.DbOperation
{
   
    public class InsertDetails
    {
        

        public int InsertUserInfo(UserInformation model,string UserName)
        {

            using (var context=new OnlineShopingEntities())
            {
                var user = context.Users.Where(x => x.UserName == UserName).FirstOrDefault();
                UserInformation userInformation = new UserInformation()
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    UserId = user.UserId
                };
                context.UserInformations.Add(userInformation);
                context.SaveChanges();
                return userInformation.UserInfoId;
            }
        }
       
      

        public int InsertCategory(Category model)
        {
            using (var context=new OnlineShopingEntities())
            {
                Category category = new Category()
                {
                    CategoryName = model.CategoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();
                return category.CategoryId;
            }
        }

        public int InsertProduct(ProductModel model)
        {
            using(var context=new OnlineShopingEntities())
            {


                Product product = new Product()
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    ProductDate = DateTime.Today,
                    Quantity = model.Quantity,
                    CategoryId=model.CategoryId
                  
                  

                };
                context.Products.Add(product);
                context.SaveChanges();
                return product.ProductId;
            }
        }
    }
}
