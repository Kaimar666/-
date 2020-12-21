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
    public class SingleControlController : Controller
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
        public TBL_SIGCONTROL[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_SIGCONTROL, bool>> whereLambda, Expression<Func<TBL_SIGCONTROL, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_SIGCONTROL.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_SIGCONTROL.ToList().Count;
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
        public TBL_SIGCONTROL[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_SIGCONTROL, bool>> whereLambda, Expression<Func<TBL_SIGCONTROL, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_SIGCONTROL.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_SIGCONTROL.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: SingleControl
        //单灯控制
        public ActionResult SingleControl()
        {
            TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            if (array == null || array.Length == 0)
            {
                return Content("没有此展示！");
            }
            ViewBag.ammeter = ammeter;
            ViewBag.array = array;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 单灯查询
        [HttpPost]
        public ActionResult SingleControlSelect(TBL_AMMETER info)
        {
            try
            {
                if (info.ammeterId != 0)
                {
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == info.ammeterId, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    TBL_AMMETER[] amt = SelectTools.SelectAmmeterInfo(u => u.ammeterName == info.ammeterName, u => u.ammeterId);
                    int id = amt[0].ammeterId;
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == id, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

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

        #region 单灯修改
        [HttpPost]
        public void SingleControlUpdate(TBL_SIGCONTROL sig)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (UpdateTools.UpdateSigcontrolInfo(u => u.ammeterId == sig.ammeterId, sig) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/SingleControl/SingleControl");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/SingleControl/SingleControl");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/SingleControl/SingleControl");
            }
        }
        #endregion

        //单灯设置-感应时间
        public ActionResult SingleSettingTime()
        {
            TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            ViewBag.ammeter = ammeter;
            ViewBag.allInfo = allInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }
        #region 感应时间查询
        [HttpPost]
        public ActionResult SingleSettingTimeSelect(TBL_AMMETER info)
        {
            try
            {
                if (info.ammeterId != 0)
                {
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == info.ammeterId, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    TBL_AMMETER[] amt = SelectTools.SelectAmmeterInfo(u => u.ammeterName == info.ammeterName, u => u.ammeterId);
                    int id = amt[0].ammeterId;
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == id, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

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

        #region 感应时间修改
        [HttpPost]
        public void SingleSettingTimeUpdate(TBL_SIGCONTROL sig)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (UpdateTools.UpdateSigcontrolInfo(u => u.ammeterId == sig.ammeterId, sig) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingTime");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingTime");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/SingleControl/SingleSettingTime");
            }
        }
        #endregion

        //单灯设置-分组
        public ActionResult SingleSettingGroup()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_SIGCONTROL[] allInfo = GetPagedList(1, 30, u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            ViewBag.allInfo = allInfo;
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_AMMETER[] AmmeterList = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            ViewBag.ammeterlist = AmmeterList;
            ViewBag.sigarray = array;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 分组信息更新
        [HttpPost]
        public void SingleSettingGroupUpdate(TBL_AMMETER info)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (UpdateTools.UpdateAmmeterInfo(u => u.ammeterId == info.ammeterId, info) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingGroup");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingGroup");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/SingleControl/SingleSettingGroup");
            }
        }
        #endregion

        //单灯设置-巡检
        public ActionResult SingleSettingInspection()
        {
            TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            ViewBag.allInfo = allInfo;
            ViewBag.ammeter = ammeter;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 巡检时间查询
        [HttpPost]
        public ActionResult SingleSettingInspectionSelect(TBL_AMMETER info)
        {
            try
            {
                if (info.ammeterId != 0)
                {
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == info.ammeterId, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else
                {
                    TBL_AMMETER[] amt = SelectTools.SelectAmmeterInfo(u => u.ammeterName == info.ammeterName, u => u.ammeterId);
                    int id = amt[0].ammeterId;
                    TBL_SIGCONTROL[] array = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == id, u => u.ammeterId);
                    TBL_AMMETER[] ammeter = SelectTools.SelectAmmeterInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    if (array == null || array.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SIGCONTROL[] allInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
                    ViewBag.allInfo = allInfo;
                    ViewBag.ammeter = ammeter;
                    ViewBag.array = array;

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

        #region 巡检时间修改
        [HttpPost]
        public void SingleSettingInspectionUpdate(TBL_SIGCONTROL sig)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (UpdateTools.UpdateSigcontrolInfo(u => u.ammeterId == sig.ammeterId, sig) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingInspection");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/SingleControl/SingleSettingInspection");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/SingleControl/SingleSettingInspection");
            }
        }
        #endregion
    }
}