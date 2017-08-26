using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using BYSJXT.Model;
using BYSJXT.IDAL;
using BYSJXT.IBLL;

namespace BYSJXT.BLL
{
    public class NoticeService : INoticeService
    {
        public INoticeDal NoticeDal { get; set; }


        public IQueryable<Notice> GetEntities(Expression<Func<Notice, bool>> whereLambda)
        {
            return NoticeDal.GetEntities(whereLambda);
        }


        public Notice Add(Notice Notice)
        {
            return NoticeDal.Add(Notice);
        }

        public bool Update(Notice Notice)
        {
            return NoticeDal.Update(Notice);
        }

        public bool Detele(int id)
        {
            return NoticeDal.Detele(id);
        }
    }
}
