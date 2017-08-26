using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BYSJXT.Model;

namespace BYSJXT.IDAL
{
    public interface IStudentSubjectDal
    {
        IQueryable<StudentSubject> GetEntities(Expression<Func<StudentSubject, bool>> whereLambda);

        StudentSubject Add(StudentSubject entity);

        bool Update(StudentSubject entity);

        bool Detele(int id);
    }
}
