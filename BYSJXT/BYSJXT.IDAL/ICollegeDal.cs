using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface ICollegeDal
    {
        IQueryable<College> GetEntities(Expression<Func<College, bool>> whereLambda);

        College Add(College entity);

        bool Update(College entity);

        bool Detele(int id);
    }
}
