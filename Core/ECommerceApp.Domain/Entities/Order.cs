using ECommerceApp.Domain.Entities.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; } // kk value object is on the way

        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
