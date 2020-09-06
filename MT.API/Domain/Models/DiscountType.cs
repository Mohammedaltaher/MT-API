using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class DiscountType
    {
        public DiscountType()
        {
            ProductDiscounts = new HashSet<ProductDiscount>();
            ClientQuotationMotorDiscounts = new HashSet<ClientQuotationMotorDiscount>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public ICollection<ClientQuotationMotorDiscount> ClientQuotationMotorDiscounts { get; set; }
    }
}
