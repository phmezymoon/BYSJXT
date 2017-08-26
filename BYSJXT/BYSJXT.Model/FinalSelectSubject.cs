using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BYSJXT.Model
{
    public class FinalSelectSubject
    {
        [Key,ForeignKey("SubjectInfo")]
        public string SubjectId { get; set; }//课题ID

        [ForeignKey("StudentInfo")]
        public string StudentId { get; set; }//学生ID

        public virtual StudentInfo StudentInfo { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
