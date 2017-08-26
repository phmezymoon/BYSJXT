using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BYSJXT.Model
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }//Id

        public string NoticeTitle { get; set; }//公告标题

        public string NoticeContent { get; set; }//公告内容

        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }//创建日期

        public string Status { get; set; }//状态
    }
}
