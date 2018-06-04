using NiuBang.Core.Infrastructure;
using NiuBang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly AppRoleManager _roleManager;
        public RoleController(AppRoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult RoleList()
        {
            var data = _roleManager.Roles.Select(e => new RoleViewModel
            {
                Id = e.Id,
                Name = e.Name,
                DisplayName = e.DisplayName
            });
            return PartialView(data);
        }

    }
}