using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IDAL
{
    public interface IStudentInfoDal
    {
        IQueryable<StudentInfo> GetEntities(Expression<Func<StudentInfo, bool>> whereLambda);

        StudentInfo Add(StudentInfo entity);

        bool Update(StudentInfo entity);

        bool Detele(int id);
    }
}
