using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface ISubjectInfoService
    {
        IQueryable<SubjectInfo> GetEntities(Expression<Func<SubjectInfo, bool>> whereLambda);

        SubjectInfo Add(SubjectInfo SubjectInfo);

        bool Update(SubjectInfo SubjectInfo);

        bool Detele(int id);

    }
}
