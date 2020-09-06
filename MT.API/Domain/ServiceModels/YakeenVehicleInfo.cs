namespace  AggriPortal.API.Domain.ServiceModels
{
    public class YakeenVehicleInfo
    {
        public long VehicleId { get; set; }
        public int VehiclePlateNumber { get; set; }
        public int? VehiclePlateFirstLetterId { get; set; }
        public int? VehiclePlateSecondLetterId { get; set; }
        public int? VehiclePlateThirdLetterId { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long? VehicleOwnerIdentityNumber { get; set; }
        public int? VehiclePlateTypeId { get; set; }
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
    }
}
