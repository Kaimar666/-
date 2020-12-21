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

    public class CenterControlController : Controller
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
        public TBL_CTRCONTROL[] GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_CTRCONTROL, bool>> whereLambda, Expression<Func<TBL_CTRCONTROL, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_CTRCONTROL.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPage(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_CTRCONTROL.ToList().Count;
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
        public TBL_CTRCONTROL[] GetPagedListArea<TKey>(int pageIndex, int pageSize, Expression<Func<TBL_CTRCONTROL, bool>> whereLambda, Expression<Func<TBL_CTRCONTROL, TKey>> orderBy)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                //分页时一定注意：Skip之前一定要OrderBy
                return db.TBL_CTRCONTROL.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
            }
        }

        public int GetSumPageArea(int pageSize)
        {
            using (LampNetEntities db = new LampNetEntities())
            {
                int listSum = db.TBL_CTRCONTROL.ToList().Count;
                if ((listSum != 0) && listSum % pageSize == 0)
                {
                    return (listSum / pageSize);
                }
                return ((listSum / pageSize) + 1);
            }
        }

        #endregion
        // GET: CenterControl
        //集中控制
        public ActionResult CenterControl()
        {
            int sumPage = GetSumPage(30);
            int nowPage = 1;
            TBL_CTRCONTROL[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.nowPage = nowPage;
            ViewBag.sumPage = sumPage;
            TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.sitearray = sitearray;
            ViewBag.allInfo = allInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 集控信息查询
        [HttpPost]
        public ActionResult CenterControlSelect(string siteName, TBL_CTRCONTROL ctr)
        {
            try
            {
                if (ctr.siteId != 0)
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_CTRCONTROL[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] info = SelectTools.SelectSiteInfo(u => u.siteId == ctr.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = sitearray;
                    ViewBag.allInfo = allInfo;
                    ViewBag.info = info;

                    HttpCookie cookie = Request.Cookies["userId"];
                    if (cookie.Name != null)
                    {
                        ViewBag.user = cookie.Value;
                    }

                    return View();
                }
                else if(siteName != null)
                {
                    int sumPage = GetSumPage(30);
                    int nowPage = 1;
                    TBL_CTRCONTROL[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
                    ViewBag.nowPage = nowPage;
                    ViewBag.sumPage = sumPage;
                    TBL_SITE[] info = SelectTools.SelectSiteInfo(u => u.siteName == siteName, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = sitearray;
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
                    return Content("没有查询内容！");
                }
            }
            catch
            {
                return Content("查询失败！（ERROR）");
            }
        }
        #endregion

        #region 集控信息删除
        [HttpGet]
        public string CenterControlDelete(int siteId)
        {
            try
            {
                if (DeleteTools.DeleteCtrcontrolInfo(u => u.siteId == siteId) == true)
                {

                    Response.Write("<script>alert('删除成功！');</script>");
                    Response.Redirect("/CenterControl/CenterControl");
                    return "success";
                }
                else
                {

                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/CenterControl/CenterControl");
                    return "不存在删除内容！";
                }
            }
            catch
            {

                Response.Write("<script>alert('删除失败！');</script>");
                Response.Redirect("/CenterControl/CenterControl");
                return "删除失败！（ERROR）";
            }
        }
        
        #endregion

        //集中设置-时钟设置
        public ActionResult CenterSettingTime()
        {
            TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_CTRCONTROL[] ctrarray = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
            ViewBag.sitearray = sitearray;
            ViewBag.ctrarray = ctrarray;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }
        #region 集中设置-时钟更新
        public void CenterSettingTimeUpdate()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                TBL_CTRCONTROL[] ctrarray = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
                foreach (var info in ctrarray)
                {
                    DateTime td = DateTime.Now;
                    info.ctrcontrolSystime = td;
                    if(td.DayOfWeek.ToString() == "Monday")
                    {
                        info.ctrcontrolSysweek = 1;
                    }
                    else if(td.DayOfWeek.ToString() == "Tuesday")
                    {
                        info.ctrcontrolSysweek = 2;
                    }
                    else if (td.DayOfWeek.ToString() == "Wednesday")
                    {
                        info.ctrcontrolSysweek = 3;
                    }
                    else if (td.DayOfWeek.ToString() == "Thursday")
                    {
                        info.ctrcontrolSysweek = 4;
                    }
                    else if (td.DayOfWeek.ToString() == "Friday")
                    {
                        info.ctrcontrolSysweek = 5;
                    }
                    else if (td.DayOfWeek.ToString() == "Saturday")
                    {
                        info.ctrcontrolSysweek = 6;
                    }
                    else
                    {
                        info.ctrcontrolSysweek = 7;
                    }

                    if (UpdateTools.UpdateCtrcontrolInfo(u => u.siteId == info.siteId, info) == true)
                    {

                        Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                        Response.Redirect("/CenterControl/CenterSettingTime");
                    }
                    else
                    {

                        Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                        Response.Redirect("/CenterControl/CenterSettingTime");
                    }
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/CenterControl/CenterSettingTime");
            }
        }
        #endregion

        //集中设置-光控设置
        public ActionResult CenterSettingLight()
        {
            TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_CTRCONTROL[] ctrarray = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_CTRCONTROL[] allInfo = GetPagedList(1, 30, u => u.siteId == u.siteId, u => u.siteId);
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.allInfo = allInfo;
            ViewBag.info = ctrarray[0];
            ViewBag.sitearray = sitearray;
            ViewBag.ctrarray = ctrarray;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 光控设置查询
        [HttpPost]
        public ActionResult CenterSettingLightSelect(TBL_SITE siteinfo)
        {
            try
            {
                if (siteinfo.siteId != 0)
                {
                    TBL_CTRCONTROL[] allInfo = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_CTRCONTROL[] info = SelectTools.SelectCtrcontrolInfo(u => u.siteId == siteinfo.siteId, u => u.siteId);
                    TBL_SITE[] site = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = site;
                    ViewBag.allInfo = allInfo;
                    ViewBag.info = info;
                    return View();
                }
                else
                {
                    TBL_SITE[] search = SelectTools.SelectSiteInfo(u => u.siteName == siteinfo.siteName, u => u.siteId);
                    int id = search[0].siteId;
                    TBL_CTRCONTROL[] allInfo = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_CTRCONTROL[] info = SelectTools.SelectCtrcontrolInfo(u => u.siteId == id, u => u.siteId);
                    TBL_SITE[] site = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = site;
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

        #region 光控设置修改
        [HttpPost]
        public void CenterSettingLightUpdate(TBL_CTRCONTROL ctr)
        {
            try
            {
                if (UpdateTools.UpdateCtrcontrolInfo(u => u.siteId == ctr.siteId, ctr) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/CenterControl/CenterSettingLight");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/CenterControl/CenterSettingLight");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/CenterControl/CenterSettingLight");
            }
        }
        #endregion

        //集中设置-定时设置
        public ActionResult CenterSettingSetTime()
        {
            TBL_SITE[] sitearray = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_CTRCONTROL[] ctrarray = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.sitearray = sitearray;
            ViewBag.ctrarray = ctrarray;
            ViewBag.allInfo = ctrarray;
            return View();
        }

        #region 定时设置查询
        [HttpPost]
        public ActionResult CenterSettingSetTimeSelect(TBL_SITE siteinfo)
        {
            try
            {
                if (siteinfo.siteId != 0)
                {
                    TBL_CTRCONTROL[] allInfo = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_CTRCONTROL[] info = SelectTools.SelectCtrcontrolInfo(u => u.siteId == siteinfo.siteId, u => u.siteId);
                    TBL_SITE[] site = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = site;
                    ViewBag.allInfo = allInfo;
                    ViewBag.info = info;
                    return View();
                }
                else
                {
                    TBL_SITE[] search = SelectTools.SelectSiteInfo(u => u.siteName == siteinfo.siteName, u => u.siteId);
                    int id = search[0].siteId;
                    TBL_CTRCONTROL[] allInfo = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);
                    TBL_CTRCONTROL[] info = SelectTools.SelectCtrcontrolInfo(u => u.siteId == id, u => u.siteId);
                    TBL_SITE[] site = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
                    if (info == null || info.Length == 0)
                    {
                        return Content("没有此展示！");
                    }
                    if (Request.Cookies["userId"] != null)
                    {
                        string user = Request.Cookies["userId"].Value;//输出全部的值
                        ViewBag.user = user;
                    }
                    ViewBag.sitearray = site;
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

        #region 定时设置修改
        [HttpPost]
        public void CenterSettingSetTimeUpdate(string opehour, string opeminute, string opesecond, string clohour, string clominute, string closecond, TBL_CTRCONTROL ctr)
        {
            try
            {
                string opetime = opehour + ':' + opeminute + ':' + opesecond;
                string clotime = clohour + ':' + clominute + ':' + closecond;
                if (UpdateTools.UpdateCtrcontrolInfo(u => u.siteId == ctr.siteId, ctr) == true)
                {

                    Response.Write("<script language='javascript'>alert('更新成功！');</script>");
                    Response.Redirect("/CenterControl/CenterSettingSetTime");
                }
                else
                {

                    Response.Write("<script language='javascript'>alert('更新失败！');</script>");
                    Response.Redirect("/CenterControl/CenterSettingSetTime");
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('更新出错！');</script>");
                Response.Redirect("/CenterControl/CenterSettingSetTime");
            }
        }
        #endregion
    }
}