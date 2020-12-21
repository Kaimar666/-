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
    public class DataScreenController : Controller
    {
        // GET: DataScreen
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            TBL_ENERGY[] energyInfo = SelectTools.SelectEnergyInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_SITE[] siteInfo = SelectTools.SelectSiteInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_AMMETER[] ammeterInfo = SelectTools.SelectAmmeterInfo(u => u.siteId == u.siteId, u => u.siteId);
            TBL_SIGCONTROL[] sigcontrolInfo = SelectTools.SelectSigcontrolInfo(u => u.ammeterId == u.ammeterId, u => u.ammeterId);
            TBL_CTRCONTROL[] ctrcontrolInfo = SelectTools.SelectCtrcontrolInfo(u => u.siteId == u.siteId, u => u.siteId);

            //单灯额定能耗数据
            ViewBag.power = ammeterInfo[0].ammeterRefpower;

            //总额定功率数据
            double totalpower = 0;
            foreach(var item in ammeterInfo)
            {
                totalpower += Convert.ToDouble(item.ammeterRefpower);
            }
            totalpower *= 1000;
            ViewBag.totalpower = totalpower;

            //本期能耗

            double curenergy = 0;
            foreach (var item in energyInfo)
            {
                curenergy += Convert.ToDouble(item.energyCurpower);
            }
            ViewBag.curenergy = curenergy;

            //上期能耗

            double preenergy = 0;
            foreach (var item in energyInfo)
            {
                preenergy += Convert.ToDouble(item.energyPrepower);
            }
            ViewBag.preenergy = preenergy;

            //单灯总数
            ViewBag.ammetercount = ammeterInfo.Count() * 10;

            //站点总数
            ViewBag.sitecount = siteInfo.Count() * 10;

            //单灯在线数

            int ammeterOnline = 0;
            foreach (var item in ammeterInfo)
            {
                if(item.ammeterStatus == 0)
                {
                    ammeterOnline += 1;
                }
                
            }
            ViewBag.ammeterOnline = ammeterOnline;

            //单灯警告数

            int ammeterAlarm = 0;
            foreach (var item in ammeterInfo)
            {
                if(item.ammeterStatus == 2 || item.ammeterStatus == 3)
                {
                    ammeterAlarm += 1;
                }
                
            }
            ViewBag.ammeterAlarm = ammeterAlarm;

            //单灯开灯数

            int ammeterOn = 0;
            foreach (var item in ammeterInfo)
            {
                if (item.ammeterSwistatus == 1)
                {
                    ammeterOn += 1;
                }
                
            }
            ViewBag.ammeterOn = ammeterOn;

            //站点在线数

            int siteOnline = 0;
            foreach (var item in siteInfo)
            {
                if(item.siteStatus == 0)
                {
                    siteOnline += 1;
                }
                
            }
            ViewBag.siteOnline = siteOnline;

            //站点警告数

            int siteAlarm = 0;
            foreach (var item in siteInfo)
            {
                if(item.siteStatus == 2 || item.siteStatus == 3)
                {
                    siteAlarm += 1;
                }
                
            }
            ViewBag.siteAlarm = siteAlarm;

            //站点工作数

            int siteOn = 0;
            foreach (var item in siteInfo)
            {
                if(item.siteSwistatus == 1)
                {
                    siteOn += 1;
                }
                
            }
            ViewBag.siteOn = siteOn;

            //开灯时间

            ViewBag.opentime = ctrcontrolInfo[0].ctrcontrolTimopetime;

            //关灯时间

            ViewBag.closetime = ctrcontrolInfo[0].ctrcontrolTimclotime;

            //巡检开始时间

            ViewBag.xjstatime = sigcontrolInfo[0].sigcontrolInsstatime;

            //巡检结束时间

            ViewBag.xjendtime = sigcontrolInfo[0].sigcontrolInsendtime;

            //告警类型名称
            TBL_RUNNOTE[] runnote = SelectTools.SelectRunnoteInfo(u => u.runnoteAlastatus == 2 || u.runnoteAlastatus == 3, u => u.infoId);
            ViewBag.alarmCount = runnote.Count();

            //告警信息提示
            ArrayList ammeter = new ArrayList();
            ArrayList site = new ArrayList();
            foreach (var item in runnote)
            {
                if(item.ammeterId != 0)
                {
                    foreach(var name in ammeterInfo)
                    {
                        if(item.ammeterId == name.ammeterId)
                        {
                            ammeter.Add(name.ammeterName);
                        }
                    }
                }
                else
                {
                    foreach (var name in siteInfo)
                    {
                        if (item.siteId == name.siteId)
                        {
                            site.Add(name.siteName);
                        }
                    }
                }
            }
            ViewBag.noticecount = ammeter.Count + site.Count;
            ViewBag.ammeter = ammeter;
            ViewBag.site = site;

            return View();
        }
    }
}