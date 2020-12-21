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
    public class DeleteTools : Controller
    {
        ///<summary>
        ///删除后台用户表的指定数据
        ///</summary>
        ///<param name="whereLambda">u=>userId == userId</param>
        ///<return>true or false</return>
        ///Notice：对应需要删除如下：
        ///用户运维TBL_USERPROTECT、设备运维TBL_DEVICEPROTECT、问题反馈TBL_FEEDBACK
        public static Boolean DeleteUserInfo(Expression<Func<TBL_USER, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USER> dbDelete = db.TBL_USER.Where(whereLambda) as DbQuery<TBL_USER>;
                    List<TBL_USER> obDelete = dbDelete.ToList();
                    if(obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_USER.RemoveRange(obDelete);
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
        /// 删除站点表中的数据
        /// </summary>
        /// <param name="whereLambda">u => siteId == siteId</param>
        /// Notice：删除站点信息需要对应删除的信息有如下：
        /// 集控TBL_CTRCONTROL、能耗TBL_ENERGY、运行数据TBL_RUN、运行状态历史TBL_RUNNOTE、设备运维TBL_DEVICEPROTECT
        public static Boolean DeleteSiteInfo(Expression<Func<TBL_SITE, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SITE> dbDelete = db.TBL_SITE.Where(whereLambda) as DbQuery<TBL_SITE>;
                    List<TBL_SITE> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_SITE.RemoveRange(obDelete);
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
        /// 删除电表信息表中的数据
        /// </summary>
        /// <param name="whereLambda">u => ammeterId == ammeterId</param>
        /// Notice：删除电表信息需要对应删除的信息有如下：
        /// 单控TBL_SIGCONTROL、运行状态历史TBL_RUNNOTE、设备运维TBL_DEVICEPROTECT
        public static Boolean DeleteAmmeterInfo(Expression<Func<TBL_AMMETER, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_AMMETER> dbDelete = db.TBL_AMMETER.Where(whereLambda) as DbQuery<TBL_AMMETER>;
                    List<TBL_AMMETER> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_AMMETER.RemoveRange(obDelete);
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
        /// 删除系统设置信息表中的数据
        /// </summary>
        /// <param name="whereLambda">u => syssetId == syssetId</param>
        public static Boolean DeleteSyssetInfo(Expression<Func<TBL_SYSSET, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SYSSET> dbDelete = db.TBL_SYSSET.Where(whereLambda) as DbQuery<TBL_SYSSET>;
                    List<TBL_SYSSET> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_SYSSET.RemoveRange(obDelete);
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
        /// 删除集控信息表中的数据
        /// </summary>
        /// <param name="whereLambda">u => siteId == siteId</param>
        public static Boolean DeleteCtrcontrolInfo(Expression<Func<TBL_CTRCONTROL, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_CTRCONTROL> dbDelete = db.TBL_CTRCONTROL.Where(whereLambda) as DbQuery<TBL_CTRCONTROL>;
                    List<TBL_CTRCONTROL> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_CTRCONTROL.RemoveRange(obDelete);
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
        /// 删除单控信息表中的数据
        /// </summary>
        /// <param name="whereLambda">u => ammeterId == ammeterId</param>
        public static Boolean DeleteSigcontrolInfo(Expression<Func<TBL_SIGCONTROL, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_SIGCONTROL> dbDelete = db.TBL_SIGCONTROL.Where(whereLambda) as DbQuery<TBL_SIGCONTROL>;
                    List<TBL_SIGCONTROL> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_SIGCONTROL.RemoveRange(obDelete);
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
        /// 删除能耗数据表中的数据
        /// </summary>
        /// <param name="whereLambda">u => siteId == siteId</param>
        public static Boolean DeleteEnergyInfo(Expression<Func<TBL_ENERGY, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_ENERGY> dbDelete = db.TBL_ENERGY.Where(whereLambda) as DbQuery<TBL_ENERGY>;
                    List<TBL_ENERGY> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_ENERGY.RemoveRange(obDelete);
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
        /// 删除运行数据表中的数据
        /// </summary>
        /// <param name="whereLambda">u => siteId == siteId</param>
        public static Boolean DeleteRunInfo(Expression<Func<TBL_RUN, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUN> dbDelete = db.TBL_RUN.Where(whereLambda) as DbQuery<TBL_RUN>;
                    List<TBL_RUN> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_RUN.RemoveRange(obDelete);
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
        /// 删除运行状态历史表中的数据
        /// </summary>
        /// <param name="whereLambda">u => siteId == siteId</param>
        /// <param name="whereLambda">u => ammeterId == ammeterId</param>
        public static Boolean DeleteRunnoteInfo(Expression<Func<TBL_RUNNOTE, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_RUNNOTE> dbDelete = db.TBL_RUNNOTE.Where(whereLambda) as DbQuery<TBL_RUNNOTE>;
                    List<TBL_RUNNOTE> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_RUNNOTE.RemoveRange(obDelete);
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
        /// 删除用户运维操作表中的数据
        /// </summary>
        /// <param name="whereLambda">u => userId == userId</param>
        public static Boolean DeleteUserprotectInfo(Expression<Func<TBL_USERPROTECT, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_USERPROTECT> dbDelete = db.TBL_USERPROTECT.Where(whereLambda) as DbQuery<TBL_USERPROTECT>;
                    List<TBL_USERPROTECT> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_USERPROTECT.RemoveRange(obDelete);
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
        /// 删除设备运维操作表中的数据
        /// </summary>
        /// <param name="whereLambda">u => userId == userId</param>
        /// <param name="whereLambda">u => siteId == siteId</param>
        /// <param name="whereLambda">u => ammeterId == ammeterId</param>
        public static Boolean DeleteDeviceprotectInfo(Expression<Func<TBL_DEVICEPROTECT, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DEVICEPROTECT> dbDelete = db.TBL_DEVICEPROTECT.Where(whereLambda) as DbQuery<TBL_DEVICEPROTECT>;
                    List<TBL_DEVICEPROTECT> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_DEVICEPROTECT.RemoveRange(obDelete);
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
        /// 删除文档数据表中的数据
        /// </summary>
        /// <param name="whereLambda">u => documentId == documentId</param>
        public static Boolean DeleteDocumentInfo(Expression<Func<TBL_DOCUMENT, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_DOCUMENT> dbDelete = db.TBL_DOCUMENT.Where(whereLambda) as DbQuery<TBL_DOCUMENT>;
                    List<TBL_DOCUMENT> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_DOCUMENT.RemoveRange(obDelete);
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
        /// 删除问题反馈表中的数据
        /// </summary>
        /// <param name="whereLambda">u => userId == userId</param>
        public static Boolean DeleteFeedbackInfo(Expression<Func<TBL_FEEDBACK, bool>> whereLambda)
        {
            try
            {
                using (LampNetEntities db = new LampNetEntities())
                {
                    DbQuery<TBL_FEEDBACK> dbDelete = db.TBL_FEEDBACK.Where(whereLambda) as DbQuery<TBL_FEEDBACK>;
                    List<TBL_FEEDBACK> obDelete = dbDelete.ToList();
                    if (obDelete.Count == 0)
                    {
                        return true;
                    }
                    db.TBL_FEEDBACK.RemoveRange(obDelete);
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
        /// 通过userId删除关于用户的所有信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Boolean DeleteUserUserId(int userId)
        {
            try
            {
                Boolean status1 = DeleteUserInfo(u => u.userId == userId);
                Boolean status2 = DeleteUserprotectInfo(u => u.userId == userId);
                Boolean status3 = DeleteDeviceprotectInfo(u => u.userId == userId);
                Boolean status4 = DeleteFeedbackInfo(u => u.userId == userId);
                if (status1 == status2 == status3 == status4 ==  true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 通过siteId删除关于站点的所有信息
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public static Boolean DeleteSiteSiteId(int siteId)
        {
            try
            {
                Boolean status1 = DeleteSiteInfo(u => u.siteId == siteId);
                Boolean status2 = DeleteCtrcontrolInfo(u => u.siteId == siteId);
                Boolean status3 = DeleteEnergyInfo(u => u.siteId == siteId);
                Boolean status4 = DeleteRunInfo(u => u.siteId == siteId);
                Boolean status5 = DeleteRunnoteInfo(u => u.siteId == siteId);
                Boolean status6 = DeleteDeviceprotectInfo(u => u.siteId == siteId);
                if (status1 == status2 == status3 == status4 == status5 == status6 == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 通过ammeterId删除关于电表的所有信息
        /// </summary>
        /// <param name="ammeterId"></param>
        /// <returns></returns>
        public static Boolean DeleteAmmeterAmmeterId(int ammeterId)
        {
            try
            {
                Boolean status1 = DeleteAmmeterInfo(u => u.ammeterId == ammeterId);
                Boolean status2 = DeleteSigcontrolInfo(u => u.ammeterId == ammeterId);
                Boolean status3 = DeleteRunnoteInfo(u => u.ammeterId == ammeterId);
                Boolean status4 = DeleteDeviceprotectInfo(u => u.ammeterId == ammeterId);
                if (status1 == status2 == status3 == status4  == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}