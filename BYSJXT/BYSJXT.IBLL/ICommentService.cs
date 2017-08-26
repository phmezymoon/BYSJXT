using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface ICommentService
    {
        IQueryable<Comment> GetEntities(Expression<Func<Comment, bool>> whereLambda);

        Comment Add(Comment Comment);

        bool Update(Comment Comment);

        bool Detele(int id);

    }
}
