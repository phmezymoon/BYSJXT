using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface ICommentDal
    {
        IQueryable<Comment> GetEntities(Expression<Func<Comment, bool>> whereLambda);

        Comment Add(Comment entity);

        bool Update(Comment entity);

        bool Detele(int id);
    }
}
