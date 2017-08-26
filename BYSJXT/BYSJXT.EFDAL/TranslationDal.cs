using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class TranslationDal : ITranslationDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<Translation> GetEntities(Expression<Func<Translation, bool>> whereLambda)
        {
            return db.Translation.Where(whereLambda).AsQueryable();
        }

        public Translation Add(Translation Translation)
        {
            db.Translation.Add(Translation);
            db.SaveChanges();
            return Translation;
        }

        public bool Update(Translation Translation)
        {
            try
            {
                db.Entry(Translation).State = System.Data.EntityState.Modified;
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
            //var Translation = db.Translation.FirstOrDefault(d => d.TeacherId == id);
            //db.Translation.Remove(Translation);
            return db.SaveChanges() > 0;
        }
    }
}
