using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class SubjectInfoService : ISubjectInfoService
    {
        public ISubjectInfoDal SubjectInfoDal { get; set; }


        public IQueryable<SubjectInfo> GetEntities(Expression<Func<SubjectInfo, bool>> whereLambda)
        {
            return SubjectInfoDal.GetEntities(whereLambda);
        }


        public SubjectInfo Add(SubjectInfo SubjectInfo)
        {
            return SubjectInfoDal.Add(SubjectInfo);
        }

        public bool Update(SubjectInfo SubjectInfo)
        {
            return SubjectInfoDal.Update(SubjectInfo);
        }

        public bool Detele(int id)
        {
            return SubjectInfoDal.Detele(id);
        }
    }
}
