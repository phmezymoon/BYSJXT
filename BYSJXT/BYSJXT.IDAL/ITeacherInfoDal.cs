using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface ITeacherInfoDal
    {
        IQueryable<TeacherInfo> GetEntities(Expression<Func<TeacherInfo, bool>> whereLambda);

        TeacherInfo Add(TeacherInfo entity);

        bool Update(TeacherInfo entity);

        bool Detele(int id);
    }
}
