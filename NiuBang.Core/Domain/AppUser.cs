﻿using Microsoft.AspNet.Identity.EntityFramework;
using NiuBang.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Domain
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
    }
}
