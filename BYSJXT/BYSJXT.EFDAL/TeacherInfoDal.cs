using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.IDAL;
using BYSJXT.Model;
using System.Linq.Expressions;
using System.Data.Entity;

namespace BYSJXT.EFDAL
{
    public class TeacherInfoDal : ITeacherInfoDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();
 
        public IQueryable<TeacherInfo> GetEntities(Expression<Func<TeacherInfo, bool>> whereLambda)
        {
            return db.TeacherInfo.Where(whereLambda).AsQueryable();
        }

        public TeacherInfo Add(TeacherInfo TeacherInfo)
        {
            db.TeacherInfo.Add(TeacherInfo);
            db.SaveChanges();
            return TeacherInfo;
        }

        public bool Update(TeacherInfo TeacherInfo)
        {
            try
            {
                db.Entry(TeacherInfo).State = System.Data.EntityState.Modified;
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
            //var TeacherInfo = db.TeacherInfo.FirstOrDefault(d => d.TeacherId == id);
            //db.TeacherInfo.Remove(TeacherInfo);
            return db.SaveChanges() > 0;
        }
    }
}
