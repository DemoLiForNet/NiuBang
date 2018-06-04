using System.Web.Mvc;

namespace NiuBang.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Filters.MvcHandleErrorRecorder());
            filters.Add(new Filters.NiuBangHandleException());
        }
    }
}
