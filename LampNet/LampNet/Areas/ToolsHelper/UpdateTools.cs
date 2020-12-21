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
    public class UpdateTools : Controller
    {
        /// <summary>
        /// 修改TBL_USER表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.userId == info.userId, info) == true </param>
        /// 判断有无userId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice>权限信息的修改需要判断用户身份</notice>
        /// <notice>修改密码用专门的方法来修改，这里只管资料</notice>
        public static Boolean UpdateUserInfo(Expression<Func<TBL_USER, bool>> whereLambda, TBL_USER info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USER> dataObject = db.TBL_USER.Where(whereLambda) as DbQuery<TBL_USER>;
                    TBL_USER oldInfo = dataObject.FirstOrDefault();
                    oldInfo.userName = info.userName;
                    oldInfo.userSex = info.userSex;
                    oldInfo.userPhone = info.userPhone;
                    oldInfo.userWechat = info.userWechat;
                    oldInfo.userStatus = info.userStatus;
                    oldInfo.userLlogtime = info.userLlogtime;
                    oldInfo.userExptime = info.userExptime;
                    oldInfo.userAut = info.userAut;
                    oldInfo.userNote = info.userNote;
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
        /// 修改TBL_SITE表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// 判断有无siteId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateSiteInfo(Expression<Func<TBL_SITE, bool>> whereLambda, TBL_SITE info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SITE> dataObject = db.TBL_SITE.Where(whereLambda) as DbQuery<TBL_SITE>;
                    TBL_SITE oldInfo = dataObject.FirstOrDefault();
                    oldInfo.siteName = info.siteName;
                    oldInfo.siteGroup = info.siteGroup;
                    oldInfo.siteModel = info.siteModel;
                    oldInfo.siteStatus = info.siteStatus;
                    oldInfo.siteSwistatus = info.siteSwistatus;
                    oldInfo.siteIp = info.siteIp;
                    oldInfo.siteContime = info.siteContime;
                    oldInfo.siteInssite = info.siteInssite;
                    oldInfo.sitePurtime = info.sitePurtime;
                    oldInfo.siteLife = info.siteLife;
                    oldInfo.siteAcctime = info.siteAcctime;
                    oldInfo.siteNote = info.siteNote;
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
        /// 修改TBL_AMMETER表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.ammeterId == info.ammeterId, info) == true </param>
        /// 判断有无ammeterId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateAmmeterInfo(Expression<Func<TBL_AMMETER, bool>> whereLambda, TBL_AMMETER info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_AMMETER> dataObject = db.TBL_AMMETER.Where(whereLambda) as DbQuery<TBL_AMMETER>;
                    TBL_AMMETER oldInfo = dataObject.FirstOrDefault();
                    oldInfo.siteId = info.siteId;
                    oldInfo.ammeterName = info.ammeterName;
                    oldInfo.ammeterGroup = info.ammeterGroup;
                    oldInfo.ammeterModel = info.ammeterModel;
                    oldInfo.ammeterRefpower = info.ammeterRefpower;
                    oldInfo.ammeterOldload = info.ammeterOldload;
                    oldInfo.ammeterNewload = info.ammeterNewload;
                    oldInfo.ammeterRate = info.ammeterRate;
                    oldInfo.ammeterAlarm = info.ammeterAlarm;
                    oldInfo.ammeterStatus = info.ammeterStatus;
                    oldInfo.ammeterSwistatus = info.ammeterSwistatus;
                    oldInfo.ammeterLife = info.ammeterLife;
                    oldInfo.ammeterAcctime = info.ammeterAcctime;
                    oldInfo.ammeterNote = info.ammeterNote;
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
        /// 修改TBL_SYSSET表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.syssetId == info.syssetId, info) == true </param>
        /// 判断有无syssetId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateSyssetInfo(Expression<Func<TBL_SYSSET, bool>> whereLambda, TBL_SYSSET info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SYSSET> dataObject = db.TBL_SYSSET.Where(whereLambda) as DbQuery<TBL_SYSSET>;
                    TBL_SYSSET oldInfo = dataObject.FirstOrDefault();
                    oldInfo.syssetName = info.syssetName;
                    oldInfo.syssetOpevalue = info.syssetOpevalue;
                    oldInfo.syssetClovalue = info.syssetClovalue;
                    oldInfo.syssetAlatime = info.syssetAlatime;
                    oldInfo.syssetAlacurrent = info.syssetAlacurrent;
                    oldInfo.syssetNote = info.syssetNote;
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
        /// 修改TBL_CTRCONTROL表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// 判断有无siteId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateCtrcontrolInfo(Expression<Func<TBL_CTRCONTROL, bool>> whereLambda, TBL_CTRCONTROL info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_CTRCONTROL> dataObject = db.TBL_CTRCONTROL.Where(whereLambda) as DbQuery<TBL_CTRCONTROL>;
                    TBL_CTRCONTROL oldInfo = dataObject.FirstOrDefault();
                    oldInfo.ctrcontrolTimweek = info.ctrcontrolTimweek;
                    oldInfo.ctrcontrolLigweek = info.ctrcontrolLigweek;
                    oldInfo.ctrcontrolTimopetime = info.ctrcontrolTimopetime;
                    oldInfo.ctrcontrolTimclotime = info.ctrcontrolTimclotime;
                    oldInfo.ctrcontrolOpeligvalue = info.ctrcontrolOpeligvalue;
                    oldInfo.ctrcontrolCloligvalue = info.ctrcontrolCloligvalue;
                    oldInfo.ctrcontrolLigvalsource = info.ctrcontrolLigvalsource;
                    oldInfo.ctrcontrolSystime = info.ctrcontrolSystime;
                    oldInfo.ctrcontrolSysweek = info.ctrcontrolSysweek;
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
        /// 修改TBL_SIGCONTROL表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.ammeterId == info.ammeterId, info) == true </param>
        /// 判断有无ammeterId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateSigcontrolInfo(Expression<Func<TBL_SIGCONTROL, bool>> whereLambda, TBL_SIGCONTROL info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SIGCONTROL> dataObject = db.TBL_SIGCONTROL.Where(whereLambda) as DbQuery<TBL_SIGCONTROL>;
                    TBL_SIGCONTROL oldInfo = dataObject.FirstOrDefault();
                    oldInfo.ammeterSwistatus = info.ammeterSwistatus;
                    oldInfo.sigcontrolIndtime = info.sigcontrolIndtime;
                    oldInfo.sigcontrolInsstatime = info.sigcontrolInsstatime;
                    oldInfo.sigcontrolInsendtime = info.sigcontrolInsendtime;
                    oldInfo.sigcontrolAlacurup = info.sigcontrolAlacurup;
                    oldInfo.sigcontrolAlacurlow = info.sigcontrolAlacurlow;
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
        /// 修改TBL_ENERGY表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// 判断有无siteId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateEnergyInfo(Expression<Func<TBL_ENERGY, bool>> whereLambda, TBL_ENERGY info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_ENERGY> dataObject = db.TBL_ENERGY.Where(whereLambda) as DbQuery<TBL_ENERGY>;
                    TBL_ENERGY oldInfo = dataObject.FirstOrDefault();
                    oldInfo.energyDate = info.energyDate;
                    oldInfo.energyWorktime = info.energyWorktime;
                    oldInfo.energyStavalue = info.energyStavalue;
                    oldInfo.energyEndvalue = info.energyEndvalue;
                    oldInfo.energyPrepower = info.energyPrepower;
                    oldInfo.energyCurpower = info.energyCurpower;
                    oldInfo.energyPrerate = info.energyPrerate;
                    oldInfo.energyCurrate = info.energyCurrate;
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
        /// 修改TBL_RUN表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// 判断有无siteId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateRunInfo(Expression<Func<TBL_RUN, bool>> whereLambda, TBL_RUN info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUN> dataObject = db.TBL_RUN.Where(whereLambda) as DbQuery<TBL_RUN>;
                    TBL_RUN oldInfo = dataObject.FirstOrDefault();
                    oldInfo.runVolt = info.runVolt;
                    oldInfo.runCurrent = info.runCurrent;
                    oldInfo.runStavalue = info.runStavalue;
                    oldInfo.runFreshtime = info.runFreshtime;
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
        /// 修改TBL_RUNNOTE表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// <param name="whereLambda"> (u=>u.ammeterId == info.ammeterId, info) == true </param>
        /// 判断有无siteId 或者 有无ammeter
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateRunnoteInfo(Expression<Func<TBL_RUNNOTE, bool>> whereLambda, TBL_RUNNOTE info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUNNOTE> dataObject = db.TBL_RUNNOTE.Where(whereLambda) as DbQuery<TBL_RUNNOTE>;
                    TBL_RUNNOTE oldInfo = dataObject.FirstOrDefault();
                    oldInfo.runnoteAlastatus = info.runnoteAlastatus;
                    oldInfo.runnoteAlatime = info.runnoteAlatime;
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
        /// 修改TBL_USERPROTECT表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.userId == info.userId, info) == true </param>
        /// 判断有无userId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateUserprotectInfo(Expression<Func<TBL_USERPROTECT, bool>> whereLambda, TBL_USERPROTECT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USERPROTECT> dataObject = db.TBL_USERPROTECT.Where(whereLambda) as DbQuery<TBL_USERPROTECT>;
                    TBL_USERPROTECT oldInfo = dataObject.FirstOrDefault();
                    oldInfo.userprotectKind = info.userprotectKind;
                    oldInfo.userprotectModule = info.userprotectModule;
                    oldInfo.userprotectLoginfo = info.userprotectLoginfo;
                    oldInfo.userprotectOpttime = info.userprotectOpttime;
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
        /// 修改TBL_DEVICEPROTECT表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// <param name="whereLambda"> (u=>u.siteId == info.siteId, info) == true </param>
        /// 判断有无 三个参数都要与原数据中的一样才能修改，否则只能作为新数据插入
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateDeviceprotectInfo(Expression<Func<TBL_DEVICEPROTECT, bool>> whereLambda, TBL_DEVICEPROTECT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DEVICEPROTECT> dataObject = db.TBL_DEVICEPROTECT.Where(whereLambda) as DbQuery<TBL_DEVICEPROTECT>;
                    TBL_DEVICEPROTECT oldInfo = dataObject.FirstOrDefault();
                    oldInfo.deviceprotectKind = info.deviceprotectKind;
                    oldInfo.deviceprotectModule = info.deviceprotectModule;
                    oldInfo.deviceprotectLoginfo = info.deviceprotectLoginfo;
                    oldInfo.deviceprotectOpttime = info.deviceprotectOpttime;
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
        /// 修改TBL_DOCUMENT表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.documentId == info.documentId, info) == true </param>
        /// 判断有无documentId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateDocumentInfo(Expression<Func<TBL_DOCUMENT, bool>> whereLambda, TBL_DOCUMENT info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DOCUMENT> dataObject = db.TBL_DOCUMENT.Where(whereLambda) as DbQuery<TBL_DOCUMENT>;
                    TBL_DOCUMENT oldInfo = dataObject.FirstOrDefault();
                    oldInfo.documentKind = info.documentKind;
                    oldInfo.documentNote = info.documentNote;
                    oldInfo.documentUrl = info.documentUrl;
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
        /// 修改TBL_FEEDBACK表的数据
        /// </summary>
        /// <param name="whereLambda"> (u=>u.userId == info.userId, info) == true </param>
        /// 判断有无userId
        /// <param name="info"> info是需要修改的信息 </param>
        /// <notice></notice>
        public static Boolean UpdateFeedbackInfo(Expression<Func<TBL_FEEDBACK, bool>> whereLambda, TBL_FEEDBACK info)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_FEEDBACK> dataObject = db.TBL_FEEDBACK.Where(whereLambda) as DbQuery<TBL_FEEDBACK>;
                    TBL_FEEDBACK oldInfo = dataObject.FirstOrDefault();
                    oldInfo.userId = info.userId;
                    oldInfo.feedbackTime = info.feedbackTime;
                    oldInfo.feedbackNote = info.feedbackNote;
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