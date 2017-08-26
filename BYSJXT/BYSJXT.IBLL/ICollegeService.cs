using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface ICollegeService
    {
        IQueryable<College> GetEntities(Expression<Func<College, bool>> whereLambda);

        College Add(College College);

        bool Update(College College);

        bool Detele(int id);

    }
}
