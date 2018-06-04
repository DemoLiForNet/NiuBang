using Microsoft.AspNet.Identity.EntityFramework;
using NiuBang.Core.Base;
using System;

namespace NiuBang.Core.Domain
{
    public class AppRole : IdentityRole, IBaseEntity
    {
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
