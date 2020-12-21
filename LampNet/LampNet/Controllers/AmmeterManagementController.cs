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
    public class AmmeterManagementController : Controller
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
        public TBL_AMMETER[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_AMMETER, bool>> whereLambda, Expression<Func<TBL_AMMETER, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_AMMETER.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_AMMETER.ToList().Count;
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
        public TBL_AMMETER[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_AMMETER, bool>> whereLambda, Expression<Func<TBL_AMMETER, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_AMMETER.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_AMMETER.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: AmmeterManagement
        public ActionResult Index()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_AMMETER[] allInfo = GetPagedList(1, 30, u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_AMMETER[] array = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);

            ArrayList SiteList = new ArrayList();
            foreach (var item in array)
            {
                //依次获得站点名
                int siteId = Convert.ToInt32(item.siteId);
                TBL_SITE[] siteName = SelectTools.SelectSiteInfo(u => u.siteId == siteId, u => u.siteId);
                if (siteName != null && siteName.Length != 0)
                {
                    SiteList.Add(siteName[0].siteName);
                }
                else
                {
                    SiteList.Add("【出错数据】");
                }
            }
            ViewBag.SiteName = SiteList;
            ViewBag.array = array;

            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }

            return View();
        }

        #region 电表添加
        public ActionResult AmmeterAdd()
        {
            return View();
        }
        #endregion

        #region 电表删除
        [HttpGet]
        public string AmmeterDelete(int ammeterId)
        {
            try
            {
                if (DeleteTools.DeleteAmmeterAmmeterId(ammeterId) == true)
                {

                    Response.Write("<script>alert('删除成功！');</script>");
                    Response.Redirect("/AmmeterManagement/Index");
                    return "success";
                }
                else
                {

                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/AmmeterManagement/Index");
                    return "不存在删除内容！";
                }
            }
            catch
            {

                Response.Write("<script>alert('删除失败！');</script>");
                Response.Redirect("/AmmeterManagement/Index");
                return "删除失败！（ERROR）";
            }
        }
        #endregion

        #region 电表修改
        [HttpPost]
        public ActionResult AmmeterUpdate(int ammeterId)
        {
            TBL_AMMETER[] allInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == ammeterId, u => u.ammeterId);
            TBL_AMMETER[] array = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);

            ArrayList SiteList = new ArrayList();
            foreach (var item in array)
            {
                //依次获得站点名
                int siteId = Convert.ToInt32(item.siteId);
                TBL_SITE[] siteName = SelectTools.SelectSiteInfo(u => u.siteId == siteId, u => u.siteId);
                if (siteName != null && siteName.Length != 0)
                {
                    SiteList.Add(siteName[0].siteName);
                }
                else
                {
                    SiteList.Add("【出错数据】");
                }
            }
            ViewBag.allInfo = allInfo;
            ViewBag.SiteName = SiteList;
            ViewBag.array = array;
            TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.siteInfo = siteInfo;
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            return View();
        }
        [HttpGet]
        public void AmmeterUpdate(TBL_AMMETER info)
        {
            try
            {
                if (UpdateTools.UpdateAmmeterInfo(u => u.ammeterId == info.ammeterId, info) == true)
                {

                    Response.Write("<script>alert('更新成功！');</script>");
                    Response.Redirect("/AmmeterManagement/Index");
                }
                else
                {

                    Response.Write("<script>alert('不存在更新内容！');</script>");
                    Response.Redirect("/AmmeterManagement/Index");
                }
            }
            catch
            {

                Response.Write("<script>alert('更新失败！');</script>");
                Response.Redirect("/AmmeterManagement/Index");
            }
        }
        #endregion

        #region 电表查询
        [HttpPost]
        public ActionResult AmmeterSelect(TBL_AMMETER ammeter)
        {
            try
            {
                if (ammeter.ammeterId != 0)
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_AMMETER[] allInfo = GetPagedList(1, 30, u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_AMMETER[] info = SelectTools.SelectAmmeterInfo(u => u.ammeterId == ammeter.ammeterId, u => u.ammeterId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ArrayList SiteList = new ArrayList();
                    foreach (var item in info)
                    {
                        //依次获得站点名
                        int siteId = Convert.ToInt32(item.siteId);
                        TBL_SITE[] siteName = SelectTools.SelectSiteInfo(u => u.siteId == siteId, u => u.siteId);
                        if (siteName != null && siteName.Length != 0)
                        {
                            SiteList.Add(siteName[0].siteName);
                        }
                        else
                        {
                            SiteList.Add("【出错数据】");
                        }
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.SiteName = SiteList;
                    ViewBag.allInfo = allInfo;
                    ViewBag.info = info;
                    return View();
                }
                else
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_AMMETER[] allInfo = GetPagedList(1, 30, u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_AMMETER[] info = SelectTools.SelectAmmeterInfo(u => u.ammeterName == ammeter.ammeterName, u => u.ammeterId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ArrayList SiteList = new ArrayList();
                    foreach (var item in info)
                    {
                        //依次获得站点名
                        int siteId = Convert.ToInt32(item.siteId);
                        TBL_SITE[] siteName = SelectTools.SelectSiteInfo(u => u.siteId == siteId, u => u.siteId);
                        if (siteName != null && siteName.Length != 0)
                        {
                            SiteList.Add(siteName[0].siteName);
                        }
                        else
                        {
                            SiteList.Add("【出错数据】");
                        }
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.SiteName = SiteList;
                    ViewBag.allInfo = allInfo;
                    ViewBag.info = info;
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