using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IScheduleService
    {
        IQueryable<Schedule> GetEntities(Expression<Func<Schedule, bool>> whereLambda);

        Schedule Add(Schedule Schedule);

        bool Update(Schedule Schedule);

        bool Detele(int id);

    }
}
