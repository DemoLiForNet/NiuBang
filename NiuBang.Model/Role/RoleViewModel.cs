using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Model
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [DisplayName("角色代码")]
        public string Name { get; set; }
        [DisplayName("角色名称")]
        public string DisplayName { get; set; }
    }
}
