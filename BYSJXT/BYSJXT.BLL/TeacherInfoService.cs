using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.IBLL;
using BYSJXT.IDAL;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.BLL
{
    public class TeacherInfoService : ITeacherInfoService
    {
        public ITeacherInfoDal TeacherInfoDal { get; set; }

        public IQueryable<TeacherInfo> GetEntities(Expression<Func<TeacherInfo, bool>> whereLambda)
        {
            return TeacherInfoDal.GetEntities(whereLambda);
        }


        public TeacherInfo Add(TeacherInfo TeacherInfo)
        {
            return TeacherInfoDal.Add(TeacherInfo);
        }

        public bool Update(TeacherInfo TeacherInfo)
        {
            return TeacherInfoDal.Update(TeacherInfo);
        }

        public bool Detele(int id)
        {
            return TeacherInfoDal.Detele(id);
        }
    }
}
