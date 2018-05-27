using Microsoft.AspNet.Identity;

namespace NiuBang.Core.Infrastructure
{
    public class AppRoleManager:RoleManager<Domain.AppRole>
    {
        public AppRoleManager(IRoleStore<Domain.AppRole,string> store):base (store)
        {

        }
    }
}
