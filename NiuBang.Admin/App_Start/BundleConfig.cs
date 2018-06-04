using System.Web;
using System.Web.Optimization;

namespace NiuBang.Admin
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Init").Include(
                        "~/Theme/js/jquery-1.10.1.min.js",
                        "~/Theme/js/jquery-migrate-1.2.1.min.js",
                        "~/Theme/js/jquery-ui-1.10.1.custom.min.js",
                        "~/Theme/js/bootstrap.min.js",
                        "~/Theme/js/excanvas.min.js",
                        "~/Theme/js/respond.min.js",
                        "~/Theme/js/jquery.slimscroll.min.js",
                        "~/Theme/js/jquery.blockui.min.js",
                        "~/Theme/js/jquery.cookie.min.js",
                        "~/Theme/js/jquery.uniform.min.js",
                        "~/Theme/js/app.js"));

            bundles.Add(new StyleBundle("~/Admin/Init").Include(
                      "~/Theme/css/bootstrap.min.css",
                      "~/Theme/css/bootstrap-responsive.min.css",
                       "~/Theme/css/font-awesome.min.css",
                        "~/Theme/css/style-metro.css",
                         "~/Theme/css/style.css",
                          "~/Theme/css/style-responsive.css",
                          "~/Theme/css/default.css"));
        }
    }
}
