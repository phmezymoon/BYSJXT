using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;
using BYSJXT.BLL;

namespace BYSJXT.UI.Controllers
{
    public class SelectedSubjectController : Controller//选题监控
    {

        public ITeacherInfoService teacherInfoService { get; set; }

        public ISubjectInfoService subjectInfoService { get; set; }

        public IScheduleService scheduleService { get; set; }

        public IStudentInfoService studentInfoService { get; set; }

        public ICollegeService collegeService { get; set; }

        public IDepartmentService departmentService { get; set; }

        public IMajorService majorService { get; set; }

        public IClassService classService { get; set; }

        public IStudentSubjectService studentSubjectService { get; set; }

        //获取学院-系树
        public ActionResult GetDepartmentTree()
        {
            string nodeId = Request["nodeId"];

            if (nodeId[0] == '0') {
                var pagaData = collegeService.GetEntities(c => true).Select(c => new { id = c.Id, text = c.CollegeName }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (nodeId[0] == '1')
            {
                var pagaData = departmentService.GetEntities(d => d.CollegeId == nodeId).Select(d => new { id = d.Id, text = d.DepartmentName, leaf = true }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }


            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        //获取学院-班级树
        public ActionResult GetClassTree()
        {
            string nodeId = Request["nodeId"];

            if (nodeId[0] == '0')
            {
                var pagaData = collegeService.GetEntities(c => true).Select(c => new { id = c.Id, text = c.CollegeName }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (nodeId[0] == '1')
            {
                var pagaData = departmentService.GetEntities(d => d.CollegeId == nodeId).Select(d => new { id = d.Id, text = d.DepartmentName }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (nodeId[0] == '2')
            {
                var pagaData = majorService.GetEntities(m => m.DepartmentId == nodeId).Select(m => new { id = m.Id, text = m.MajorName }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (nodeId[0] == '3')
            {
                var pagaData = classService.GetEntities(m => m.MajorId == nodeId).Select(m => new { id = m.Id, text = m.ClassName, leaf = true }).ToList();
                return Json(new { children = pagaData }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        //根据院系ID获取该院系的所有老师
        public ActionResult GetAllTeachers()
        {
            string choseTreeId = Request["choseTreeId"];
            if (choseTreeId[0] == '1') {
                var pagaData = teacherInfoService.GetEntities(t => t.Department.CollegeId == choseTreeId)
                                                 .Select(t => new { teacherId = t.TeacherId, 
                                                                    teacherName = t.TeacherName, 
                                                                    collegeName = t.Department.College.CollegeName, 
                                                                    departmentName = t.Department.DepartmentName,
                                                                    checkedAmount = t.CheckedAmount,
                                                                    uncheckedAmount = t.UncheckedAmount,   
                                                                    filledAmount = t.FilledAmount,
                                                                    unfilledAmount = t.UnfilledAmount,
                                                                    selectedAmount = t.SelectedAmount,
                                                                    role = t.Role,
                                                                    declaredAmount = t.DeclaredAmount }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '2') {
                var pagaData = teacherInfoService.GetEntities(t => t.DepartmentId == choseTreeId)
                                                 .Select(t => new { teacherId = t.TeacherId, 
                                                                    teacherName = t.TeacherName, 
                                                                    collegeName = t.Department.College.CollegeName,
                                                                    departmentName = t.Department.DepartmentName,
                                                                    checkedAmount = t.CheckedAmount,
                                                                    uncheckedAmount = t.UncheckedAmount,
                                                                    filledAmount = t.FilledAmount,
                                                                    unfilledAmount = t.UnfilledAmount,
                                                                    selectedAmount = t.SelectedAmount,
                                                                    role = t.Role,
                                                                    declaredAmount = t.DeclaredAmount }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            
        }

        //根据老师ID获取该老师申报的课题清单
        public ActionResult GetDeclareSubjectList()
        {
            string teacherId = Request["teacherId"];
            var pagaData = subjectInfoService.GetEntities(s => s.TeacherId == teacherId)
                                             .Select(s => new {  teacherId = s.TeacherId, 
                                                                 teacherName = s.TeacherInfo.TeacherName,
                                                                 subjectName = s.SubjectName,
                                                                 subjectId = s.SubjectId, 
                                                                 type = s.Type, 
                                                                 source = s.Source, 
                                                                 status = s.Status }).ToList();                                                  
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据课题ID获取该题的详细情况
        public ActionResult GetSubjectDetails()
        {
            string subjectId = Request["subjectId"];
            var pagaData = subjectInfoService.GetEntities(s => s.SubjectId == subjectId)
                                             .Select(s => new{  teacherName = s.TeacherInfo.TeacherName,                                              
                                                                subjectName = s.SubjectName,
                                                                subjectId = s.SubjectId,
                                                                type = s.Type,
                                                                source = s.Source,
                                                                majorName1 = s.MajorName1,
                                                                majorName2 = s.MajorName2,
                                                                requirement = s.Requirement,
                                                                tools = s.Tools,
                                                                reference = s.Reference,
                                                                secondTeacher = s.SecondTeacher }).ToList();                                            
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);    
        }

        //根据课题ID获取该题的计划进度
        public ActionResult GetSchedule()
        {
            string subjectId = Request["subjectId"];
            var pagaData = scheduleService.GetEntities(s => s.SubjectId == subjectId)
                                          .Select(s => new {  scheduleRequirement = s.ScheduleRequirement, 
                                                              beginDate = s.BeginDate, 
                                                              endDate  = s.EndDate}).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据审查老师的ID获取 该老师所审查的课题清单
        public ActionResult GetCheckSubjectList()
        {
            string checkerId = Request["checkerId"];
            string checkerName = Request["checkerName"];
            var pagaData = subjectInfoService.GetEntities(s => s.CheckerId == checkerId)
                                             .Select(s => new
                                             {
                                                 teacherId = s.TeacherId,
                                                 teacherName = s.TeacherInfo.TeacherName,
                                                 subjectName = s.SubjectName,
                                                 subjectId = s.SubjectId,
                                                 checkerId = checkerId,
                                                 checkerName = checkerName,
                                                 checkResult = s.CheckResult
                                             }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据院系ID获取该院系的所有申报课题情况
        public ActionResult GetAllSubjects()
        {
            string choseTreeId = Request["choseTreeId"];
            if (choseTreeId[0] == '1')
            {
                var pagaData = subjectInfoService.GetEntities(s => s.TeacherInfo.Department.CollegeId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     subjectId = s.SubjectId,
                                                     subjectName = s.SubjectName,
                                                     teacherName = s.TeacherInfo.TeacherName,
                                                     departmentName = s.TeacherInfo.Department.DepartmentName,
                                                     source = s.Source,
                                                     type = s.Type,
                                                     status = s.Status,
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '2')
            {
                var pagaData = subjectInfoService.GetEntities(s => s.TeacherInfo.DepartmentId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     subjectId = s.SubjectId,
                                                     subjectName = s.SubjectName,
                                                     teacherName = s.TeacherInfo.TeacherName,
                                                     departmentName = s.TeacherInfo.Department.DepartmentName,
                                                     source = s.Source,
                                                     type = s.Type,
                                                     status = s.Status,
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        //根据老师ID获取该老师每个课题所选的学生
        public ActionResult GetTeacherSelectionList()
        {
            string teacherId = Request["teacherId"];
            var pagaData = subjectInfoService.GetEntities(s => s.TeacherId == teacherId)
                                             .Select(s => new
                                             {
                                                 teacherId = s.TeacherId,
                                                 teacherName = s.TeacherInfo.TeacherName,
                                                 subjectId = s.SubjectId,
                                                 subjectName = s.SubjectName,                                             
                                                 studentId = s.FinalSelectSubject.StudentInfo.StudentId,
                                                 studentName = s.FinalSelectSubject.StudentInfo.StudentName,
                                                 selectedAmount = s.SelectedAmount,
                                                 status = s.Status
                                             }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据院系ID获取该院系的所有学生
        public ActionResult GetAllStudents()
        {
            string choseTreeId = Request["choseTreeId"];
            if (choseTreeId[0] == '1')
            {
                var pagaData = studentInfoService.GetEntities(s => s.Class.Major.Department.CollegeId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     studentId = s.StudentId,
                                                     studentName = s.StudentName,
                                                     className = s.Class.ClassName,
                                                     departmentName = s.Class.Major.Department.DepartmentName,
                                                     selectedAmount = s.SelectedAmount,
                                                     remark = s.Remark                    
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '2')
            {
                var pagaData = studentInfoService.GetEntities(s => s.Class.Major.DepartmentId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     studentId = s.StudentId,
                                                     studentName = s.StudentName,
                                                     className = s.Class.ClassName,
                                                     departmentName = s.Class.Major.Department.DepartmentName,
                                                     selectedAmount = s.SelectedAmount,
                                                     remark = s.Remark
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '3')
            {
                var pagaData = studentInfoService.GetEntities(s => s.Class.MajorId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     studentId = s.StudentId,
                                                     studentName = s.StudentName,
                                                     className = s.Class.ClassName,
                                                     departmentName = s.Class.Major.Department.DepartmentName,
                                                     selectedAmount = s.SelectedAmount,
                                                     remark = s.Remark
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '4')
            {
                var pagaData = studentInfoService.GetEntities(s => s.ClassId == choseTreeId)
                                                 .Select(s => new
                                                 {
                                                     studentId = s.StudentId,
                                                     studentName = s.StudentName,
                                                     className = s.Class.ClassName,
                                                     departmentName = s.Class.Major.Department.DepartmentName,
                                                     selectedAmount = s.SelectedAmount,
                                                     remark = s.Remark
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        //根据学生ID获取该学生所选的题目清单
        public ActionResult GetStudentSelectionList()
        {
            string studentId = Request["studentId"];
            var pagaData = studentSubjectService.GetEntities(s => s.StudentId == studentId)
                                             .Select(s => new
                                             {
                                                 studentId = s.StudentId,
                                                 studentName = s.StudentInfo.StudentName,
                                                 subjectId = s.SubjectId,
                                                 subjectName = s.SubjectInfo.SubjectName,
                                                 teacherId = s.SubjectInfo.TeacherInfo.TeacherId,
                                                 teacherName = s.SubjectInfo.TeacherInfo.TeacherName,
                                                 selectionOrder = s.SelectionOrder
                                             }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据学生ID获取该学生的联系方式
        public ActionResult GetStudentInfo()
        {
            string studentId = Request["studentId"];
            var student = studentInfoService.GetEntities(s => s.StudentId == studentId)
                                             .Select(s => new
                                             {
                                                 studentId = s.StudentId,
                                                 studentName = s.StudentName,
                                                 phone = s.Phone,
                                                 email = s.Email
                                             }).ToList();
            return Json(new { studentId = student[0].studentId, studentName = student[0].studentName, phone = student[0].phone, email = student[0].email }, JsonRequestBehavior.AllowGet);
        }

        //查看每位同学最终所选的课题
        public ActionResult GetAllSelectedSubjects()
        {
            string choseTreeId = Request["choseTreeId"];
            if (choseTreeId[0] == '1')
            {
                var pagaData = studentSubjectService.GetEntities(s => s.StudentInfo.Class.Major.Department.CollegeId == choseTreeId && s.IsFinalSelection == true)
                                                 .Select(s => new
                                                 {
                                                     studentId = s.StudentId,
                                                     studentName = s.StudentInfo.StudentName,
                                                     className = s.StudentInfo.Class.ClassName,
                                                     departmentName = s.StudentInfo.Class.Major.Department.DepartmentName,
                                                     subjectId = s.SubjectInfo.SubjectId,
                                                     subjectName = s.SubjectInfo.SubjectName,
                                                     teacherName = s.SubjectInfo.TeacherInfo.TeacherName,
                                                     teacherPro = s.SubjectInfo.TeacherInfo.TeacherPro,
                                                     source = s.SubjectInfo.Source,
                                                     type = s.SubjectInfo.Type,
                                                     remark = s.StudentInfo.Remark
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '2') {
                var pagaData = studentSubjectService.GetEntities(s => s.StudentInfo.Class.Major.DepartmentId == choseTreeId && s.IsFinalSelection == true)
                                 .Select(s => new
                                 {
                                     studentId = s.StudentId,
                                     studentName = s.StudentInfo.StudentName,
                                     className = s.StudentInfo.Class.ClassName,
                                     departmentName = s.StudentInfo.Class.Major.Department.DepartmentName,
                                     subjectId = s.SubjectInfo.SubjectId,
                                     subjectName = s.SubjectInfo.SubjectName,
                                     teacherName = s.SubjectInfo.TeacherInfo.TeacherName,
                                     teacherPro = s.SubjectInfo.TeacherInfo.TeacherPro,
                                     source = s.SubjectInfo.Source,
                                     type = s.SubjectInfo.Type,
                                     remark = s.StudentInfo.Remark
                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '3')
            {
                var pagaData = studentSubjectService.GetEntities(s => s.StudentInfo.Class.MajorId == choseTreeId && s.IsFinalSelection == true)
                                 .Select(s => new
                                 {
                                     studentId = s.StudentId,
                                     studentName = s.StudentInfo.StudentName,
                                     className = s.StudentInfo.Class.ClassName,
                                     departmentName = s.StudentInfo.Class.Major.Department.DepartmentName,
                                     subjectId = s.SubjectInfo.SubjectId,
                                     subjectName = s.SubjectInfo.SubjectName,
                                     teacherName = s.SubjectInfo.TeacherInfo.TeacherName,
                                     teacherPro = s.SubjectInfo.TeacherInfo.TeacherPro,
                                     source = s.SubjectInfo.Source,
                                     type = s.SubjectInfo.Type,
                                     remark = s.StudentInfo.Remark
                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '4')
            {
                var pagaData = studentSubjectService.GetEntities(s => s.StudentInfo.ClassId == choseTreeId && s.IsFinalSelection == true)
                                 .Select(s => new
                                 {
                                     studentId = s.StudentId,
                                     studentName = s.StudentInfo.StudentName,
                                     className = s.StudentInfo.Class.ClassName,
                                     departmentName = s.StudentInfo.Class.Major.Department.DepartmentName,
                                     subjectId = s.SubjectInfo.SubjectId,
                                     subjectName = s.SubjectInfo.SubjectName,
                                     teacherName = s.SubjectInfo.TeacherInfo.TeacherName,
                                     teacherPro = s.SubjectInfo.TeacherInfo.TeacherPro,
                                     source = s.SubjectInfo.Source,
                                     type = s.SubjectInfo.Type,
                                     remark = s.StudentInfo.Remark
                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        
        
    }
}
