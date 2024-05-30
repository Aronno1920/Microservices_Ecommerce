using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Order : EntityBase
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public Decimal TotalPrice { get; set; }
        public decimal Price { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
