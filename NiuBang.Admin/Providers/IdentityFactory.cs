using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NiuBang.Core;
using NiuBang.Core.Domain;
using NiuBang.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiuBang.Admin.Providers
{
    public static class IdentityFactory
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns></returns>
        public static NiuBangDbConetxt CreatedDbContext()
        {
            return new NiuBangDbConetxt(nameOrConnectionString: "DefaultConnection");
        }

        public static AppUserManager CreateUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<NiuBangDbConetxt>()));
            // 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true
                //RequireUniqueEmail = true,
            };

            // 配置密码的验证逻辑
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // 配置用户锁定默认值
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            // 你可以编写自己的提供程序并将其插入到此处。
            manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<AppUser>
            {
                MessageFormat = "你的安全代码是 {0}"
            });
            manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<AppUser>
            {
                Subject = "安全代码",
                BodyFormat = "你的安全代码是 {0}"
            });
            //manager.EmailService = DependencyResolver.Current.GetService<EmailService>();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
        public static AppRoleManager CreateRoleManager(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            var manager = new AppRoleManager(new RoleStore<AppRole>(context.Get<NiuBangDbConetxt>()));
            return manager;
        }
        public static AppSignInManager CreateSignInManager(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            var manager = new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
            return manager;
        }
    }
}