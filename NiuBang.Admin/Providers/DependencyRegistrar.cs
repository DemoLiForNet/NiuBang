using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using NiuBang.Core.Domain;
using NiuBang.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NiuBang.Admin.Providers
{
    public partial class DependencyRegistrar
    {
        public static ContainerBuilder CurrentBuilder { get; set; }
        public static IContainer CurrentContainerget { get; set; }
        public static void RegisterDependency()
        {
            CurrentBuilder = new ContainerBuilder();
            SetupResolveRules(CurrentBuilder);
            CurrentBuilder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            var container = CurrentContainerget = CurrentBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        private static void SetupResolveRules(ContainerBuilder builder)
        {
            builder.Register<IdentityDbContext<AppUser>>(c => HttpContext.Current.GetOwinContext().Get<Core.NiuBangDbConetxt>()).InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Get<AppUserManager>()).InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Get<AppRoleManager>()).InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Get<AppSignInManager>()).InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //All Services
            builder.RegisterAssemblyTypes(Assemblies.Value).Where(p => p.Name.EndsWith("Service") && p.IsClass).AsImplementedInterfaces().InstancePerRequest();


        }
        #region 缓存Services
        private static Lazy<Assembly> Assemblies = new Lazy<Assembly>(LoadAssemblies);
        private static Assembly LoadAssemblies()
        {
            return Assembly.Load("NiuBang.Service");
        }
        #endregion
    }
}