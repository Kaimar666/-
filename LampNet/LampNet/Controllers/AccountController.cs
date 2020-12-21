using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LampNet.Models;

namespace LampNet.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Request.Cookies["userId"] != null)
            {
                //获取Cookies的值
                HttpCookie cookieName = Request.Cookies["userId"];
                var cookieText = Server.HtmlEncode(cookieName.Value);
                return Content(cookieText);
            }
            return Content("未登录");
        }

        #region 登录
        public ActionResult Login()
        {
            Areas.CookiesHelper.CookiesHelper.clearCookie("userId");
            return View();
        }
        [HttpPost]
        public string Login(TBL_USER user)
        {
            try
            {
                //从数据库中查找数据
                TBL_USER[] users_array = Areas.ToolsHelper.SelectTools.SelectUserInfo(u => u.userId == user.userId, u => u.userId);
                //string MD5Pwd = Areas.MD5Helper.MD5Helper.encrypt(user.userPwd.Trim());
                if (users_array == null)
                {
                    Response.Write("<script>alert('用户名错误！');</script>");
                    Response.Redirect(Url.Action("Index", "Login", new { area = "" }));
                }
                //取密码
                string Pwd = users_array[0].userPwd.ToString();
                if (Pwd != null && Pwd == users_array[0].userPwd)
                {
                    HttpCookie cookieName = new HttpCookie("userId");
                    cookieName.Value = users_array[0].userName;
                    cookieName.Expires = DateTime.Now.AddHours(1);

                    System.Web.HttpContext.Current.Response.Cookies.Add(Areas.CookiesHelper.CookiesHelper.creatCookieHours("userId", users_array[0].ToString(), 1));
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookieName);
                    Response.Redirect(Url.Action("Index", "MainIndex", new { area = "" }));
                    return "登录成功";
                }
                else
                {
                    return "密码错误";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion

        #region 注销
        [HttpPost]
        public void Logout()
        {
            System.Web.HttpContext.Current.Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Url.Action("Index", "Login", new { area = "" }));
        }
        #endregion
    }
}