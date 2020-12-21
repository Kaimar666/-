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
    public class ProtectDataUserController : Controller
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
        public TBL_USERPROTECT[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_USERPROTECT, bool>> whereLambda, Expression<Func<TBL_USERPROTECT, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_USERPROTECT.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_USERPROTECT.ToList().Count;
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
        public TBL_USERPROTECT[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_USERPROTECT, bool>> whereLambda, Expression<Func<TBL_USERPROTECT, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_USERPROTECT.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_USERPROTECT.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion

        // GET: ProtectDataUser
        public ActionResult Index()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_USERPROTECT[] ProtectUserInfo = GetPagedList(1, 30, u => u.userId == u.userId, u => u.userId);
            ViewBag.ProtectUserInfo = ProtectUserInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
            ViewBag.userInfo = userInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }
            return View();
        }

        #region 设备维护信息查询
        [HttpPost]
        public ActionResult ProtectDataUserSelect(TBL_USERPROTECT table)
        {
            try
            {
                if (table.userId != 0)
                {
                    //如果有站点号，按照站点号查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_USERPROTECT[] ProtectUserInfo = GetPagedList(1, 30, u => u.userId == table.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    if (userInfo == null || userInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.ProtectUserInfo = ProtectUserInfo;
                    ViewBag.userInfo = userInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }
                    return View();
                }
                else if (table.userprotectKind != -1)
                {
                    //如果输入了时间，按时间查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_USERPROTECT[] ProtectUserInfo = GetPagedList(1, 30, u => u.userprotectKind == table.userprotectKind, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    if (userInfo == null || userInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.ProtectUserInfo = ProtectUserInfo;
                    ViewBag.userInfo = userInfo;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }
                    return View();
                }
                else if (table.userprotectModule != -1)
                {
                    //如果没有时间和站点号，则按照名称查找
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_USERPROTECT[] ProtectUserInfo = GetPagedList(1, 30, u => u.userprotectModule == table.userprotectModule, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] userInfo = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
                    if (userInfo == null || userInfo.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    ViewBag.ProtectUserInfo = ProtectUserInfo;
                    ViewBag.userInfo = userInfo;

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

        #region 设备维护信息添加
        public ActionResult ProtectDataUserAdd()
        {
            return View();
        }
        #endregion

        #region 设备维护信息删除
        public ActionResult ProtectDataUserDelete()
        {
            return View();
        }
        #endregion

        #region 设备维护信息修改
        public ActionResult ProtectDataUserUpdate()
        {
            return View();
        }
        #endregion
    }
}