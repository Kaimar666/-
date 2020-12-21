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
using System.IO;

namespace LampNet.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            TBL_DOCUMENT[] documentInfo = SelectTools.SelectDocumentInfo(u => u.documentKind == 1, u => u.documentId);
            if (documentInfo == null || documentInfo.Count() == 0)
            {
                Response.Write("<script>alert('无查询信息！');</script>");
            }
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            ViewBag.documentInfo = documentInfo;
            return View();
        }

        #region Document添加
        public ActionResult DocumentAdd()
        {
            return View();
        }
        #endregion

        #region Document删除
        [HttpPost]
        public void DocumentDelete(TBL_DOCUMENT document)
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
                    Response.Redirect("/Document/Index");
                }
                else
                {

                    Response.Write("<script>alert('不存在删除内容！');</script>");
                    Response.Redirect("/Document/Index");
                }
            }
            catch
            {

            }
        }
        #endregion

        #region Document查询
        public ActionResult DocumentSelect()
        {
            return View();
        }
        #endregion

        #region Document上传
        public ActionResult DocumentUpload()
        {
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
            if (Request.Cookies["userId"] != null)
            {
                string user = Request.Cookies["userId"].Value;//输出全部的值
                ViewBag.user = user;
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 下载

        [HttpPost]
        public FileResult DocumentDownload(TBL_DOCUMENT document)
        {
            TBL_DOCUMENT[] list = SelectTools.SelectDocumentInfo(u => u.documentId == document.documentId, u => u.documentId);
            string path = list[0].documentUrl;
            string filePath = Server.MapPath(path);//路径
            return File(filePath, "text/plain", "document.excel"); //welcome.txt是客户端保存的名字
        }


        #endregion
    }
}