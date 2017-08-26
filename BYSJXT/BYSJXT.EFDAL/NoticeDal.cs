using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class NoticeDal : INoticeDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<Notice> GetEntities(Expression<Func<Notice, bool>> whereLambda)
        {
            return db.Notice.Where(whereLambda).AsQueryable();
        }

        public Notice Add(Notice Notice)
        {
            db.Notice.Add(Notice);
            db.SaveChanges();
            return Notice;
        }

        public bool Update(Notice Notice)
        {
            try
            {
                db.Entry(Notice).State = System.Data.EntityState.Modified;
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
            var Notice = db.Notice.FirstOrDefault(d => d.Id == id);
            db.Notice.Remove(Notice);
            return db.SaveChanges() > 0;
        }
    }
}
