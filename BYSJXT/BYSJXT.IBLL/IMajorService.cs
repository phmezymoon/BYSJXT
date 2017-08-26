using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IMajorService
    {
        IQueryable<Major> GetEntities(Expression<Func<Major, bool>> whereLambda);

        Major Add(Major Major);

        bool Update(Major Major);

        bool Detele(int id);

    }
}
