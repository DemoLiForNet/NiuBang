using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Mapping
{
    public class AppRoleMap : Base.BaseEntityTypeConfiguration<Domain.AppRole>
    {
        public AppRoleMap()
        {
            Property(e => e.DisplayName).HasMaxLength(50).IsRequired();
        }
    }
}
