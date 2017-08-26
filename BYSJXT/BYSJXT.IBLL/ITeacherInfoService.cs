using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface ITeacherInfoService
    {
        IQueryable<TeacherInfo> GetEntities(Expression<Func<TeacherInfo, bool>> whereLambda);

        TeacherInfo Add(TeacherInfo TeacherInfo);

        bool Update(TeacherInfo TeacherInfo);

        bool Detele(int id);

    }
}
