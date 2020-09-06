using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Identity Type Master Table.
    /// </summary>
    public class IdentityType
    {
        public IdentityType()
        {
            Clients = new HashSet<Client>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
        }
        /// <summary>
        /// Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name in english.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic.
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
    }
}
