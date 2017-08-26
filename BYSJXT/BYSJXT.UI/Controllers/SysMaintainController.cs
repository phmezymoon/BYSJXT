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
    public class SysMaintainController : Controller
    {
        //
        // GET: /SysMaintain/
        public IDepartmentService departmentService { get; set; }

        public ITeacherInfoService teacherInfoService { get; set; }

        public IStudentInfoService studentInfoService { get; set; }

        public IClassService classService { get; set; }

        //获取系名
        public ActionResult GetDepartmentName()
        {

            var pagaData = departmentService.GetEntities(d => true).Select(d => new { departmentName = d.DepartmentName, departmentId = d.Id }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);

        }

        //添加老师
        public ActionResult AddTeacher()
        {
            string teacherId = Request["teacherId"];
            string teacherName = Request["teacherName"];
            string password = Request["password"];
            string phone = Request["phone"];
            string email = Request["email"];
            string teacherPro = Request["teacherPro"];
            string departmentId = Request["departmentId"];
            string role = Request["role"];

            password = Md5Helper.GetMd5String(password);

            TeacherInfo teacher = new TeacherInfo();
            teacher.TeacherId = teacherId;
            teacher.TeacherName = teacherName;
            teacher.Password = password;
            teacher.Phone = phone;
            teacher.Email = email;
            teacher.TeacherPro = teacherPro;
            teacher.DepartmentId = departmentId;
            teacher.Role = role;
            teacher.DeclaredAmount = 0;
            teacher.SelectedAmount = 0;
            teacher.CheckedAmount = 0;
            teacher.UncheckedAmount = 0;
            teacher.FilledAmount = 0;
            teacher.UnfilledAmount = 0;

            teacherInfoService.Add(teacher);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //获取班级名
        public ActionResult GetClassName()
        {

            var pagaData = classService.GetEntities(c => true).Select(c => new { className = c.ClassName, classId = c.Id }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);

        }

        //添加学生
        public ActionResult AddStudent()
        {
            string studentId = Request["studentId"];
            string studentName = Request["studentName"];
            string password = Request["password"];
            string phone = Request["phone"];
            string email = Request["email"];
            string classId = Request["classId"];

            password = Md5Helper.GetMd5String(password);

            StudentInfo student = new StudentInfo();
            student.StudentId = studentId;
            student.StudentName = studentName;
            student.Password = password;
            student.Phone = phone;
            student.Email = email;
            student.ClassId = classId;
            student.SelectedAmount = 0;
            student.Remark = "可以参加毕设";

            studentInfoService.Add(student);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //根据教师ID获取老师信息
        public ActionResult GetTeacherInfo()
        {
            string teacherId = Request["teacherId"];

            var pagaData = teacherInfoService.GetEntities(t => t.TeacherId == teacherId)
                                                 .Select(t => new
                                                 {
                                                     teacherId = t.TeacherId,
                                                     teacherName = t.TeacherName,
                                                     role = t.Role
                                                 }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //修改或添加评阅意见
        public ActionResult UpdateTeacherRole()
        {
            string teacherId = Request["teacherId"];
            string role = Request["role"];


            TeacherInfo teacher = teacherInfoService.GetEntities(t => t.TeacherId == teacherId).FirstOrDefault();
            teacher.Role = role;
            teacherInfoService.Update(teacher);


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
