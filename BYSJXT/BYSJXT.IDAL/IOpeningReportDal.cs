using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IOpeningReportDal
    {
        IQueryable<OpeningReport> GetEntities(Expression<Func<OpeningReport, bool>> whereLambda);

        OpeningReport Add(OpeningReport entity);

        bool Update(OpeningReport entity);

        bool Detele(int id);
    }
}
