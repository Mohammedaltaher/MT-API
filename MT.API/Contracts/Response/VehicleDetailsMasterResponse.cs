using AggriPortal.API.Resources;
using AggriPortal.API.Domain.Models;
using System.Collections.Generic;


namespace  AggriPortal.API.Contracts.Response
{
    public class VehicleDetailsMasterResponse
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public IEnumerable<VehicleUseDto> VehicleUses { get; set; }
        public IEnumerable<TransmissionTypeDto> TransmissionTypes { get; set; }
        public IEnumerable<ParkingLocation> ParkingLocations { get; set; }
        public IEnumerable<Mileage> Mileages { get; set; }
    }
}
