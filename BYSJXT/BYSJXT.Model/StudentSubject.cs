using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class StudentSubject
    {
        //[Key]
       // public int Id { get; set; }//Id

        [ForeignKey("StudentInfo")]
        public string StudentId { get; set; }//学生ID

        [ForeignKey("SubjectInfo")]
        public string SubjectId { get; set; }//课题ID

        public string SelectionOrder { get; set; }//选题序号

        public Boolean IsFinalSelection { get; set; }//是否为最终选题

        public virtual StudentInfo StudentInfo { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }


    }
}
