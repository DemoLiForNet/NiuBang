using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Service.Feature.IFeatureService _featureService;
        public HomeController(Service.Feature.IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Header()
        {
            var feature = _featureService.GetFeatures();
            return PartialView(feature);
        }
    }
}