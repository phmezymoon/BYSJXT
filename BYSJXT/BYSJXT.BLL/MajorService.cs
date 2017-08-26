using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.IDAL;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class MajorService : IMajorService
    {
        public IMajorDal MajorDal { get; set; }


        public IQueryable<Major> GetEntities(Expression<Func<Major, bool>> whereLambda)
        {
            return MajorDal.GetEntities(whereLambda);
        }


        public Major Add(Major Major)
        {
            return MajorDal.Add(Major);
        }

        public bool Update(Major Major)
        {
            return MajorDal.Update(Major);
        }

        public bool Detele(int id)
        {
            return MajorDal.Detele(id);
        }
    }
}
