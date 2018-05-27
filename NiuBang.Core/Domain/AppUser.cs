using Microsoft.AspNet.Identity.EntityFramework;
using NiuBang.Core.Base;
using System;

namespace NiuBang.Core.Domain
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
    }
}
