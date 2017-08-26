using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface INoticeDal
    {
        IQueryable<Notice> GetEntities(Expression<Func<Notice, bool>> whereLambda);

        Notice Add(Notice entity);

        bool Update(Notice entity);

        bool Detele(int id);
    }
}
