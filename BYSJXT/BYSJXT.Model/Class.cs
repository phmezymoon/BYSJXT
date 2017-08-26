using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Class
    {
        [Key]
        public string Id { get; set; }//Id

       // public string ClassCode { get; set; }//班级编号

        public string ClassName { get; set; }//班级名

        [ForeignKey("Major")]
        public string MajorId { get; set; }//专业编号

        public virtual Major Major { get; set; }

        public virtual ICollection<SubjectInfo> SubjectInfo { get; set; }
    }
}
