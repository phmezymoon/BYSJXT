using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Major
    {
        [Key]
        public string Id { get; set; }//Id

       // public string MajorCode { get; set; }//专业编号

        public string MajorName { get; set; }//专业名

        [ForeignKey("Department")]
        public string DepartmentId { get; set; }//系编号

        public virtual ICollection<Class> Class { get; set; }

        public virtual Department Department { get; set; }
    }
}
