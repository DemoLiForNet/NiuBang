using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NiuBang.Core
{
    public class NiuBangDbConetxt : IdentityDbContext<Domain.AppUser>
    {
        public NiuBangDbConetxt()
        {

        }
        public NiuBangDbConetxt(string nameOrConnectionString) : base(nameOrConnectionString: nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
            foreach (var type in typeList.Value)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
        #region static  缓存Entity
        private Lazy<IEnumerable<Type>> typeList = new Lazy<IEnumerable<Type>>(AssemblyInit);
        private static IEnumerable<Type> AssemblyInit()
        {
            var typesToRegister = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                   .Where(type => !string.IsNullOrEmpty(type.Namespace))
                   .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(Base.BaseEntityTypeConfiguration <>));
            return typesToRegister;
        }
        #endregion
    }
}
