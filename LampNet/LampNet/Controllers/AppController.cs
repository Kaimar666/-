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
using System.Text.RegularExpressions;

namespace LampNet.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            TBL_DOCUMENT[] appInfo = SelectTools.SelectDocumentInfo(u => u.documentKind == 0, u => u.documentId);
            if(appInfo == null || appInfo.Count() == 0)
            {
                Response.Write("<script>alert('无App二维码！');</script>");
                return View();
            }
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            string app = appInfo[0].documentUrl.ToString();
            ViewBag.app = app;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 上传图片

        /// <summary>
        /// 把图片上传到服务器并保存路径到数据库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveImage(TBL_DOCUMENT info)
        {
            try
            {
                HttpPostedFileBase imageName = Request.Files["image"];// 从前台获取文件
                if (imageName == null)
                {
                    return Content("(error)未获取到文件");
                }
                string file = imageName.FileName;
                string fileFormat = file.Split('.')[file.Split('.').Length - 1]; // 以“.”截取，获取“.”后面的文件后缀
                Regex imageFormat = new Regex(@"^(bmp)|(png)|(gif)|(jpg)|(jpeg)"); // 验证文件后缀的表达式（自己写的，不规范别介意哈）
                if (string.IsNullOrEmpty(file) || !imageFormat.IsMatch(fileFormat)) // 验证后缀，判断文件是否是所要上传的格式
                {
                    return Content("(error)文件格式支持(bmp)|(png)|(gif)|(jpg)|(jpeg)");
                }
                else
                {
                    string timeStamp = DateTime.Now.Ticks.ToString(); // 获取当前时间的string类型
                    string firstFileName = timeStamp.Substring(0, timeStamp.Length - 4); // 通过截取获得文件名
                    string imageStr = "/img/"; // 获取保存图片的项目文件夹
                    string uploadPath = Server.MapPath("~/" + imageStr); // 将项目路径与文件夹合并
                    string pictureFormat = file.Split('.')[file.Split('.').Length - 1];// 设置文件格式
                    string fileName = firstFileName + "." + fileFormat;// 设置完整（文件名+文件格式） 
                    string saveFile = uploadPath + fileName;//文件路径
                    imageName.SaveAs(saveFile);// 保存文件
                    string image = imageStr + fileName;// 设置数据库保存的路径

                    ViewBag.pictureAdr = image;
                    ViewBag.appInfo = info;
                    if (info.documentId != 0)
                    {
                        return View("Index");
                    }
                    else
                    {
                        return View("Index"); ;
                    }
                }
            }
            catch
            {
                return Content("上传出错！");
            }
        }
        #endregion
    }
}