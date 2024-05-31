using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public abstract class EntityBase
    {
        public string CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = String.Empty;
        public DateTime? UpdatedDate { get; set; }
    }
}
