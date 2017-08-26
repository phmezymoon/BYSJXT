using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IDepartmentService
    {
        IQueryable<Department> GetEntities(Expression<Func<Department, bool>> whereLambda);

        Department Add(Department Department);

        bool Update(Department Department);

        bool Detele(int id);

    }
}
