using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiuBang.Core.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedOn { get; set; }

    }
    public class BaseEntity<TKeyType> : IBaseEntity
    {
        public TKeyType Id { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedByUserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedOn { get; set; }
    }

}
