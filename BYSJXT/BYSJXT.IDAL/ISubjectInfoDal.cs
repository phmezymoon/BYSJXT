using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface ISubjectInfoDal
    {
        IQueryable<SubjectInfo> GetEntities(Expression<Func<SubjectInfo, bool>> whereLambda);

        SubjectInfo Add(SubjectInfo entity);

        bool Update(SubjectInfo entity);

        bool Detele(int id);
    }
}
