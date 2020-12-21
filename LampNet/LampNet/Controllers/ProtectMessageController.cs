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
using System.Text;

namespace LampNet.Controllers
{
    public class ProtectMessageController : Controller
    {
        // GET: ProtectMessage
        public ActionResult Index()
        {
            TBL_DOCUMENT[] protectInfo = SelectTools.SelectDocumentInfo(u => u.documentKind == 2, u => u.documentId);
            if (protectInfo == null || protectInfo.Count() == 0)
            {
                Response.Write("<script>alert('无查询信息！');</script>");
            }
            ViewBag.protectInfo = protectInfo;

            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        #region 维护信息添加
        public ActionResult ProtectMessageAdd()
        {
            return View();
        }
        #endregion

        #region 维护信息删除
        public void ProtectMessageDelete(TBL_DOCUMENT document)
        {
            try
            {

                HttpCookie cookie = Request.Cookies["userId"];
                if (cookie.Name != null)
                {
                    ViewBag.user = cookie.Value;
                }

                if (DeleteTools.DeleteDocumentInfo(u => u.documentId == document.documentId) == true)
                {

                    Response.Write("<script>alert('删除成功！');</script>");
                    Response.Redirect("/ProtectMessage/Index");
                }
                else
                {

                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/ProtectMessage/Index");
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 维护信息查询
        public ActionResult ProtectMessageSelect()
        {
            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }
        #endregion

        #region 维护信息修改
        public ActionResult ProtectMessageUpdate()
        {
            return View();
        }
        #endregion

        #region 维护信息上传
        public ActionResult ProtectMessageUpload()
        {
            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }

            return View();
        }

        [HttpPost]
        public ActionResult ProcessUploadFiles(IEnumerable<HttpPostedFileBase> fileName)
        {
            foreach (var file in fileName)
            {
                if (file.ContentLength > 0)
                {
                    string target = "~/Content/assets/document/";//取得目标文件夹的路径
                    string filename = file.FileName;//取得文件名字
                    string path = target + filename;//获取存储的目标地址
                    file.SaveAs(Server.MapPath(path));
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 下载

        [HttpPost]
        public FileResult download()
        {
            string filePath = Server.MapPath("~/Document/123.txt");//路径
            return File(filePath, "Document/", "welcome.txt"); //welcome.txt是客户端保存的名字
        }
        public ActionResult Down(string fileName)
        {
            //文件下载
            string fn = Request.Url.ToString();
            string filePath = Server.MapPath("../../Upload") + "\\" + fileName;
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            // Response.AppendHeader("Content-Length", fInfo.Length.ToString());
            Response.WriteFile(filePath);
            return null;
        }

        #endregion
    }
}