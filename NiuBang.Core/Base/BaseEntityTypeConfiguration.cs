using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Base
{
    public class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public BaseEntityTypeConfiguration(bool shouldPostInitialize = true)
        {
            if (shouldPostInitialize)
                PostInitialize();
        }
        protected virtual void PostInitialize()
        {
            Property(b => b.CreatedByUserId).IsRequired();
            Property(b => b.CreatedOn).IsRequired();
        }
    }
}
