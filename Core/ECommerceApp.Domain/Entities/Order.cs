using ECommerceApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; } // kk value object is on the way

        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
