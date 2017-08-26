using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class StudentSubjectDal : IStudentSubjectDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<StudentSubject> GetEntities(Expression<Func<StudentSubject, bool>> whereLambda)
        {
            return db.StudentSubject.Where(whereLambda).AsQueryable();
        }

        public StudentSubject Add(StudentSubject StudentSubject)
        {
            db.StudentSubject.Add(StudentSubject);
            db.SaveChanges();
            return StudentSubject;
        }

        public bool Update(StudentSubject StudentSubject)
        {
            try
            {
                db.Entry(StudentSubject).State = System.Data.EntityState.Modified;
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
            //var StudentSubject = db.StudentSubject.FirstOrDefault(d => d.TeacherId == id);
            //db.StudentSubject.Remove(StudentSubject);
            return db.SaveChanges() > 0;
        }
    }
}
