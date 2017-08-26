using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class StudentInfo
    {
        //[Key]
       // public int Id { get; set; }//Id

        [Key]
        public string StudentId { get; set; }//学号

        public string Password { get; set; }//密码

        public string StudentName { get; set; }//姓名

        public string Phone { get; set; }//联系方式

        public string Email { get; set; }//邮箱

        [ForeignKey("Class")]
        public string ClassId { get; set; }//班级ID

        public int SelectedAmount { get; set; }//选题数量

       // [Required,ForeignKey("SubjectInfo")]
     //   public string SubjectCode { get; set; }//最终选题ID

        public string Remark { get; set; }//备注

        public virtual Class Class { get; set; }

  //      public virtual StudentSubject StudentSubject { get; set; }

       // public virtual SubjectInfo SubjectInfo { get; set; }
    }
}
