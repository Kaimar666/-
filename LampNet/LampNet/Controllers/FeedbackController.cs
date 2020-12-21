using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using LampNet.Models;
using LampNet.Areas.ToolsHelper;
using System.Text.RegularExpressions;

namespace LampNet.Controllers
{
    public class FeedbackController : Controller
    {
        #region 分页类
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排列 lambda表达式</param>
        /// <returns></returns>
        public TBL_FEEDBACK[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_FEEDBACK, bool>> whereLambda, Expression<Func<TBL_FEEDBACK, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_FEEDBACK.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_FEEDBACK.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排列 lambda表达式</param>
        /// <returns></returns>
        public TBL_FEEDBACK[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_FEEDBACK, bool>> whereLambda, Expression<Func<TBL_FEEDBACK, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_FEEDBACK.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_FEEDBACK.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion

        // GET: Feedback
        public ActionResult Index()
        {
            int sumPage = GetSumPage(10);
            int nowPage = 1;
            TBL_FEEDBACK[] feedbackInfo = GetPagedList(1, 10, u => u.userId == u.userId, u => u.userId);
            if (feedbackInfo == null || feedbackInfo.Count() == 0)
            {
                Response.Write("<script>alert('无查询信息！');</script>");
            }
            ViewBag.feedbackInfo = feedbackInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.userInfo = userInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 反馈信息添加
        public ActionResult FeedbackAdd()
        {
            return Content("");
        }
        #endregion

        #region 反馈信息编辑
        [HttpPost]
        public ActionResult FeedbackInput(int userId)
        {
            if(userId == 0)
            {
                return View("Index");
            }
            else
            {
                TBL_FEEDBACK[] feedbackInfo = SelectTools.SelectFeedbackInfo(u => u.userId == userId, u => u.userId);
                if (feedbackInfo == null || feedbackInfo.Count() == 0)
                {
                    Response.Write("<script>alert('无查询信息！');</script>");
                }
                ViewBag.feedbackInfo = feedbackInfo;
                if (Request.Cookies["userId"] != null)
                {
                    string user = Request.Cookies["userId"].Value;//输出全部的值
                    ViewBag.user = user;
                }
                TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                ViewBag.userInfo = userInfo;

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                return View();
            }
        }
        #endregion

        #region 反馈信息删除
        public ActionResult FeedbackDelete()
        {
            return View();
        }
        #endregion

        #region 反馈信息查询
        [HttpPost]
        public ActionResult FeedbackSelect(TBL_USER user)
        {
            try
            {
                if (user.userId != 0)
                {
                    int sumPage = GetSumPage(10);
                    int nowPage = 1;
                    TBL_FEEDBACK[] info = GetPagedList(1, 10, u => u.userId == user.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] allUserInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    TBL_FEEDBACK[] allInfo = GetPagedList(1, 10, u => u.userId == u.userId, u => u.userId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string userName = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = userName;
                    }
                    ViewBag.allInfo = allInfo;
                    ViewBag.allUserInfo = allUserInfo;
                    ViewBag.info = info;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    int sumPage = GetSumPage(10);
                    int nowPage = 1;
                    TBL_USER[] userId = SelectTools.SelectUserInfo(u => u.userName == user.userName, u => u.userId);
                    int id = userId[0].userId;
                    TBL_FEEDBACK[] info = GetPagedList(1, 10, u => u.userId == id, u => u.userId);
                    TBL_FEEDBACK[] allInfo = GetPagedList(1, 10, u => u.userId == u.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] allUserInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string userName = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = userName;
                    }
                    ViewBag.allInfo = allInfo;
                    ViewBag.allUserInfo = allUserInfo;
                    ViewBag.info = info;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
            }
            catch
            {
                return Content("查询失败！（ERROR）");
            }
        }
        #endregion

        #region 反馈信息插入
        [HttpPost]
        public void FeedbackUpdate(TBL_FEEDBACK info)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                DateTime dt = DateTime.Now;
                info.feedbackTime = dt;
                if (InsertTools.InsertFeedbackInfo(info) == true)
                {

                    Response.Write("<script>alert('删除成功！');</script>");
                    Response.Redirect("/Feedback/Index");
                }
                else
                {

                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/Feedback/Index");
                }
            }
            catch
            {

                Response.Write("<script>alert('删除失败！');</script>");
                Response.Redirect("/Feedback/Index");
            }
        }
        #endregion
    }
}