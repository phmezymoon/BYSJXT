using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using BYSJXT.IDAL;
using System.Linq.Expressions;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class CollegeService : ICollegeService
    {
        public ICollegeDal CollegeDal { get; set; }


        public IQueryable<College> GetEntities(Expression<Func<College, bool>> whereLambda)
        {
            return CollegeDal.GetEntities(whereLambda);
        }


        public College Add(College College)
        {
            return CollegeDal.Add(College);
        }

        public bool Update(College College)
        {
            return CollegeDal.Update(College);
        }

        public bool Detele(int id)
        {
            return CollegeDal.Detele(id);
        }
    }
}
