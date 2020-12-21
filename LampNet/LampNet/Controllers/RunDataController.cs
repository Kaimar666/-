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

namespace LampNet.Controllers
{
    public class RunDataController : Controller
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
        public TBL_RUN[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_RUN, bool>> whereLambda, Expression<Func<TBL_RUN, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_RUN.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_RUN.ToList().Count;
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
        public TBL_RUN[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_RUN, bool>> whereLambda, Expression<Func<TBL_RUN, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_RUN.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_RUN.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: RunData
        public ActionResult Index()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_RUN[] runInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.runInfo = runInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.siteInfo = siteInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 运行数据查询
        [HttpPost]
        public ActionResult RunDataSelect(string siteName, TBL_RUN run)
        {
            try
            {
                if (run.siteId != 0)
                {
                    //如果有站点号，按照站点号查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_RUN[] runInfo = GetPagedList(1, 30, u => u.siteId == run.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.runInfo = runInfo;
                    ViewBag.siteInfo = siteInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if(run.runFreshtime != null)
                {
                    //如果输入了时间，按时间查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
                    DateTime dt = Convert.ToDateTime(run.runFreshtime);
                    TBL_RUN[] runInfo = GetPagedList(1, 30, u => u.runFreshtime == dt, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.runInfo = runInfo;
                    ViewBag.siteInfo = siteInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    //如果没有时间和站点号，则按照名称查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_SITE[] info = SelectTools.SelectSiteInfo(u => u.siteName == siteName, u => u.siteId);
                    int siteId = info[0].siteId;
                    TBL_RUN[] runInfo = GetPagedList(1, 30, u => u.siteId == siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.runInfo = runInfo;
                    ViewBag.siteInfo = siteInfo;

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
    }
}