using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;
using BYSJXT.Common;

namespace BYSJXT.UI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ITeacherInfoService teacherInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }
        //登录
        public ActionResult TeacherLogin()
        {
            string username = Request["username"];
            string password = Request["password"];
            string logoradio = Request["logoradio"];
            password = Md5Helper.GetMd5String(password);

            TeacherInfo teacher = teacherInfoService.GetEntities(u => u.TeacherId == username && u.Password == password).FirstOrDefault();
            if (teacher != null && (teacher.Role == "校督导员" || teacher.Role == "校管理员"))
            {
                if (logoradio != "学校")
                {
                    return Json(new { success = false, msg = "无权限" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["loginUser"] = teacher;
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

            }
            else if (teacher != null && teacher.Role == "无")
            {
                return Json(new { success = false, msg = "无权限" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, msg = "账号或密码错误" }, JsonRequestBehavior.AllowGet);
            }
        }

        //注销
        public ActionResult Logout()
        {
            Session.Clear();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index", "Login");
        }

        //获取老师信息
        public ActionResult GetTeacherInfo()
        {
            TeacherInfo teacher = (TeacherInfo)Session["loginUser"];

            return Json(new { teacherId = teacher.TeacherId, teacherName = teacher.TeacherName, phone = teacher.Phone, email = teacher.Email }, JsonRequestBehavior.AllowGet);
        }

        //更新老师信息
        public ActionResult UpdateTeacherInfo()
        {
            TeacherInfo teacherSession = (TeacherInfo)Session["loginUser"];

            TeacherInfo teacher = teacherInfoService.GetEntities(u => u.TeacherId == teacherSession.TeacherId).FirstOrDefault();

            string password = Request["password"];
            string phone = Request["phone"];
            string email = Request["email"];

            password = Md5Helper.GetMd5String(password);

            teacher.Password = password;
            teacher.Phone = phone;
            teacher.Email = email;

            teacherInfoService.Update(teacher);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
