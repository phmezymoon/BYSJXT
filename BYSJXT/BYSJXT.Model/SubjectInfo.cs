using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class SubjectInfo
    {
       // [Key]
       // public int Id { get; set; }//Id

        [Key]
        public string SubjectId { get; set; }//课题编号

        public string SubjectName { get; set; }//课题名称

        public string Type { get; set; }//类型

        public string Source { get; set; }//来源

        public string Status { get; set; }//状态

        //  public string DepartmentCode { get; set; }//系ID

        [ForeignKey("TeacherInfo")]
        public string TeacherId { get; set; }//指导教师ID

        public string SecondTeacher { get; set; }//第二教师姓名

        public string MajorName1 { get; set; }//面向专业1

        public string MajorName2 { get; set; }//面向专业2

        public string Requirement { get; set; }//任务要求

        public string Tools { get; set; }//工具环境

        public string Reference { get; set; }//参考资料

      //  [ForeignKey("TeacherInfo")]
        public string CheckerId { get; set; }//审查教师ID

        public string CheckResult { get; set; }//审查结论

       // [ForeignKey("StudentInfo")]
       // public string StudentId { get; set; }//选定学生ID

        public int SelectedAmount { get; set; }//选题学生数

        public virtual ICollection<Schedule> Schedule { get; set; }

        public virtual TeacherInfo TeacherInfo { get; set; }

        public virtual FinalSelectSubject FinalSelectSubject { get; set; }

      //  public virtual StudentSubject StudentSubject { get; set; }

      //  public StudentInfo StudentInfo { get; set; }
    }
}
