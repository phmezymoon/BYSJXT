using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;

namespace BYSJXT.UI.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ITeacherInfoService teacherInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TeacherInfo teacher)
        {
            teacherInfoService.Add(teacher);
            return Index();
        }

    }
}
