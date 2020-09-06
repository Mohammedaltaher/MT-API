
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{

    public class ClientVehiclesRequestDto
    {
        public Guid ClientId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public  class ClientVehiclesResponseDto : BaseResponse
    {
        public IEnumerable<ClientVehicleDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class ClientVehicleDto
    {
        public Guid Id { get; set; }
        public int? VehiclePlateNumber { get; set; }
        public string VehiclePlateFirstLetterName { get; set; }
        public string VehiclePlateFirstLetterNameAr { get; set; }
        public string VehiclePlateSecondLetterName { get; set; }
        public string VehiclePlateSecondLetterNameAr { get; set; }
        public string VehiclePlateThirdLetterName { get; set; }
        public string VehiclePlateThirdLetterNameAr { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long VehicleOwnerIdentityNumber { get; set; }
        public int? VehicleModelYear { get; set; }
        public string VehicleMakerName { get; set; }
        public string VehicleMakerNameAr { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelNameAr { get; set; }
        public string VehicleMajorColorName { get; set; }
        public string VehicleMajorColorNameAr { get; set; }
        public string VehicleBodyTypeName { get; set; }
        public string VehicleBodyTypeNameAr { get; set; }
        public string VehicleRegistrationCityName { get; set; }
        public string VehicleRegistrationCityNameAr { get; set; }
        public string VehicleRegistrationExpiryDate { get; set; }
        public int? VehicleCylinders { get; set; }
        public int? VehicleWeight { get; set; }
        public int? VehicleCapacity { get; set; }
        public bool IsVehicleOwnerTransfer { get; set; }
        public string VehicleUseName { get; set; }
        public string VehicleUseNameAr { get; set; }
        public string VehicleTransmissionTypeName { get; set; }
        public string VehicleTransmissionTypeNameAr { get; set; }
        public string VehicleAxleWeightName { get; set; }
        public string VehicleAxleWeightNameAr { get; set; }

        /// <summary>
        /// Insert ClientVehicleSpecification in 1,2,3
        /// </summary>
        public string VehicleSpecifications { get; set; }
        public List<VehicleSpecificationList> VehicleSpecification { get; set; }
        public bool IsVehicleModified { get; set; }
        public string VehicleModificationDetails { get; set; }
        public string VehicleIdTypeName { get;  set; }
        public string VehicleIdTypeNameAr { get;  set; }
        public string VehicleRepairMethodName { get;  set; }
        public string VehicleRepairMethodNameAr { get;  set; }
        public string VehicleMakerLogo { get;  set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
    public class VehicleSpecificationList
    {
        public int VehicleSpecificationId { get; set; }
        public string VehicleSpecification { get; set; }
    }
}
