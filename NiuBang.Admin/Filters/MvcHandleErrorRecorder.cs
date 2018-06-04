using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Filters
{
    /// <summary>
    /// 记录访问MVC错误日志
    /// </summary>
    public class MvcHandleErrorRecorder: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}