using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{

    public class ProfileVehiclesResponse : BaseResponse
    {
        public IEnumerable<ProfileVehicleDto> Data { get; set; }
        public ProfileVehiclesResponse()
        {
            Data = new List<ProfileVehicleDto>();
        }
    } 
    public class ProfileVehicleDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public long InsuredIdentityNumber { get; set; }
        public long VehicleOwnerIdentityNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long VehicleId { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string VehiclePlateFirstLetter { get; set; }
        public string VehiclePlateSecondLetter { get; set; }
        public string VehiclePlateThirdLetter { get; set; }
        public string VehiclePlateFirstLetterAr { get; set; }
        public string VehiclePlateSecondLetterAr { get; set; }
        public string VehiclePlateThirdLetterAr { get; set; }
        public string VehicleModelYear { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleModelAr { get; set; }
        public string VehicleMakerAr { get; set; }
        public string VehicleMaker { get; set; }
        public string VehicleLogo { get; set; }
        public string VehicleMajorColor { get; set; }
        public string VehicleMajorColorAr { get; set; }
        public int NumberOfActivePolicies { get; set; }
        public int NumberOfActiveQuotes { get; set; }
        public int NumberOfReciepts { get; set; }
    }
}
