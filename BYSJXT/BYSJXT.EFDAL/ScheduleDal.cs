using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class ScheduleDal : IScheduleDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<Schedule> GetEntities(Expression<Func<Schedule, bool>> whereLambda)
        {
            return db.Schedule.Where(whereLambda).AsQueryable();
        }

        public Schedule Add(Schedule Schedule)
        {
            db.Schedule.Add(Schedule);
            db.SaveChanges();
            return Schedule;
        }

        public bool Update(Schedule Schedule)
        {
            try
            {
                db.Entry(Schedule).State = System.Data.EntityState.Modified;
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
            //var Schedule = db.Schedule.FirstOrDefault(d => d.TeacherId == id);
            //db.Schedule.Remove(Schedule);
            return db.SaveChanges() > 0;
        }
    }
}
