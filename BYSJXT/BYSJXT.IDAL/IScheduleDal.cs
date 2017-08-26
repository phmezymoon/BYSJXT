using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IScheduleDal
    {
        IQueryable<Schedule> GetEntities(Expression<Func<Schedule, bool>> whereLambda);

        Schedule Add(Schedule entity);

        bool Update(Schedule entity);

        bool Detele(int id);
    }
}
