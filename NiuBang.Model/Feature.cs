using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Model
{
    /// <summary>
    /// 如果需要展示至菜单请添加controller,action,area默认null
    /// </summary>
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        /// <summary>
        /// 可用于导航栏分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 导航栏排序
        /// </summary>
        public int Order { get; set; }
    }
}
