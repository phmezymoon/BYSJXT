using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class StudentInfoDal : IStudentInfoDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<StudentInfo> GetEntities(Expression<Func<StudentInfo, bool>> whereLambda)
        {
            return db.StudentInfo.Where(whereLambda).AsQueryable();
        }

        public StudentInfo Add(StudentInfo StudentInfo)
        {
            db.StudentInfo.Add(StudentInfo);
            db.SaveChanges();
            return StudentInfo;
        }

        public bool Update(StudentInfo StudentInfo)
        {
            try
            {
                db.Entry(StudentInfo).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Detele(int id)
        {
            //var StudentInfo = db.StudentInfo.FirstOrDefault(d => d.TeacherId == id);
            //db.StudentInfo.Remove(StudentInfo);
            return db.SaveChanges() > 0;
        }
    }
}
