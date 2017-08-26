using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BYSJXT.Model;
using System.Linq.Expressions;
using BYSJXT.IDAL;

namespace BYSJXT.EFDAL
{
    public class DepartmentDal : IDepartmentDal
    {

        BysjxtDB db = DbContextFactory.GetDbContext();

        public IQueryable<Department> GetEntities(Expression<Func<Department, bool>> whereLambda)
        {
            return db.Department.Where(whereLambda).AsQueryable();
        }

        public Department Add(Department Department)
        {
            db.Department.Add(Department);
            db.SaveChanges();
            return Department;
        }

        public bool Update(Department Department)
        {
            try
            {
                db.Entry(Department).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Detele(int id)
        {
            //var Department = db.Department.FirstOrDefault(d => d.TeacherId == id);
            //db.Department.Remove(Department);
            return db.SaveChanges() > 0;
        }
    }
}
