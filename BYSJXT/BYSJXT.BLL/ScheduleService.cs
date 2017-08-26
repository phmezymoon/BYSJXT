using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class ScheduleService : IScheduleService
    {
        public IScheduleDal ScheduleDal { get; set; }


        public IQueryable<Schedule> GetEntities(Expression<Func<Schedule, bool>> whereLambda)
        {
            return ScheduleDal.GetEntities(whereLambda);
        }


        public Schedule Add(Schedule Schedule)
        {
            return ScheduleDal.Add(Schedule);
        }

        public bool Update(Schedule Schedule)
        {
            return ScheduleDal.Update(Schedule);
        }

        public bool Detele(int id)
        {
            return ScheduleDal.Detele(id);
        }
    }
}
