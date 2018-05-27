using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.DbMigration
{
    public class MigrationDbContext : NiuBang.Core.NiuBangDbConetxt
    {
        public MigrationDbContext()
        {

        }
        public MigrationDbContext(string nameOrConnectionString = "DefaultConnection") : base(nameOrConnectionString)
        {
        }
    }
}
