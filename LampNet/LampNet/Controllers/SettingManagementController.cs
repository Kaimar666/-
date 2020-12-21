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
    public class SettingManagementController : Controller
    {
        // GET: SettingManagement
        public ActionResult Index()
        {
            TBL_SYSSET[] allInfo = SelectTools.SelectSyssetInfo(u => u.syssetId == u.syssetId, u => u.syssetId);
            TBL_SYSSET[] info = SelectTools.SelectSyssetInfo(u => u.syssetId == 1, u => u.syssetId);
            ViewBag.allInfo = allInfo;
            ViewBag.info = info;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 系统设置添加
        public ActionResult SettingAdd()
        {
            return View();
        }
        #endregion

        #region 系统设置删除
        public ActionResult SettingDelete()
        {
            return View();
        }
        #endregion

        #region 系统设置修改
        [HttpPost]
        public string SettingUpdate(TBL_SYSSET set)
        {
            if (UpdateTools.UpdateSyssetInfo(u => u.syssetId == set.syssetId, set) == true)
            {
                Response.Redirect("/SettingManagement/Index");
                return "success";
            }
            else
            {
                Response.Redirect("/SettingManagement/Index");
                return "false";
            }
            
        }
        #endregion

        #region 系统设置查询
        [HttpPost]
        public ActionResult SettingSelect(TBL_SYSSET set)
        {
            TBL_SYSSET[] allInfo = SelectTools.SelectSyssetInfo(u => u.syssetId == u.syssetId, u => u.syssetId);
            TBL_SYSSET[] info = SelectTools.SelectSyssetInfo(u => u.syssetId == set.syssetId, u => u.syssetId);
            ViewBag.allInfo = allInfo;
            ViewBag.info = info;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }
        #endregion
    }
}