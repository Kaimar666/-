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
    public class ProtectDataDeviceController : Controller
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
        public TBL_DEVICEPROTECT[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_DEVICEPROTECT, bool>> whereLambda, Expression<Func<TBL_DEVICEPROTECT, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_DEVICEPROTECT.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_DEVICEPROTECT.ToList().Count;
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
        public TBL_DEVICEPROTECT[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_DEVICEPROTECT, bool>> whereLambda, Expression<Func<TBL_DEVICEPROTECT, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_DEVICEPROTECT.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_DEVICEPROTECT.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion

        // GET: ProtectDataDevice
        public ActionResult Index()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.userId == u.userId, u => u.userId);
            ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
            ViewBag.userInfo = userInfo;
            ViewBag.siteInfo = siteInfo;
            ViewBag.ammeterInfo = ammeterInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 设备维护信息添加
        public ActionResult ProtectDataDeviceAdd()
        {
            return View();
        }
        #endregion

        #region 设备维护信息删除
        public ActionResult ProtectDataDeviceDelete()
        {
            return View();
        }
        #endregion

        #region 设备维护信息修改
        public ActionResult ProtectDataDeviceUpdate()
        {
            return View();
        }
        #endregion

        #region 设备维护信息查询
        [HttpPost]
        public ActionResult ProtectDataDeviceSelect(TBL_DEVICEPROTECT table)
        {
            try
            {
                if (table.userId != 0)
                {
                    //按照用户号查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.userId == table.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    ViewBag.userInfo = userInfo;
                    ViewBag.siteInfo = siteInfo;
                    ViewBag.ammeterInfo = ammeterInfo;
                    ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if (table.siteId != -1)
                {
                    //按站点查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.siteId == table.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    ViewBag.userInfo = userInfo;
                    ViewBag.siteInfo = siteInfo;
                    ViewBag.ammeterInfo = ammeterInfo;
                    ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if (table.ammeterId != -1)
                {
                    //按照电表查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.ammeterId == table.ammeterId, u => u.ammeterId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    ViewBag.userInfo = userInfo;
                    ViewBag.siteInfo = siteInfo;
                    ViewBag.ammeterInfo = ammeterInfo;
                    ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if (table.deviceprotectKind != -1)
                {
                    //按照电表查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.deviceprotectKind == table.deviceprotectKind, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    ViewBag.userInfo = userInfo;
                    ViewBag.siteInfo = siteInfo;
                    ViewBag.ammeterInfo = ammeterInfo;
                    ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if (table.deviceprotectModule != -1)
                {
                    //按照电表查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_DEVICEPROTECT[] ProtectDeviceInfo = GetPagedList(1, 30, u => u.deviceprotectModule == table.deviceprotectModule, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    ViewBag.userInfo = userInfo;
                    ViewBag.siteInfo = siteInfo;
                    ViewBag.ammeterInfo = ammeterInfo;
                    ViewBag.ProtectDeviceInfo = ProtectDeviceInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    return Content("查询信息为空！");
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