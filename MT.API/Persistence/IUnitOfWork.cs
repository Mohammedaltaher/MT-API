using AggriPortal.API.Persistence.Repository;
using System.Threading.Tasks;

namespace  AggriPortal.API.Persistence
{
    public interface IUnitOfWork
    {
        #region Log Activities
        IApplicationUserLoginHistoryRepository ApplicationUserLoginHistory { get; }
        ISMSLogRepository SMSLog { get; }
        IAPILogHistoryRepository APILogHistory { get; }
        #endregion
        #region Account
        IApplicationUserRepository ApplicationUser { get; }
        IApplicationUserClaimRepository ApplicationUserClaim { get; }
        #endregion
        #region Master Tables
        IProductTypeRepository ProductType { get; }
        IBenefitRepository Benefit { get; }
        IViolationRepository Violation { get; }
        IDiscountTypeRepository DiscountType { get; }
        IPremiumBreakdownRepository PremiumBreakdown { get; }
        IPromoCodeRepository PromoCode { get; }
        INCDFreeYearRepository NCDFreeYear { get; }
        IIdentityTypeRepository IdentityType { get; }
        IGenderRepository Gender { get; }
        IEducationLevelRepository EducationLevel { get; }
        ISocialStatusRepository SocialStatus { get; }
        IOccupationMaleRepository OccupationMale { get; }
        IOccupationFemaleRepository OccupationFemale { get; }
        ICountryRepository Country { get; }
        IRegionRepository Region { get; }
        ICityRepository City { get; }
        ILicenseTypeRepository LicenseType { get; }
        IDriverTypeRepository DriverType { get; }
        IDrivingPercentageRepository DrivingPercentage { get; }
        IMedicalConditionRepository MedicalCondition { get; }
        IMileageRepository Mileage { get; }
        IVehicleIdTypeRepository VehicleIdType { get; }
        IVehiclePlateTypeRepository VehiclePlateType { get; }
        IVehiclePlateLetterRepository VehiclePlateLetter { get; }
        ITransmissionTypeRepository TransmissionType { get; }
        IVehicleBodyTypeRepository VehicleBodyType { get; }
        IVehicleAxlesWeightRepository VehicleAxlesWeight { get; }
        IVehicleColorRepository VehicleColor { get; }
        IQuotationsMotorRequestVehicleDriverRepository QuotationsMotorRequestVehicleDriver { get; }
        IVehicleEngineSizeRepository VehicleEngineSize { get; }
        IVehicleSpecificationRepository VehicleSpecification { get; }
        IVehicleUseRepository VehicleUse { get; }
        IVehicleMakerRepository VehicleMaker { get; }
        IVehicleModelRepository VehicleModel { get; }
        IVehicleRepairMethodRepository VehicleRepairMethod { get; }
        IParkingLocationRepository ParkingLocation { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        IBankRepository Bank { get; }
        IRelationRepository Relation { get; }
        IAttachmentRepository Attachment { get; }
        IInsuranceCompanyRepository InsuranceCompany { get; }
        #endregion

        #region Quotation
        IQuotationsMotorRequestRepository QuotationsMotorRequest { get; }
        IQuotationsMotorResponseRepository QuotationsMotorResponse { get; }
        IQuotationsMotorResponseProductRepository QuotationsMotorResponseProduct { get; }
        IProductBenefitRepository QuotationsMotorResponseProductBenefit { get; }
        IClientQuotationRepository ClientQuotation { get; }
        #endregion

        #region Client
        IClientRepository Client { get; }
        IClientVehicleRepository ClientVehicle { get; }
        IClientPaymentRepository ClientPayment { get; }
        #endregion

        #region PoliciesMotor
        IPoliciesMotorRequestRepository PoliciesMotorRequest { get; }
        IPoliciesMotorRepository PoliciesMotor { get; }
        #endregion

        #region Ticket
        ITicketRepository Ticket { get; }
        ITicketTypeRepository TicketType { get; }
        ITicketStatusRepository TicketStatus { get; }
        ITicketFollowUpRepository TicketFollowUp { get; }
        #endregion
        Task Commit();
    }
}
 