using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5RealWorld.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.User.UserLogin login)
        {
            if (User != null)
            {
                ViewBag.ValidationResult = "";
                bool isValid = false;
                if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                {
                    ViewBag.ValidationResult = "Incorrect user ID or Password";
                    isValid = false;
                }
                else
                {
                    MVC5RealWorld.Models.User.Result result =  MVC5RealWorld.Models.User.Result.GetToken(new Models.User.UserLogin { email = login.email, password =login.password});
                    if (result.token.ToString().ToLower().Contains("error"))
                    {
                        isValid = false;
                        ViewBag.ValidationResult = "Incorrect user ID or Password";
                        return View(login);
                    }
                    else
                    {
                        Session["email"] = login.email;
                        Session["pass"] = login.password;
                        Session["token"] = result.token;
                        return RedirectToAction("Index", "Home");
                    }
                 
                }
            }
            return View();
        }
    }
}