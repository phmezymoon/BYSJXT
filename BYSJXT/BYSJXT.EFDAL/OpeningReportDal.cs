using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BYSJXT.Model;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class OpeningReportDal : IOpeningReportDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();


        public IQueryable<OpeningReport> GetEntities(Expression<Func<OpeningReport, bool>> whereLambda)
        {
            return db.OpeningReport.Where(whereLambda).AsQueryable();
        }

        public OpeningReport Add(OpeningReport OpeningReport)
        {
            db.OpeningReport.Add(OpeningReport);
            db.SaveChanges();
            return OpeningReport;
        }

        public bool Update(OpeningReport OpeningReport)
        {
            try
            {
                db.Entry(OpeningReport).State = System.Data.EntityState.Modified;
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
            //var OpeningReport = db.OpeningReport.FirstOrDefault(d => d.TeacherId == id);
            //db.OpeningReport.Remove(OpeningReport);
            return db.SaveChanges() > 0;
        }
    }
}
