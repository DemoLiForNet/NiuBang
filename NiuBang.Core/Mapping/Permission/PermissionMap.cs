using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Mapping.Permission
{
    public class PermissionMap:Base.BaseEntityTypeConfiguration<Domain.Premisson.Permission>
    {
        public PermissionMap()
        {
            ToTable("Permission");
            Property(e => e.RoleName).IsRequired().HasMaxLength(20);
            Property(e => e.FeatureName).IsRequired().HasMaxLength(30);
        }
    }
}
