using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class QuotationsMotorRequest
    {
        public QuotationsMotorRequest()
        {
            Id = Guid.NewGuid();
            IsExternalLogin = true;
            CreatedDate = DateTime.Now;
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
            QuotationsMotorResponses = new HashSet<QuotationsMotorResponse>();
            ClientQuotationMotors = new HashSet<ClientQuotationMotor>();
        }
        public Guid Id { get; set; }
        public string RequestReferenceId { get; set; }
        public Guid? ClientId { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string PromoCode { get; set; }
        public int InsuredIdentityTypeId { get; set; }
        public long InsuredIdentityNumber { get; set; }
        public string InsuredBirthDate { get; set; }
        public string InsuredGenderId { get; set; }
        public int InsuredNationalityId { get; set; }
        public int? InsuredIdentityIssuePlaceId { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredMiddleName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredFirstNameAr { get; set; }
        public string InsuredMiddleNameAr { get; set; }
        public string InsuredLastNameAr { get; set; }
        public int? InsuredSocialStatusId { get; set; }
        public int? InsuredOccupationId { get; set; }
        public int? InsuredEducationLevelId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? InsuredWorkCityId { get; set; }
        public int? DrivingCityId { get; set; }
        public int? InsuredBuildingNumber { get; set; }
        public string InsuredStreet { get; set; }
        public string InsuredDistrict { get; set; }
        public string InsuredCity { get; set; }
        public int? InsuredPostalCode { get; set; }
        public int? InsuredAdditionalNumber { get; set; }
        public int VehicleIdTypeId { get; set; }
        public long VehicleId { get; set; }
        public int VehiclePlateNumber { get; set; }
        public int VehiclePlateFirstLetterId { get; set; }
        public int VehiclePlateSecondLetterId { get; set; }
        public int VehiclePlateThirdLetterId { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long? VehicleOwnerIdentityNumber { get; set; }
        public int VehiclePlateTypeId { get; set; }
        public int VehicleModelYear { get; set; }
        public int VehicleMakerId { get; set; }
        public int VehicleModelId { get; set; }
        public int? VehicleMajorColorId { get; set; }
        public int? VehicleBodyTypeId { get; set; }
        public int? VehicleRegistrationCityId { get; set; }
        public string VehicleRegistrationExpiryDate { get; set; }
        public int? VehicleCylinders { get; set; }
        public int? VehicleWeight { get; set; }
        public int? VehicleCapacity { get; set; }
        public bool IsVehicleOwnerTransfer { get; set; }
        public decimal VehicleSumInsured { get; set; }
        public int? VehicleRepairMethodId { get; set; }
        public int? VehicleEngineSizeId { get; set; }
        public int VehicleUseId { get; set; }
        public int? VehicleCurrentMileage { get; set; }
        public int? VehicleTransmissionTypeId { get; set; }
        public int? VehicleMileageExpectedAnnualId { get; set; }
        public int? VehicleAxleWeightId { get; set; }
        public int? VehicleParkingLocationId { get; set; }
        public bool IsVehicleModified { get; set; }
        public string VehicleModificationDetails { get; set; }
        public int? NCDFreeYearId { get; set; }
        public string NCDReference { get; set; }
        /// <summary>
        /// Insert vehicle specification Id as 1,2,3
        /// </summary>
        public string VehicleSpecifications { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsExternalLogin { get; set; }
        public string CreatedBy { get; set; }
        public IdentityType IdentityType { get; set; }
        public Gender Gender { get; set; }
        public City IdentityIssuePlace { get; set; }
        public City WorkCity { get; set; }
        public City DrivingCity { get; set; }
        public Country Nationality { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public Client Client { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public VehicleIdType VehicleIdType { get; set; }
        public VehiclePlateLetter VehiclePlateFirstLetter { get; set; }
        public VehiclePlateLetter VehiclePlateSecondLetter { get; set; }
        public VehiclePlateLetter VehiclePlateThirsdLetter { get; set; }
        public VehiclePlateType VehiclePlateType { get; set; }
        public VehicleMaker VehicleMaker { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public VehicleColor VehicleMajorColor { get; set; }
        public VehicleBodyType VehicleBodyType { get; set; }
        public City VehicleRegistrationCity { get; set; }
        public VehicleRepairMethod VehicleRepairMethod { get; set; }
        public VehicleUse VehicleUse { get; set; }
        public TransmissionType VehicleTransmissionType { get; set; }
        public VehicleAxlesWeight VehicleAxleWeight { get; set; }
        public NCDFreeYear NCDFreeYear { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
        public ICollection<QuotationsMotorResponse> QuotationsMotorResponses { get; private set; }
        public ICollection<ClientQuotationMotor> ClientQuotationMotors { get; private set; }

    }
}
