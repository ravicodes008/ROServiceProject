using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROServiceProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region About Us Page

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }


        #endregion

        #region Contact Us Page

        // GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }
        #endregion
    }
}