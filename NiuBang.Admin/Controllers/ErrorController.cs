using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Controllers
{
    /// <summary>
    /// 错误页面
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// 400.404错误页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }
        /// <summary>
        /// 401.403错误页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Forbidden()
        {
            return View();
        }

        /// <summary>
        /// 500 服务器错误
        /// </summary>
        /// <returns></returns>
        public ActionResult InternalError()
        {
            return View();
        }
    }
}