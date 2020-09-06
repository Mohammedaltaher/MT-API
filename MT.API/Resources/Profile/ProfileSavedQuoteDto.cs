using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ProfileSavedQuoteResponse: BaseResponse
    {
        public IEnumerable<ProfileSavedQuoteDto> Data { get; set; }
        public ProfileSavedQuoteResponse()
        {
            Data = new List<ProfileSavedQuoteDto>();
        }
    }
    public class ProfileSavedQuoteDto
    {
        public Guid Id { get; set; }
        public string InsurCompany { get; set; }
        public string InsurCompanyAr { get; set; }
        public string QuoteReferenceId { get; set; }
        public long VehicleId { get; set; }
        public int VehiclePlateNumber { get; set; }
        public string VehiclePlateFirstLetter { get; set; }
        public string VehiclePlateSecondLetter { get; set; }
        public string VehiclePlateThirdLetter { get; set; }
        public string VehiclePlateFirstLetterAr { get; set; }
        public string VehiclePlateSecondLetterAr { get; set; }
        public string VehiclePlateThirdLetterAr { get; set; }
        public string VehicleModelYear { get; set; }
        public string VehicleModelAr { get; set; }
        public string VehicleMakerAr { get; set; }
        public string VehicleLogo { get; set; }
        public string VehicleMajorColor { get; set; }
        public string VehicleMajorColorAr { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public string Status { 
            get 
            {
                string status = "Active";
                if(this.QuotationEndDate < DateTime.Now)
                {
                    status = "Expired";
                }
                return status;
            }
        }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
