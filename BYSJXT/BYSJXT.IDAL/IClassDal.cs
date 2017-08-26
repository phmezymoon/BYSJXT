using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IClassDal
    {
        IQueryable<Class> GetEntities(Expression<Func<Class, bool>> whereLambda);

        Class Add(Class entity);

        bool Update(Class entity);

        bool Detele(int id);
    }
}
