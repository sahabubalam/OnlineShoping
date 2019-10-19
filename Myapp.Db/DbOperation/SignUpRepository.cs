using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyyApp.Models;
using Myapp.Db;

namespace Myapp.Db.DbOperation
{
    public class SignUpRepository
    {
        public int HashFunction(string str)
        {
            long Base = 127, Mod = 1000000007;
            long ans = 0;
            int len = str.Length;
            long pow = 1;
            for (int i = 0; i < len; i++)
            {
                ans = (ans + str[i] * pow) % Mod;
                pow = (pow * Base) % Mod;
            }
            return (int)ans;
        }

        public int Operation(RegistrationModel model)
        {
            using (var context = new OnlineShopingEntities())
            {
                User user = new User()
                {
                    UserName = model.UserName,

                    Password = HashFunction(model.Password)

                };
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserId;
            }
        }
        public int login(LoginModel model)
        {
           using(var context=new OnlineShopingEntities())
            {
                string UserName = model.UserName.Replace(" ", "");
                string Password = model.Password.Replace(" ", "");
                int HashPassword = HashFunction(Password);
                var user = context.Users.Where(x => x.UserName == UserName && x.Password == HashPassword).FirstOrDefault();
                if (user != null)
                {
                    return user.UserId;
                }
                else return -1;
            }
        }

    }
}
