using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BYSJXT.IBLL;
using BYSJXT.Model;

namespace BYSJXT.UI.Controllers
{
    public class InfoReleaseController : Controller
    {
        
        public INoticeService noticeService { get; set; }

        //查找所有公告
        public ActionResult GetAllNotice()
        {
            var pagaData = noticeService.GetEntities(s => true)
                                          .Select(s => new
                                          {
                                              noticeId = s.Id,
                                              noticeTitle = s.NoticeTitle,
                                              createDate = s.CreateDate,
                                              status = s.Status
                                          }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //根据公告ID获取公告的内容
        public ActionResult GetNoticeContent()
        {
            string noticeId = Request["noticeId"];
            int Id = Convert.ToInt32(noticeId) ;
            var pagaData = noticeService.GetEntities(s => s.Id == Id)
                                          .Select(s => new
                                          {
                                              noticeTitle = s.NoticeTitle,
                                              noticeContent = s.NoticeContent
                                          }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

        //添加公告
        public ActionResult AddNotice()
        {
            string content = Request["content"];
            string title = Request["title"];
            Notice notice = new Notice();
            notice.NoticeContent = content;
            notice.NoticeTitle = title;
            notice.CreateDate = DateTime.Now;
            notice.Status = "未发布";
            noticeService.Add(notice);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //删除公告
        public ActionResult DeleteNotice()
        {
            string noticeId = Request["noticeId"];
            int Id = Convert.ToInt32(noticeId);
            //Notice notice = noticeService.GetEntities(s => s.Id == Id).FirstOrDefault();
            noticeService.Detele(Id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //修改公告
        public ActionResult UpdateNotice()
        {
            string content = Request["content"];
            string title = Request["title"];
            string noticeId = Request["noticeId"];
            int Id = Convert.ToInt32(noticeId);
            Notice notice = noticeService.GetEntities(s => s.Id == Id).FirstOrDefault();
            notice.NoticeContent = content;
            notice.NoticeTitle = title;
            noticeService.Update(notice);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //发布公告
        public ActionResult ReleaseNotice()
        {
            Notice lastNotice = noticeService.GetEntities(s => s.Status == "已发布").FirstOrDefault();
            if (lastNotice != null) {
                lastNotice.Status = "未发布";
                noticeService.Update(lastNotice);
            }
            
            string noticeId = Request["noticeId"];
            int Id = Convert.ToInt32(noticeId);
            Notice notice = noticeService.GetEntities(s => s.Id == Id).FirstOrDefault();
            notice.Status = "已发布";
            
            noticeService.Update(notice);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //获取被发布的公告
        public ActionResult GetReleaseNotice()
        {
            var pagaData = noticeService.GetEntities(s => s.Status == "已发布")
                                          .Select(s => new
                                          {
                                              noticeTitle = s.NoticeTitle,
                                              noticeContent = s.NoticeContent
                                          }).ToList();
            return Json(new { rows = pagaData }, JsonRequestBehavior.AllowGet);
        }

    }
}
