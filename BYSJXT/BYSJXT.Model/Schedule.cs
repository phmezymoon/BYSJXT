using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }//Id

        public string ScheduleRequirement { get; set; }//进度要求

        [DataType(DataType.Date)]
        public DateTime? BeginDate { get; set; }//起始日期

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }//截止日期

       // [DataType(DataType.Date)]
      //  public DateTime? CompleteDate { get; set; }//完成日期

        public string Status { get; set; }//状态

        [ForeignKey("SubjectInfo")]
        public string SubjectId { get; set; }//课题ID

        public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
