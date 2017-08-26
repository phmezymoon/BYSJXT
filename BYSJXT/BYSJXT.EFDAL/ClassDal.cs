using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class ClassDal : IClassDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<Class> GetEntities(Expression<Func<Class, bool>> whereLambda)
        {
            return db.Class.Where(whereLambda).AsQueryable();
        }

        public Class Add(Class Class)
        {
            db.Class.Add(Class);
            db.SaveChanges();
            return Class;
        }

        public bool Update(Class Class)
        {
            try
            {
                db.Entry(Class).State = System.Data.EntityState.Modified;
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
            //var Class = db.Class.FirstOrDefault(d => d.TeacherId == id);
            //db.Class.Remove(Class);
            return db.SaveChanges() > 0;
        }
    }
}
