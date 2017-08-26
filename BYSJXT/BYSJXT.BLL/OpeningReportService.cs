using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using BYSJXT.IDAL;
using System.Linq.Expressions;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class OpeningReportService : IOpeningReportService
    {
        public IOpeningReportDal OpeningReportDal { get; set; }


        public IQueryable<OpeningReport> GetEntities(Expression<Func<OpeningReport, bool>> whereLambda)
        {
            return OpeningReportDal.GetEntities(whereLambda);
        }


        public OpeningReport Add(OpeningReport OpeningReport)
        {
            return OpeningReportDal.Add(OpeningReport);
        }

        public bool Update(OpeningReport OpeningReport)
        {
            return OpeningReportDal.Update(OpeningReport);
        }

        public bool Detele(int id)
        {
            return OpeningReportDal.Detele(id);
        }
    }
}
