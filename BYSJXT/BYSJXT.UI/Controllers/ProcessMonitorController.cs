using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;

namespace BYSJXT.UI.Controllers
{
    public class ProcessMonitorController : Controller
    {
        //
        // GET: /ProcessMonitor/
        public IStudentSubjectService studentSubjectService { get; set; }

        public IScheduleService scheduleService { get; set; }

        public IOpeningReportService openingReportService { get; set; }

        public ITranslationService translationService { get; set; }

        public ICommentService commentService { get; set; }


        //根据院系ID获得所有学生的信息
        public ActionResult GetAllStudent()
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
                                                     subjectName = s.SubjectInfo.SubjectName
                                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            else if (choseTreeId[0] == '2')
            {
                var pagaData = studentSubjectService.GetEntities(s => s.StudentInfo.Class.Major.DepartmentId == choseTreeId && s.IsFinalSelection == true)
                                 .Select(s => new
                                 {
                                     studentId = s.StudentId,
                                     studentName = s.StudentInfo.StudentName,
                                     className = s.StudentInfo.Class.ClassName,
                                     departmentName = s.StudentInfo.Class.Major.Department.DepartmentName,
                                     subjectId = s.SubjectInfo.SubjectId,
                                     subjectName = s.SubjectInfo.SubjectName
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
                                     subjectName = s.SubjectInfo.SubjectName
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
                                     subjectName = s.SubjectInfo.SubjectName
                                 }).ToList();
                return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        //获取工作记录
        public ActionResult GetSchedule() {
            string subjectId = Request["subjectId"];
            var pagaData = scheduleService.GetEntities(s => s.SubjectId == subjectId)
                                          .Select(s => new
                                          {
                                              scheduleRequirement = s.ScheduleRequirement,
                                              beginDate = s.BeginDate,
                                              endDate = s.EndDate,
                                              status = s.Status
                                          }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //获取开题报告
        public ActionResult GetOpeningReport()
        {
            string studentId = Request["studentId"];
            var pagaData = openingReportService.GetEntities(o => o.StudentId == studentId)
                                               .Select(o => new
                                                {
                                                    subjectMeaning = o.SubjectMeaning,
                                                    subjectOverview = o.SubjectOverview,
                                                    keyIssues = o.KeyIssues,
                                                    subjectSolution = o.SubjectSolution,
                                                    condition = o.Condition
                                                }).ToList();
                                          
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //获取论文译文
        public ActionResult GetTranslation()
        {
            string studentId = Request["studentId"];
            var pagaData = translationService.GetEntities(t => t.StudentId == studentId)
                                               .Select(t => new
                                               {
                                                   sourceText = t.SourceText,
                                                   translationContent = t.TranslationContent
                                               }).ToList();

            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //获取评阅意见
        public ActionResult GetComment()
        {
            string studentId = Request["studentId"];
            var pagaData = commentService.GetEntities(t => t.StudentId == studentId)
                                               .Select(t => new
                                               {
                                                   teacherComment = t.TeacherComment,
                                                   mentorComment = t.MentorComment,
                                                   studentFeedback = t.StudentFeedback
                                               }).ToList();

            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //修改或添加评阅意见
        public ActionResult UpdateTeacherComment()
        {
            string studentId = Request["studentId"];
            string teacherComment = Request["teacherComment"];

            Comment comment = commentService.GetEntities(t => t.StudentId == studentId).FirstOrDefault();
            if (comment == null)
            {
                Comment newComment = new Comment();
                newComment.StudentId = studentId;
                newComment.TeacherComment = teacherComment;
                commentService.Add(newComment);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else if (comment != null)
            {
                comment.TeacherComment = teacherComment;
                commentService.Update(comment);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }


            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

    }
}
