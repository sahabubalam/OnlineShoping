using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyyApp.Models;
using Myapp.Db.DbOperation;
using System.Web.Security;

namespace OnlineShopingApplication.Controllers
{
    public class AccountController : Controller   
    {
       
        SignUpRepository signUpRepository = null;
        public AccountController()
        {
          
            signUpRepository = new SignUpRepository();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            int id = signUpRepository.login(model);
            FormsAuthentication.SetAuthCookie(model.UserName, false);
            ViewBag.Success = "Success";
            Session["UserName"] = model.UserName;
            return RedirectToAction("Contact", "Home");
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                int id = signUpRepository.Operation(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Congratulation! Registration successfull";
                }
                else
                {
                    ViewBag.Success = "UserName already exists";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}