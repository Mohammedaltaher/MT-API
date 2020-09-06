using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Policies = new HashSet<PoliciesMotor>();
            PolicyRequests = new HashSet<PolicyRequest>();
            ClientPayments = new HashSet<ClientPayment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<PoliciesMotor> Policies { get; set; }
        public ICollection<PolicyRequest> PolicyRequests { get; set; }
        public ICollection<ClientPayment> ClientPayments { get; set; }
    }
}
