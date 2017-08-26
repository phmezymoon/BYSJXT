using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface ITranslationDal
    {
        IQueryable<Translation> GetEntities(Expression<Func<Translation, bool>> whereLambda);

        Translation Add(Translation entity);

        bool Update(Translation entity);

        bool Detele(int id);
    }
}
