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
    public class EnergyDataController : Controller
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
        public TBL_ENERGY[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_ENERGY, bool>> whereLambda, Expression<Func<TBL_ENERGY, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_ENERGY.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_ENERGY.ToList().Count;
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
        public TBL_ENERGY[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_ENERGY, bool>> whereLambda, Expression<Func<TBL_ENERGY, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_ENERGY.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_ENERGY.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: EnergyData
        public ActionResult Index()
        {
            int sumPage = GetSumPage(15);
            int nowPage = 1;
            TBL_ENERGY[] energyInfo = GetPagedList(1, 15, u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.energyInfo = energyInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.siteInfo = siteInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 能耗数据查询
        [HttpPost]
        public ActionResult EnergyDataSelect(string siteName, TBL_ENERGY energy)
        {
            try
            {
                if (energy.siteId != 0)
                {
                    //如果有站点号，按照站点号查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_ENERGY[] energyInfo = GetPagedList(1, 30, u => u.siteId == energy.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.energyInfo = energyInfo;
                    ViewBag.siteInfo = siteInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if (energy.energyDate != null)
                {
                    //如果输入了时间，按时间查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_ENERGY[] energyInfo = GetPagedList(1, 30, u => u.energyDate == energy.energyDate, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.energyInfo = energyInfo;
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
                    TBL_ENERGY[] energyInfo = GetPagedList(1, 30, u => u.siteId == siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (siteInfo == null || siteInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.energyInfo = energyInfo;
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