using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyyApp.Models;

namespace Myapp.Db.DbOperation
{
    public class LoginRepository
    {
        public bool login(User model)
        {
            using(var context=new OnlineShopingEntities())
            {
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                return isValid;
            }
        }
    }
}
