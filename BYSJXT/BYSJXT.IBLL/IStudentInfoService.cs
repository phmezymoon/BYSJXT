using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IStudentInfoService
    {
        IQueryable<StudentInfo> GetEntities(Expression<Func<StudentInfo, bool>> whereLambda);

        StudentInfo Add(StudentInfo StudentInfo);

        bool Update(StudentInfo StudentInfo);

        bool Detele(int id);

    }
}
