using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class SubjectInfoDal : ISubjectInfoDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<SubjectInfo> GetEntities(Expression<Func<SubjectInfo, bool>> whereLambda)
        {
            return db.SubjectInfo.Where(whereLambda).AsQueryable();
        }

        public SubjectInfo Add(SubjectInfo SubjectInfo)
        {
            db.SubjectInfo.Add(SubjectInfo);
            db.SaveChanges();
            return SubjectInfo;
        }

        public bool Update(SubjectInfo SubjectInfo)
        {
            try
            {
                db.Entry(SubjectInfo).State = System.Data.EntityState.Modified;
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
            //var SubjectInfo = db.SubjectInfo.FirstOrDefault(d => d.TeacherId == id);
            //db.SubjectInfo.Remove(SubjectInfo);
            return db.SaveChanges() > 0;
        }
    }
}
