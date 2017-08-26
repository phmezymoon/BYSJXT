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
    public class CommentService : ICommentService
    {
        public ICommentDal CommentDal { get; set; }


        public IQueryable<Comment> GetEntities(Expression<Func<Comment, bool>> whereLambda)
        {
            return CommentDal.GetEntities(whereLambda);
        }


        public Comment Add(Comment Comment)
        {
            return CommentDal.Add(Comment);
        }

        public bool Update(Comment Comment)
        {
            return CommentDal.Update(Comment);
        }

        public bool Detele(int id)
        {
            return CommentDal.Detele(id);
        }
    }
}
