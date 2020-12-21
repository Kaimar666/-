using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using LampNet.Models;

namespace LampNet.Areas.ToolsHelper
{
    public class SelectTools : Controller
    {
        /// <summary>
        /// 查找后台用户信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.userId == info.userId, u => u.userId</param>
        /// <returns>用户信息数组</returns>
        public static TBL_USER[] SelectUserInfo<TKey>(Expression<Func<TBL_USER, bool>> whereLambda, Expression<Func<TBL_USER, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USER> dataObject = db.TBL_USER.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_USER>;
                    TBL_USER[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_USER[] nullInfo = new TBL_USER[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找站点信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <returns>站点信息数组</returns>
        public static TBL_SITE[] SelectSiteInfo<TKey>(Expression<Func<TBL_SITE, bool>> whereLambda, Expression<Func<TBL_SITE, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SITE> dataObject = db.TBL_SITE.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_SITE>;
                    TBL_SITE[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_SITE[] nullInfo = new TBL_SITE[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找电表信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.ammeterId == info.ammeterId, u => u.ammeterId</param>
        /// <returns>电表信息数组</returns>
        public static TBL_AMMETER[] SelectAmmeterInfo<TKey>(Expression<Func<TBL_AMMETER, bool>> whereLambda, Expression<Func<TBL_AMMETER, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_AMMETER> dataObject = db.TBL_AMMETER.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_AMMETER>;
                    TBL_AMMETER[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_AMMETER[] nullInfo = new TBL_AMMETER[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找系统设置信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.syssetId == info.syssetId, u => u.syssetId</param>
        /// <returns>系统设置信息数组</returns>
        public static TBL_SYSSET[] SelectSyssetInfo<TKey>(Expression<Func<TBL_SYSSET, bool>> whereLambda, Expression<Func<TBL_SYSSET, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SYSSET> dataObject = db.TBL_SYSSET.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_SYSSET>;
                    TBL_SYSSET[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_SYSSET[] nullInfo = new TBL_SYSSET[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找集控信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <returns>集控信息数组</returns>
        public static TBL_CTRCONTROL[] SelectCtrcontrolInfo<TKey>(Expression<Func<TBL_CTRCONTROL, bool>> whereLambda, Expression<Func<TBL_CTRCONTROL, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_CTRCONTROL> dataObject = db.TBL_CTRCONTROL.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_CTRCONTROL>;
                    TBL_CTRCONTROL[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_CTRCONTROL[] nullInfo = new TBL_CTRCONTROL[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找单控信息表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.ammeterId == info.ammeterId, u => u.ammeterId</param>
        /// <returns>单控信息数组</returns>
        public static TBL_SIGCONTROL[] SelectSigcontrolInfo<TKey>(Expression<Func<TBL_SIGCONTROL, bool>> whereLambda, Expression<Func<TBL_SIGCONTROL, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SIGCONTROL> dataObject = db.TBL_SIGCONTROL.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_SIGCONTROL>;
                    TBL_SIGCONTROL[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_SIGCONTROL[] nullInfo = new TBL_SIGCONTROL[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找能耗数据表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <returns>能耗数据数组</returns>
        public static TBL_ENERGY[] SelectEnergyInfo<TKey>(Expression<Func<TBL_ENERGY, bool>> whereLambda, Expression<Func<TBL_ENERGY, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_ENERGY> dataObject = db.TBL_ENERGY.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_ENERGY>;
                    TBL_ENERGY[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_ENERGY[] nullInfo = new TBL_ENERGY[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找运行数据表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <returns>运行数据数组</returns>
        public static TBL_RUN[] SelectRunInfo<TKey>(Expression<Func<TBL_RUN, bool>> whereLambda, Expression<Func<TBL_RUN, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUN> dataObject = db.TBL_RUN.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_RUN>;
                    TBL_RUN[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_RUN[] nullInfo = new TBL_RUN[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找运行状态历史表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <param name="whereLambda">u => u.ammeterId == info.ammeterId, u => u.ammeterId</param>
        /// <returns>运行状态数据数组</returns>
        public static TBL_RUNNOTE[] SelectRunnoteInfo<TKey>(Expression<Func<TBL_RUNNOTE, bool>> whereLambda, Expression<Func<TBL_RUNNOTE, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUNNOTE> dataObject = db.TBL_RUNNOTE.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_RUNNOTE>;
                    TBL_RUNNOTE[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_RUNNOTE[] nullInfo = new TBL_RUNNOTE[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找用户运维操作表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.userId == info.userId, u => u.userId</param>
        /// <returns>用户操作数据数组</returns>
        public static TBL_USERPROTECT[] SelectUserprotectInfo<TKey>(Expression<Func<TBL_USERPROTECT, bool>> whereLambda, Expression<Func<TBL_USERPROTECT, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USERPROTECT> dataObject = db.TBL_USERPROTECT.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_USERPROTECT>;
                    TBL_USERPROTECT[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_USERPROTECT[] nullInfo = new TBL_USERPROTECT[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找设备运维数据表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.userId == info.userId, u => u.userId</param>
        /// <param name="whereLambda">u => u.siteId == info.siteId, u => u.siteId</param>
        /// <param name="whereLambda">u => u.ammeterId == info.ammeterId, u => u.ammeterId</param>
        /// <returns>设备运维数据数组</returns>
        public static TBL_DEVICEPROTECT[] SelectDeviceprotectInfo<TKey>(Expression<Func<TBL_DEVICEPROTECT, bool>> whereLambda, Expression<Func<TBL_DEVICEPROTECT, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DEVICEPROTECT> dataObject = db.TBL_DEVICEPROTECT.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_DEVICEPROTECT>;
                    TBL_DEVICEPROTECT[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_DEVICEPROTECT[] nullInfo = new TBL_DEVICEPROTECT[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找文档数据表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.documentId == info.documentId, u => u.documentId</param>
        /// <returns>文档数据数据数组</returns>
        public static TBL_DOCUMENT[] SelectDocumentInfo<TKey>(Expression<Func<TBL_DOCUMENT, bool>> whereLambda, Expression<Func<TBL_DOCUMENT, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DOCUMENT> dataObject = db.TBL_DOCUMENT.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_DOCUMENT>;
                    TBL_DOCUMENT[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_DOCUMENT[] nullInfo = new TBL_DOCUMENT[0];
                return nullInfo;
            }
        }

        /// <summary>
        /// 查找问题反馈表中符合条件的信息
        /// </summary>
        /// <param name="whereLambda">u => u.userId == info.userId, u => u.userId</param>
        /// <returns>问题反馈数组</returns>
        public static TBL_FEEDBACK[] SelectFeedbackInfo<TKey>(Expression<Func<TBL_FEEDBACK, bool>> whereLambda, Expression<Func<TBL_FEEDBACK, TKey>> orderBy)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_FEEDBACK> dataObject = db.TBL_FEEDBACK.Where(whereLambda).OrderBy(orderBy) as DbQuery<TBL_FEEDBACK>;
                    TBL_FEEDBACK[] infoList = dataObject.ToArray();
                    return infoList;
                }
            }
            catch
            {
                TBL_FEEDBACK[] nullInfo = new TBL_FEEDBACK[0];
                return nullInfo;
            }
        }
    }
}