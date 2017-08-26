using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Web;
using BYSJXT.Model;
using System.Runtime.Remoting.Messaging;

namespace BYSJXT.EFDAL
{
    public class DbContextFactory
    {
        public static BysjxtDB GetDbContext()
        {
            BysjxtDB dbContext = HttpContext.Current.Items["dbContext"] as BysjxtDB;
            if (dbContext == null)
            {
                dbContext = new BysjxtDB();
                HttpContext.Current.Items["dbContext"] = dbContext;
            }
            return dbContext;

          //  return new BysjxtDB();

            //BysjxtDB obj = CallContext.GetData("DbContext") as BysjxtDB;
            //if (obj == null)
            //{
            //    obj =  new BysjxtDB();
            //    CallContext.SetData("DbContext", obj);
            //}
            //return obj;
        }  
    }
}
