using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class CommentDal : ICommentDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<Comment> GetEntities(Expression<Func<Comment, bool>> whereLambda)
        {
            return db.Comment.Where(whereLambda).AsQueryable();
        }

        public Comment Add(Comment Comment)
        {
            db.Comment.Add(Comment);
            db.SaveChanges();
            return Comment;
        }

        public bool Update(Comment Comment)
        {
            try
            {
                db.Entry(Comment).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Detele(int id)
        {
            //var Comment = db.Comment.FirstOrDefault(d => d.TeacherId == id);
            //db.Comment.Remove(Comment);
            return db.SaveChanges() > 0;
        }
    }
}
