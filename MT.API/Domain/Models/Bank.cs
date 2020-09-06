using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class Bank
    {
        public Bank()
        {
            Policies = new HashSet<PoliciesMotor>();
            PolicyRequests = new HashSet<PolicyRequest>();
            ClientPayments = new HashSet<ClientPayment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
        public string Logo { get; set; }
        public ICollection<PoliciesMotor> Policies { get; private set; }
        public ICollection<PolicyRequest> PolicyRequests { get; private set; }
        public ICollection<ClientPayment> ClientPayments { get; set; }
    }
}
