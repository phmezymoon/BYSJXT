using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BYSJXT.Model
{
    public class College
    {
        [Key]
        public string Id { get; set; }//Id

      //  public string CollegeCode { get; set; }//院编号

        public string CollegeName { get; set; }//院名

        public virtual ICollection<Department> Department { get; set; }


    }
}
