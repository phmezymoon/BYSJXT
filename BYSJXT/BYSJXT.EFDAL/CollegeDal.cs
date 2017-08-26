using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class CollegeDal : ICollegeDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<College> GetEntities(Expression<Func<College, bool>> whereLambda)
        {
            return db.College.Where(whereLambda).AsQueryable();
        }

        public College Add(College College)
        {
            db.College.Add(College);
            db.SaveChanges();
            return College;
        }

        public bool Update(College College)
        {
            try
            {
                db.Entry(College).State = System.Data.EntityState.Modified;
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
            //var College = db.College.FirstOrDefault(d => d.TeacherId == id);
            //db.College.Remove(College);
            return db.SaveChanges() > 0;
        }
    }
}
