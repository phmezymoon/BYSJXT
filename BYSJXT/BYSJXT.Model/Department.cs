using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Department
    {
        [Key]
        public string Id { get; set; }//Id

      //  public string DepartmentCode { get; set; }//系编号

        public string DepartmentName { get; set; }//系名

        [ForeignKey("College")]
        public string CollegeId { get; set; }//院编号

        public virtual ICollection<Major> Major { get; set; }

        public virtual College College { get; set; }
    }
}
