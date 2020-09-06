using System;

namespace  AggriPortal.API.Domain.Models
{
    public class ClientVehicle
    {
        public ClientVehicle()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public int VehicleIdTypeId { get; set; }
        public long VehicleId { get; set; }
        public int? VehiclePlateNumber { get; set; }
        public int? VehiclePlateFirstLetterId { get; set; }
        public int? VehiclePlateSecondLetterId { get; set; }
        public int? VehiclePlateThirdLetterId { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long VehicleOwnerIdentityNumber { get; set; }
        public int VehiclePlateTypeId { get; set; }
        public int? VehicleModelYear { get; set; }
        public int? VehicleMakerId { get; set; }
        public int? VehicleModelId { get; set; }
        public int? VehicleMajorColorId { get; set; }
        public int? VehicleBodyTypeId { get; set; }
        public int? VehicleRegistrationCityId { get; set; }
        public string VehicleRegistrationExpiryDate { get; set; }
        public int? VehicleCylinders { get; set; }
        public int? VehicleWeight { get; set; }
        public int? VehicleCapacity { get; set; }
        public bool IsVehicleOwnerTransfer { get; set; }
        public int? VehicleRepairMethodId { get; set; }
        public int? VehicleUseId { get; set; }
        public int? VehicleTransmissionTypeId { get; set; }
        public int? VehicleAxleWeightId { get; set; }

        /// <summary>
        /// Insert ClientVehicleSpecification in 1,2,3
        /// </summary>
        public string VehicleSpecifications { get; set; }
        public bool IsVehicleModified { get; set; }
        public string VehicleModificationDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Client Client { get; set; }
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

    }


}
