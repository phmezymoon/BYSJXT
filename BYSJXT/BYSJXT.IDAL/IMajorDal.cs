using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IMajorDal
    {
        IQueryable<Major> GetEntities(Expression<Func<Major, bool>> whereLambda);

        Major Add(Major entity);

        bool Update(Major entity);

        bool Detele(int id);
    }
}
