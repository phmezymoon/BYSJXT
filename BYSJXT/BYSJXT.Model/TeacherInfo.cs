using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class TeacherInfo
    {
        //[Key]
        //public int Id { get; set; }//Id
        [Key]
        public string TeacherId { get; set; }//工号

        public string Password { get; set; }//密码

        public string TeacherName { get; set; }//姓名

        public string Phone { get; set; }//联系方式

        public string Email { get; set; }//邮箱

        [ForeignKey("Department")]
        public string DepartmentId { get; set; }//系ID

        public string TeacherPro { get; set; }//职称

        public int DeclaredAmount { get; set; }//申报课题数量

        public int SelectedAmount { get; set; }//已被选的课题数量

        public int CheckedAmount { get; set; }//已审查数量

        public int UncheckedAmount { get; set; }//未审查数量

        public int FilledAmount { get; set; }//已写任务书

        public int UnfilledAmount { get; set; }//未写任务书

        public string Role { get; set; }//权限

        public virtual Department Department { get; set; }

        public virtual ICollection<SubjectInfo> SubjectInfo { get; set; }
    }
}
