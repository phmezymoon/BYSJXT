using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYSJXT.Model
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }//Id

        [ForeignKey("StudentInfo")]
        public string StudentId { get; set; }//学生ID

        //public string TranslationTitle { get; set; }//翻译标题

        public string SourceText { get; set; }//原文

        public string TranslationContent { get; set; }//译文

        public virtual StudentInfo StudentInfo { get; set; }
    }
}
