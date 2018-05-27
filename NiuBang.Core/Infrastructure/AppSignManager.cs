using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Infrastructure
{
    public class AppSignInManager : SignInManager<Domain.AppUser, string>
    {
        public AppSignInManager(UserManager<Domain.AppUser, string> userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        {

        }
    }
}
