using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NiuBang.Admin.Providers;
using NiuBang.Core.Domain;
using NiuBang.Core.Infrastructure;
using Owin;

[assembly: OwinStartup(typeof(NiuBang.Admin.Startup))]

namespace NiuBang.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
            //Autofac 依赖注入
            DependencyRegistrar.RegisterDependency();
        }

        protected static void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(IdentityFactory.CreatedDbContext);
            app.CreatePerOwinContext<AppUserManager>(IdentityFactory.CreateUserManager);
            app.CreatePerOwinContext<AppRoleManager>(IdentityFactory.CreateRoleManager);
            app.CreatePerOwinContext<AppSignInManager>(IdentityFactory.CreateSignInManager);

            //// 使应用程序可以使用 Cookie 来存储已登录用户的信息
            //// 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            //// 配置登录 Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieDomain = "NiuBang",

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // 当用户登录时使应用程序可以验证安全戳。
                    // 这是一项安全功能，当你更改密码或者向帐户添加外部登录名时，将使用此功能。
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<AppUserManager, AppUser>(
                        validateInterval: TimeSpan.FromMinutes(10),
                        regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // 使应用程序可以在双重身份验证过程中验证第二因素时暂时存储用户信息。
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // 使应用程序可以记住第二登录验证因素，例如电话或电子邮件。
            // 选中此选项后，登录过程中执行的第二个验证步骤将保存到你登录时所在的设备上。
            // 此选项类似于在登录时提供的“记住我”选项。
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // 取消注释以下行可允许使用第三方登录提供程序登录
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});       
        }
    }
}
