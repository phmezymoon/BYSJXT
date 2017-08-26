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
    public class ClassService : IClassService
    {
        public IClassDal ClassDal { get; set; }


        public IQueryable<Class> GetEntities(Expression<Func<Class, bool>> whereLambda)
        {
            return ClassDal.GetEntities(whereLambda);
        }


        public Class Add(Class Class)
        {
            return ClassDal.Add(Class);
        }

        public bool Update(Class Class)
        {
            return ClassDal.Update(Class);
        }

        public bool Detele(int id)
        {
            return ClassDal.Detele(id);
        }
    }
}
