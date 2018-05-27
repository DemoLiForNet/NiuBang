using Microsoft.AspNet.Identity;

namespace NiuBang.Core.Infrastructure
{
    public class AppUserManager : UserManager<Domain.AppUser>
    {
        public AppUserManager(IUserStore<Domain.AppUser> store) : base(store)
        {

        }

    }
}
