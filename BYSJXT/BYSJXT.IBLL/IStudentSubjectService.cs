using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;

namespace BYSJXT.IBLL
{
    public interface IStudentSubjectService
    {
        IQueryable<StudentSubject> GetEntities(Expression<Func<StudentSubject, bool>> whereLambda);

        StudentSubject Add(StudentSubject StudentSubject);

        bool Update(StudentSubject StudentSubject);

        bool Detele(int id);

    }
}
