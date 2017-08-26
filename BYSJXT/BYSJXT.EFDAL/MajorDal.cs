using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class MajorDal : IMajorDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();

        public IQueryable<Major> GetEntities(Expression<Func<Major, bool>> whereLambda)
        {
            return db.Major.Where(whereLambda).AsQueryable();
        }

        public Major Add(Major Major)
        {
            db.Major.Add(Major);
            db.SaveChanges();
            return Major;
        }

        public bool Update(Major Major)
        {
            try
            {
                db.Entry(Major).State = System.Data.EntityState.Modified;
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
            //var Major = db.Major.FirstOrDefault(d => d.TeacherId == id);
            //db.Major.Remove(Major);
            return db.SaveChanges() > 0;
        }
    }
}
