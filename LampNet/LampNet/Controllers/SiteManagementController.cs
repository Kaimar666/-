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
    public class SiteManagementController : Controller
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
        public TBL_SITE[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_SITE, bool>> whereLambda, Expression<Func<TBL_SITE, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_SITE.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_SITE.ToList().Count;
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
        public TBL_SITE[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_SITE, bool>> whereLambda, Expression<Func<TBL_SITE, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_SITE.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_SITE.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion

        // GET: SiteManagement
        public ActionResult Index()
        {
            int sumPage = GetSumPage(15);
            int nowPage = 1;
            TBL_SITE[] allInfo = GetPagedList(1, 15, u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SITE[] array = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.array = array;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 站点添加
        public ActionResult SiteAdd()
        {
            return View();
        }
        #endregion

        #region 站点删除
        [HttpGet]
        public string SiteDelete(int siteId)
        {
            try
            {
                if (DeleteTools.DeleteSiteSiteId(siteId) == true)
                {
                    
                    Response.Write("<script>alert('删除成功！');</script>");
                    Response.Redirect("/SiteManagement/Index");
                    return "success";
                }
                else
                {
                    
                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/SiteManagement/Index");
                    return "不存在删除内容！";
                }
            }
            catch
            {
                
                Response.Write("<script>alert('删除失败！');</script>");
                Response.Redirect("/SiteManagement/Index");
                return "删除失败！（ERROR）";
            }
        }
        #endregion

        #region 站点修改
        [HttpPost]
        public ActionResult SiteUpdate(int siteId)
        {
            TBL_SITE[] allInfo = SelectTools.SelectSiteInfo(u => u.siteId == siteId, u => u.siteId);
            TBL_SITE[] array = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.array = array;
            ViewBag.allInfo = allInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        [HttpGet]
        public void SiteUpdate(TBL_SITE info)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (UpdateTools.UpdateSiteInfo(u => u.siteId == info.siteId, info) == true)
                {

                    Response.Write("<script>alert('更新成功！');</script>");
                    Response.Redirect("/SiteManagement/Index");
                }
                else
                {

                    Response.Write("<script>alert('不存在更新内容！');</script>");
                    Response.Redirect("/SiteManagement/Index");
                }
            }
            catch
            {

                Response.Write("<script>alert('更新失败！');</script>");
                Response.Redirect("/SiteManagement/Index");
            }
        }
        #endregion

        #region 站点查询
        [HttpPost]
        public ActionResult SiteSelect(TBL_SITE site)
        {
            try
            {
                if (site.siteId != 0)
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_SITE[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] info = SelectTools.SelectSiteInfo(u => u.siteId == site.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.allInfo = allInfo;
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
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_SITE[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] info = SelectTools.SelectSiteInfo(u => u.siteName == site.siteName, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.allInfo = allInfo;
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
    }
}