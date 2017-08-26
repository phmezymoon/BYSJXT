using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BYSJXT.Model;

namespace BYSJXT.IBLL
{
    public interface INoticeService
    {
        IQueryable<Notice> GetEntities(Expression<Func<Notice, bool>> whereLambda);

        Notice Add(Notice Notice);

        bool Update(Notice Notice);

        bool Detele(int id);

    }
}
