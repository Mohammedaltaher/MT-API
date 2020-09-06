using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Vehicle Plate Alpha
    /// </summary>
    public class VehiclePlateLetter
    {
        public VehiclePlateLetter()
        {
            ClientVehicleFrLetters = new HashSet<ClientVehicle>();
            ClientVehicleScLetters = new HashSet<ClientVehicle>();
            ClientVehicleThLetters = new HashSet<ClientVehicle>();

            QuotationRequestFrLetters = new HashSet<QuotationsMotorRequest>();
            QuotationRequestScLetters = new HashSet<QuotationsMotorRequest>();
            QuotationRequestThLetters = new HashSet<QuotationsMotorRequest>();
        }
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name in english
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<ClientVehicle> ClientVehicleFrLetters { get; set; }
        public ICollection<ClientVehicle> ClientVehicleScLetters { get; set; }
        public ICollection<ClientVehicle> ClientVehicleThLetters { get; set; }

        public ICollection<QuotationsMotorRequest> QuotationRequestFrLetters { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestScLetters { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationRequestThLetters { get; set; }

    }
}
