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
    public class UserManagementController : Controller
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
        public TBL_USER[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_USER, bool>> whereLambda, Expression<Func<TBL_USER, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_USER.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_USER.ToList().Count;
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
        public TBL_USER[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_USER, bool>> whereLambda, Expression<Func<TBL_USER, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_USER.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_USER.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: UserManagement
        public ActionResult Index()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_USER[] allInfo = GetPagedList(1, 30, u => u.userId == u.userId, u => u.userId);
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_USER[] array = SelectTools.SelectUserInfo(u => u.userId == u.userId, u => u.userId);
            ViewBag.array = array;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 用户添加
        public ActionResult UserAdd()
        {
            return View();
        }
        #endregion

        #region 用户删除
        public ActionResult UserDelete()
        {
            return View();
        }
        #endregion

        #region 用户修改
        public ActionResult UserUpdate()
        {
            return View();
        }
        #endregion

        #region 用户查询
        [HttpPost]
        public ActionResult UserSelect(TBL_USER user)
        {
            try
            {
                if (user.userId != 0)
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_USER[] allInfo = GetPagedList(1, 30, u => u.userId == u.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] info = SelectTools.SelectUserInfo(u => u.userId == user.userId, u => u.userId);
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
                    TBL_USER[] allInfo = GetPagedList(1, 30, u => u.userId == u.userId, u => u.userId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_USER[] info = SelectTools.SelectUserInfo(u => u.userName == user.userName, u => u.userId);
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