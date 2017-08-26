using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }//Id

        [ForeignKey("StudentInfo")]
        public string StudentId { get; set; }//学生ID

        public string MentorComment { get; set; }//指导老师意见

        public string TeacherComment { get; set; }//督导组老师意见

        public string StudentFeedback { get; set; }//学生反馈

        public virtual StudentInfo StudentInfo { get; set; }
    }
}
