using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace BYSJXT.Model
{
    public class BysjxtDB : DbContext
    {

        public DbSet<College> College { get; set; }//院表

        public DbSet<Department> Department { get; set; }//系表

        public DbSet<Major> Major { get; set; }//专业表

        public DbSet<Class> Class { get; set; }//班级表

        public DbSet<StudentInfo> StudentInfo { get; set; }//学生表

        public DbSet<TeacherInfo> TeacherInfo { get; set; }//教师表

        public DbSet<SubjectInfo> SubjectInfo { get; set; }//课题表

        public DbSet<OpeningReport> OpeningReport { get; set; }//开题报告表

        public DbSet<Schedule> Schedule { get; set; }//计划进度表

        public DbSet<StudentSubject> StudentSubject { get; set; }//学生选题表

        public DbSet<Translation> Translation { get; set; }//论文译文表

        public DbSet<Comment> Comment { get; set; }//评阅意见表

        public DbSet<Notice> Notice { get; set; }//公告表


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //一个学生对应一个课题  一个课题对应0-1个学生
            //modelBuilder.Entity<StudentInfo>().HasRequired(p => p.SubjectInfo).WithOptional(p => p.StudentInfo);

            modelBuilder.Entity<StudentSubject>().HasKey(t => new { t.StudentId, t.SubjectId });

           // modelBuilder.Entity<FinalSelectSubject>().HasKey(t => new { t.StudentId, t.SubjectId });
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
