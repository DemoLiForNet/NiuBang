using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Base
{
    public interface IBaseEntity
    {
        int CreatedByUserId { get; set; }
        DateTime CreatedOn { get; set; }
        bool IsDelete { get; set; }
    }
}
