using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IDepartmentDal
    {
        IQueryable<Department> GetEntities(Expression<Func<Department, bool>> whereLambda);

        Department Add(Department entity);

        bool Update(Department entity);

        bool Detele(int id);
    }
}
