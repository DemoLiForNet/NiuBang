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
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult NavLeft()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        

    }
}