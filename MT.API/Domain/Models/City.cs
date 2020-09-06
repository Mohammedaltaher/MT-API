using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// City Master Table.
    /// </summary>
    public class City
    {
        public City()
        {
            IdentityIssuePlaceClients = new HashSet<Client>();
            WorkCityClients = new HashSet<Client>();
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationRequestsIdentityIssuePlace = new HashSet<QuotationsMotorRequest>();
            QuotationRequestsVehicleReqCity = new HashSet<QuotationsMotorRequest>();
            QuotationRequestsWorkCity = new HashSet<QuotationsMotorRequest>();
            QuotationRequestsDrivingCity = new HashSet<QuotationsMotorRequest>();
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

        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Client> IdentityIssuePlaceClients { get; set; }
        public ICollection<Client> WorkCityClients { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestsIdentityIssuePlace { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestsVehicleReqCity { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestsWorkCity { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestsDrivingCity { get; set; }


    }
}
