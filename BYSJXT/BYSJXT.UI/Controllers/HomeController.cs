using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BYSJXT.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["loginUser"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Menu");
        }

    }
}
