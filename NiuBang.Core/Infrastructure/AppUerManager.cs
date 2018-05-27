using Microsoft.AspNet.Identity;

namespace NiuBang.Core.Infrastructure
{
    public class AppUerManager : UserManager<Domain.AppUser>
    {
        public AppUerManager(IUserStore<Domain.AppUser> store) : base(store)
        {

        }

    }
}
