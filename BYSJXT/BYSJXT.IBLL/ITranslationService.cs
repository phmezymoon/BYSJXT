using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface ITranslationService
    {
        IQueryable<Translation> GetEntities(Expression<Func<Translation, bool>> whereLambda);

        Translation Add(Translation Translation);

        bool Update(Translation Translation);

        bool Detele(int id);

    }
}
