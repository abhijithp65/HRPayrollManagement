using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayrollManagement.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Display the home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Redirect to the "SignIn" action of the "Account" controller
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
         
            return View("~/Views/Account/SignIn.cshtml");
        }
        /// <summary>
        /// Redirect to the "Register" action of the "Registration" controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View("~/Views/Registration/Register.cshtml");
        }
        /// <summary>
        ///  Action to display the "About" page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// Action to display the "Contact" page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}