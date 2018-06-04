using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NiuBang.Model;

namespace NiuBang.Admin.Providers
{
    public class FeatureProvider : Service.Feature.IFeatureService
    {
        private const string HomeManager = "HomeManager";
        private static readonly Feature Home = new Feature { Name = HomeManager, Action = "Index", Controller = "Home", Description = "首页", Order = 0 };

        private const string RoleManager = "RoleManager";
        private static readonly Feature Role = new Feature { Name = RoleManager, Action = "Index", Controller = "Role", Description = "角色", Order = 1 };
        public IEnumerable<Feature> GetFeatures()
        {
            return new[]
            {
                Home,
                Role
            };
        }
    }
}