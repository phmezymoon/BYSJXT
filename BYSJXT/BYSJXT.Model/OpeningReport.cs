using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class OpeningReport
    {
        [Key]
        public int Id { get; set; }//Id

        [ForeignKey("StudentInfo")]
        public string StudentId { get; set; }//学生ID

        public string SubjectMeaning { get; set; }//课题意义

        public string SubjectOverview { get; set; }//课题综述

        public string KeyIssues { get; set; }//关键问题

        public string SubjectSolution { get; set; }//课题方案

        public string Condition { get; set; }//需要条件

       // public string Schedule { get; set; }//计划进度

        public virtual StudentInfo StudentInfo { get; set; }
    }
}
