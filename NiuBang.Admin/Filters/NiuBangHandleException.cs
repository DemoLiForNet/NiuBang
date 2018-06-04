using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Filters
{
    /// <summary>
    ///异常处理
    /// </summary>
    public class NiuBangHandleException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            if (System.Diagnostics.Debugger.IsAttached)
            {
                filterContext.ExceptionHandled = false;
                return;
            }
            Exception exception = filterContext.Exception;
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            HttpException httpException = new HttpException(null, exception);
            int errorCode = httpException.GetHttpCode();
            //处理异常
            //1、根据对应的HTTP错误码跳转到错误页面
            //2、其他错误默认为HTTP 500服务器错误
            if (errorCode == 400 || errorCode == 404)
            {
                filterContext.HttpContext.Response.StatusCode = 404;
                filterContext.HttpContext.Response.Redirect("~/Error/NotFound");
            }
            if (errorCode == 401 || errorCode == 403)
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.HttpContext.Response.Redirect("~/Error/Forbidden");
            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.Redirect("~/Error/InternalError");
            }
            //设置异常已经处理,否则会被其他异常过滤器覆盖
            filterContext.ExceptionHandled = true;
            //在派生类中重写时，获取或设置一个值，该值指定是否禁用IIS自定义错误。
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            base.OnException(filterContext);
        }
    }
}