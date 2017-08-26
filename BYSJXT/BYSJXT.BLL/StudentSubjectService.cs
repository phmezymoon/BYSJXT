using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.IDAL;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class StudentSubjectService : IStudentSubjectService
    {
        public IStudentSubjectDal StudentSubjectDal { get; set; }


        public IQueryable<StudentSubject> GetEntities(Expression<Func<StudentSubject, bool>> whereLambda)
        {
            return StudentSubjectDal.GetEntities(whereLambda);
        }


        public StudentSubject Add(StudentSubject StudentSubject)
        {
            return StudentSubjectDal.Add(StudentSubject);
        }

        public bool Update(StudentSubject StudentSubject)
        {
            return StudentSubjectDal.Update(StudentSubject);
        }

        public bool Detele(int id)
        {
            return StudentSubjectDal.Detele(id);
        }
    }
}
