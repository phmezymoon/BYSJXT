using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BYSJXT.Model;

namespace BYSJXT.IBLL
{
    public interface IOpeningReportService
    {
        IQueryable<OpeningReport> GetEntities(Expression<Func<OpeningReport, bool>> whereLambda);

        OpeningReport Add(OpeningReport OpeningReport);

        bool Update(OpeningReport OpeningReport);

        bool Detele(int id);

    }
}
