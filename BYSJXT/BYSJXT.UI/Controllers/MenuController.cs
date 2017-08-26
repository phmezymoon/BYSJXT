using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;

namespace BYSJXT.UI.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
       // public IUserService userService { get; set; }

        public ActionResult Index()
        {
            if (Session["loginUser"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        //public ActionResult GetUserInfo()
        //{
        //    User user = (User)Session["loginUser"];

        //    return Json(new { username = user.UserName }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult UpdateUserInfo()
        //{
        //    User user = (User)Session["loginUser"];

        //    string password = Request["password"];
        //    user.PassWord = password;
        //    userService.Update(user);

        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}

    }
}
