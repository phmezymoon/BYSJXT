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
    public class TranslationService : ITranslationService
    {
        public ITranslationDal TranslationDal { get; set; }


        public IQueryable<Translation> GetEntities(Expression<Func<Translation, bool>> whereLambda)
        {
            return TranslationDal.GetEntities(whereLambda);
        }


        public Translation Add(Translation Translation)
        {
            return TranslationDal.Add(Translation);
        }

        public bool Update(Translation Translation)
        {
            return TranslationDal.Update(Translation);
        }

        public bool Detele(int id)
        {
            return TranslationDal.Detele(id);
        }
    }
}
