using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using BYSJXT.IDAL;
using System.Linq.Expressions;
using BYSJXT.IBLL;
using BYSJXT.EFDAL;

namespace BYSJXT.BLL
{
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentDal DepartmentDal { get; set; }

        public IQueryable<Department> GetEntities(Expression<Func<Department, bool>> whereLambda)
        {
            return DepartmentDal.GetEntities(whereLambda);
        }


        public Department Add(Department Department)
        {
            return DepartmentDal.Add(Department);
        }

        public bool Update(Department Department)
        {
            return DepartmentDal.Update(Department);
        }

        public bool Detele(int id)
        {
            return DepartmentDal.Detele(id);
        }
    }
}
