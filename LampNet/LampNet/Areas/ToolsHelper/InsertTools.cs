using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using LampNet.Models;

namespace LampNet.Areas.ToolsHelper
{
    public class InsertTools : Controller
    {
        /// <summary>
        /// 往用户信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertUserInfo(TBL_USER info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_USER.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往站点信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertSiteInfo(TBL_SITE info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_SITE.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往电表信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertAmmeterInfo(TBL_AMMETER info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_AMMETER.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往系统设置信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertSyssetInfo(TBL_SYSSET info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_SYSSET.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往集控信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertCtrcontrolInfo(TBL_CTRCONTROL info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_CTRCONTROL.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往单控信息表中插入数据
        /// </summary>
        /// <param name="info">前端页面输入的信息</param>
        /// <returns></returns>
        public static Boolean InsertSigcontrolInfo(TBL_SIGCONTROL info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_SIGCONTROL.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往能耗数据表中插入数据
        /// </summary>
        /// <param name="info">硬件产生的信息（本系统模拟）</param>
        /// <returns></returns>
        public static Boolean InsertEnergyInfo(TBL_ENERGY info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_ENERGY.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往运行数据表中插入数据
        /// </summary>
        /// <param name="info">系统产生的信息（本系统模拟）</param>
        /// <returns></returns>
        public static Boolean InsertRunInfo(TBL_RUN info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_RUN.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往运行状态历史表中插入数据
        /// </summary>
        /// <param name="info">系统产生的信息（本系统模拟）</param>
        /// <returns></returns>
        public static Boolean InsertRunnoteInfo(TBL_RUNNOTE info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_RUNNOTE.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往用户运维操作表中插入数据
        /// </summary>
        /// <param name="info">用户操作产生的信息</param>
        /// <returns></returns>
        public static Boolean InsertUserprotectInfo(TBL_USERPROTECT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_USERPROTECT.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往设备运维操作表中插入数据
        /// </summary>
        /// <param name="info">用户操作设备产生的信息</param>
        /// <returns></returns>
        public static Boolean InsertDeviceprotectInfo(TBL_DEVICEPROTECT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_DEVICEPROTECT.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往文档数据表中插入数据
        /// </summary>
        /// <param name="info">新上传的文档数据信息</param>
        /// <returns></returns>
        public static Boolean InsertDocumentInfo(TBL_DOCUMENT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_DOCUMENT.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 往问题反馈表中插入数据
        /// </summary>
        /// <param name="info">新上传的反馈信息</param>
        /// <returns></returns>
        public static Boolean InsertFeedbackInfo(TBL_FEEDBACK info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    db.TBL_FEEDBACK.Add(info);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}