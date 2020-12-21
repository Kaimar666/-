using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LampNet.Controllers
{
    public class MainIndexController : Controller
    {
        // GET: MainIndex
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie.Name != null)
            {
                ViewBag.user = cookie.Value;
            }
            return View();
        }
    }
}