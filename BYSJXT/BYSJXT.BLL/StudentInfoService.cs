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
    public class StudentInfoService : IStudentInfoService
    {
        public IStudentInfoDal StudentInfoDal { get; set; }


        public IQueryable<StudentInfo> GetEntities(Expression<Func<StudentInfo, bool>> whereLambda)
        {
            return StudentInfoDal.GetEntities(whereLambda);
        }


        public StudentInfo Add(StudentInfo StudentInfo)
        {
            return StudentInfoDal.Add(StudentInfo);
        }

        public bool Update(StudentInfo StudentInfo)
        {
            return StudentInfoDal.Update(StudentInfo);
        }

        public bool Detele(int id)
        {
            return StudentInfoDal.Detele(id);
        }
    }
}
