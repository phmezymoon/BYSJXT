using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IClassService
    {
        IQueryable<Class> GetEntities(Expression<Func<Class, bool>> whereLambda);

        Class Add(Class Class);

        bool Update(Class Class);

        bool Detele(int id);

    }
}
