using System.Threading.Tasks;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Persistence.Repository;

namespace  AggriPortal.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Property
        private AppDbContext _context;
        private ISMSLogRepository _smsLog;
        private IApplicationUserLoginHistoryRepository _loginHistory;
        private IAPILogHistoryRepository _apiLogHistory;
        // Master Tables.
        #region Master Tables.
        private IProductTypeRepository _productType;
        private IBenefitRepository _benefit;
        private IViolationRepository _violation;
        private IDiscountTypeRepository _discountType;
        private IPremiumBreakdownRepository _premiumBreakdown;
        private IPromoCodeRepository _promoCode;
        private INCDFreeYearRepository _NCDFreeYear;
        private IIdentityTypeRepository _identityType;
        private IGenderRepository _gender;
        private IEducationLevelRepository _educationLevel;
        private ISocialStatusRepository _socialStatus;
        private ICountryRepository _country;
        private IRegionRepository _region;
        private ICityRepository _city;
        private ILicenseTypeRepository _licenseType;
        private IDriverTypeRepository _driverType;
        private IDrivingPercentageRepository _drivingPercentage;
        private IMedicalConditionRepository _medicalCondition;
        private IMileageRepository _mileage;
        private IVehicleIdTypeRepository _vehicleIdType;
        private IVehiclePlateTypeRepository _vehiclePlateType;
        private IVehiclePlateLetterRepository _vehiclePlateLetter;
        private ITransmissionTypeRepository _transmissionType;
        private IVehicleBodyTypeRepository _vehicleBodyType;
        private IVehicleAxlesWeightRepository _vehicleAxlesWeight;
        private IVehicleColorRepository _vehicleColor;
        private IQuotationsMotorRequestVehicleDriverRepository _vehicleDriver;
        private IVehicleEngineSizeRepository _vehicleEngineSize;
        private IVehicleSpecificationRepository _vehicleSpecification;
        private IVehicleUseRepository _vehicleUse;
        private IVehicleMakerRepository _vehicleMaker;
        private IVehicleModelRepository _vehicleModel;
        private IVehicleRepairMethodRepository _vehicleRepairMethod;
        private IParkingLocationRepository _parkingLocation;
        private IPaymentMethodRepository _paymentMethod;
        private IBankRepository _bank;
        private IAttachmentRepository _attachment;
        private IOccupationMaleRepository _occupationMale;
        private IOccupationFemaleRepository _occupationFemale;
        private IInsuranceCompanyRepository _insuranceCompany;
        private IRelationRepository _relation;
        #endregion
        private IApplicationUserRepository _ApplicationUser;
        private ApplicationUserClaimRepository _ApplicationUserClaim;

        // Quotations Motor Request.
        private IQuotationsMotorRequestRepository _quotationRequest;
        private IQuotationsMotorResponseRepository _quotationsMotorResponse;
        private IQuotationsMotorResponseProductRepository _quotationProduct;
        private IProductBenefitRepository _productBenefit;
        private IClientRepository _client;
        private IClientVehicleRepository _clientVehicle;
        private IClientQuotationRepository _clientQuotation;
        private IClientPaymentRepository _clientPayment;

        // Policies Motor
        private IPoliciesMotorRepository _policiesMotor;
        private IPoliciesMotorRequestRepository _policiesMotorRequest;
        // ticket
        private ITicketRepository _ticket;
        private ITicketTypeRepository _ticketType;
        private ITicketStatusRepository _ticketStatus; 
        private ITicketFollowUpRepository _ticketFollowUp; 

        #endregion

        public UnitOfWork(AppDbContext dbContext)
        {
            this._context = dbContext;
        }

        #region Log Activities
        public IAPILogHistoryRepository APILogHistory
        {
            get
            {
                if (_apiLogHistory == null)
                {
                    _apiLogHistory = new APILogHistoryRepository(_context);
                }

                return _apiLogHistory;
            }
        }
        public ISMSLogRepository SMSLog
        {
            get
            {
                if (_smsLog == null)
                {
                    _smsLog = new SMSLogRepository(_context);
                }

                return _smsLog;
            }
        }
        public IApplicationUserLoginHistoryRepository ApplicationUserLoginHistory
        {
            get
            {
                if (_loginHistory == null)
                {
                    _loginHistory = new ApplicationUserLoginHistoryRepository(_context);
                }

                return _loginHistory;
            }
        }
        #endregion

        #region Account
        public IApplicationUserRepository ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                {
                    _ApplicationUser = new ApplicationUserRepository(_context);
                }

                return _ApplicationUser;
            }
        }
        public IApplicationUserClaimRepository ApplicationUserClaim
        {
            get
            {
                if (_ApplicationUserClaim == null)
                {
                    _ApplicationUserClaim = new ApplicationUserClaimRepository(_context);
                }

                return _ApplicationUserClaim;
            }
        }
        #endregion

        #region Master Tables
        public IProductTypeRepository ProductType
        {
            get
            {
                if (_productType == null)
                {
                    _productType = new ProductTypeRepository(_context);
                }

                return _productType;
            }
        }
        public IBenefitRepository Benefit
        {
            get
            {
                if (_benefit == null)
                {
                    _benefit = new BenefitRepository(_context);
                }

                return _benefit;
            }
        }
        public IViolationRepository Violation
        {
            get
            {
                if (_violation == null)
                {
                    _violation = new ViolationRepository(_context);
                }

                return _violation;
            }
        }
        public IDiscountTypeRepository DiscountType
        {
            get
            {
                if (_discountType == null)
                {
                    _discountType = new DiscountTypeRepository(_context);
                }

                return _discountType;
            }
        }
        public IPremiumBreakdownRepository PremiumBreakdown
        {
            get
            {
                if (_premiumBreakdown == null)
                {
                    _premiumBreakdown = new PremiumBreakdownRepository(_context);
                }

                return _premiumBreakdown;
            }
        }
        public IPromoCodeRepository PromoCode
        {
            get
            {
                if (_promoCode == null)
                {
                    _promoCode = new PromoCodeRepository(_context);
                }

                return _promoCode;
            }
        }
        public IIdentityTypeRepository IdentityType
        {
            get
            {
                if (_identityType == null)
                {
                    _identityType = new IdentityTypeRepository(_context);
                }

                return _identityType;
            }
        }
        public INCDFreeYearRepository NCDFreeYear
        {
            get
            {
                if (_NCDFreeYear == null)
                {
                    _NCDFreeYear = new NCDFreeYearRepository(_context);
                }

                return _NCDFreeYear;
            }
        }
        public IGenderRepository Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new GenderRepository(_context);
                }

                return _gender;
            }
        }
        public IEducationLevelRepository EducationLevel
        {
            get
            {
                if (_educationLevel == null)
                {
                    _educationLevel = new EducationLevelRepository(_context);
                }

                return _educationLevel;
            }
        }
        public ISocialStatusRepository SocialStatus
        {
            get
            {
                if (_socialStatus == null)
                {
                    _socialStatus = new SocialStatusRepository(_context);
                }

                return _socialStatus;
            }
        }
        public IRegionRepository Region
        {
            get
            {
                if (_region == null)
                {
                    _region = new RegionRepository(_context);
                }

                return _region;
            }
        }
        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_context);
                }

                return _country;
            }
        }
        public ICityRepository City
        {
            get
            {
                if (_city == null)
                {
                    _city = new CityRepository(_context);
                }

                return _city;
            }
        }
        public ILicenseTypeRepository LicenseType
        {
            get
            {
                if (_licenseType == null)
                {
                    _licenseType = new LicenseTypeRepository(_context);
                }

                return _licenseType;
            }
        }
        public IDriverTypeRepository DriverType
        {
            get
            {
                if (_driverType == null)
                {
                    _driverType = new DriverTypeRepository(_context);
                }

                return _driverType;
            }
        }
        public IDrivingPercentageRepository DrivingPercentage
        {
            get
            {
                if (_drivingPercentage == null)
                {
                    _drivingPercentage = new DrivingPercentageRepository(_context);
                }

                return _drivingPercentage;
            }
        }
        public IMedicalConditionRepository MedicalCondition
        {
            get
            {
                if (_medicalCondition == null)
                {
                    _medicalCondition = new MedicalConditionRepository(_context);
                }

                return _medicalCondition;
            }
        }
        public IMileageRepository Mileage
        {
            get
            {
                if (_mileage == null)
                {
                    _mileage = new MileageRepository(_context);
                }

                return _mileage;
            }
        }
        public IVehicleIdTypeRepository VehicleIdType
        {
            get
            {
                if (_vehicleIdType == null)
                {
                    _vehicleIdType = new VehicleIdTypeRepository(_context);
                }

                return _vehicleIdType;
            }
        }
        public IVehiclePlateTypeRepository VehiclePlateType
        {
            get
            {
                if (_vehiclePlateType == null)
                {
                    _vehiclePlateType = new VehiclePlateTypeRepository(_context);
                }

                return _vehiclePlateType;
            }
        }
        public IVehiclePlateLetterRepository VehiclePlateLetter
        {
            get
            {
                if (_vehiclePlateLetter == null)
                {
                    _vehiclePlateLetter = new VehiclePlateLetterRepository(_context);
                }

                return _vehiclePlateLetter;
            }
        }
        public ITransmissionTypeRepository TransmissionType
        {
            get
            {
                if (_transmissionType == null)
                {
                    _transmissionType = new TransmissionTypeRepository(_context);
                }

                return _transmissionType;
            }
        }
        public IVehicleBodyTypeRepository VehicleBodyType
        {
            get
            {
                if (_vehicleBodyType == null)
                {
                    _vehicleBodyType = new VehicleBodyTypeRepository(_context);
                }

                return _vehicleBodyType;
            }
        }
        public IVehicleAxlesWeightRepository VehicleAxlesWeight
        {
            get
            {
                if (_vehicleAxlesWeight == null)
                {
                    _vehicleAxlesWeight = new VehicleAxlesWeightRepository(_context);
                }

                return _vehicleAxlesWeight;
            }
        }
        public IVehicleColorRepository VehicleColor
        {
            get
            {
                if (_vehicleColor == null)
                {
                    _vehicleColor = new VehicleColorRepository(_context);
                }

                return _vehicleColor;
            }
        }
        public IVehicleEngineSizeRepository VehicleEngineSize
        {
            get
            {
                if (_vehicleEngineSize == null)
                {
                    _vehicleEngineSize = new VehicleEngineSizeRepository(_context);
                }

                return _vehicleEngineSize;
            }
        }
        public IVehicleSpecificationRepository VehicleSpecification
        {
            get
            {
                if (_vehicleSpecification == null)
                {
                    _vehicleSpecification = new VehicleSpecificationRepository(_context);
                }

                return _vehicleSpecification;
            }
        }
        public IVehicleUseRepository VehicleUse
        {
            get
            {
                if (_vehicleUse == null)
                {
                    _vehicleUse = new VehicleUseRepository(_context);
                }

                return _vehicleUse;
            }
        }
        public IVehicleMakerRepository VehicleMaker
        {
            get
            {
                if (_vehicleMaker == null)
                {
                    _vehicleMaker = new VehicleMakerRepository(_context);
                }

                return _vehicleMaker;
            }
        }
        public IVehicleModelRepository VehicleModel
        {
            get
            {
                if (_vehicleModel == null)
                {
                    _vehicleModel = new VehicleModelRepository(_context);
                }

                return _vehicleModel;
            }
        }
        public IVehicleRepairMethodRepository VehicleRepairMethod
        {
            get
            {
                if (_vehicleRepairMethod == null)
                {
                    _vehicleRepairMethod = new VehicleRepairMethodRepository(_context);
                }

                return _vehicleRepairMethod;
            }
        }
        public IParkingLocationRepository ParkingLocation
        {
            get
            {
                if (_parkingLocation == null)
                {
                    _parkingLocation = new ParkingLocationRepository(_context);
                }

                return _parkingLocation;
            }
        }
        public IPaymentMethodRepository PaymentMethod
        {
            get
            {
                if (_paymentMethod == null)
                {
                    _paymentMethod = new PaymentMethodRepository(_context);
                }

                return _paymentMethod;
            }
        }
        public IBankRepository Bank
        {
            get
            {
                if (_bank == null)
                {
                    _bank = new BankRepository(_context);
                }

                return _bank;
            }
        }
        public IOccupationMaleRepository OccupationMale
        {
            get
            {
                if (_occupationMale == null)
                {
                    _occupationMale = new OccupationMaleRepository(_context);
                }

                return _occupationMale;
            }
        }
        public IOccupationFemaleRepository OccupationFemale
        {
            get
            {
                if (_occupationFemale == null)
                {
                    _occupationFemale = new OccupationFemaleRepository(_context);
                }

                return _occupationFemale;
            }
        }
        public IRelationRepository Relation
        {
            get
            {
                if (_relation == null)
                {
                    _relation = new RelationRepository(_context);
                }
                return _relation;
            }
        }
        public IAttachmentRepository Attachment
        {
            get
            {
                if (_attachment == null)
                {
                    _attachment = new AttachmentRepository(_context);
                }

                return _attachment;
            }
        }
        public IInsuranceCompanyRepository InsuranceCompany
        {
            get
            {
                if (_insuranceCompany == null)
                {
                    _insuranceCompany = new InsuranceCompanyRepository(_context);
                }

                return _insuranceCompany;
            }
        }

        #endregion

        #region Quotation
        public IQuotationsMotorRequestRepository QuotationsMotorRequest
        {
            get
            {
                if (_quotationRequest == null)
                {
                    _quotationRequest = new QuotationsMotorRequestRepository(_context);
                }

                return _quotationRequest;
            }
        }
        public IQuotationsMotorRequestVehicleDriverRepository QuotationsMotorRequestVehicleDriver
        {
            get
            {
                if (_vehicleDriver == null)
                {
                    _vehicleDriver = new QuotationsMotorRequestVehicleDriverRepository(_context);
                }

                return _vehicleDriver;
            }
        }
        public IQuotationsMotorResponseRepository QuotationsMotorResponse
        {
            get
            {
                if (_quotationsMotorResponse == null)
                {
                    _quotationsMotorResponse = new QuotationResponseRepository(_context);
                }

                return _quotationsMotorResponse;
            }
        }
        public IQuotationsMotorResponseProductRepository QuotationsMotorResponseProduct
        {
            get
            {
                if (_quotationProduct == null)
                {
                    _quotationProduct = new QuotationsMotorResponseProductRepository(_context);
                }

                return _quotationProduct;
            }
        }
        public IProductBenefitRepository QuotationsMotorResponseProductBenefit
        {
            get
            {
                if (_productBenefit == null)
                {
                    _productBenefit = new ProductBenefitRepository(_context);
                }

                return _productBenefit;
            }
        }
        #endregion

        #region Client
        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_context);
                }

                return _client;
            }
        }
        public IClientVehicleRepository ClientVehicle
        {
            get
            {
                if (_clientVehicle == null)
                {
                    _clientVehicle = new ClientVehicleRepository(_context);
                }

                return _clientVehicle;
            }
        }
        public IClientQuotationRepository ClientQuotation
        {
            get
            {
                if(_clientQuotation == null)
                {
                    _clientQuotation = new ClientQuotationRepository(_context);
                }
                return _clientQuotation;
            }
        }
        public IClientPaymentRepository ClientPayment
        {
            get
            {
                if (_clientPayment == null)
                {
                    _clientPayment = new ClientPaymentRepository(_context);
                }
                return _clientPayment;
            }
        }
        #endregion

        #region Policy
        public IPoliciesMotorRepository PoliciesMotor
        {
            get
            {
                if (_policiesMotor == null)
                {
                    _policiesMotor = new PoliciesMotorRepository(_context);
                }
                return _policiesMotor;
            }
        }

        public IPoliciesMotorRequestRepository PoliciesMotorRequest
        {
            get
            {
                if (_policiesMotorRequest == null)
                {
                    _policiesMotorRequest = new PoliciesMotorRequestRepository(_context);
                }
                return _policiesMotorRequest;
            }
        }

        #endregion

        #region Ticket
        public ITicketRepository Ticket
        {
            get
            {
                if (_ticket == null)
                {
                    _ticket = new TicketRepository(_context);
                }
                return _ticket;
            }
        }

        public ITicketTypeRepository TicketType
        {
            get
            {
                if (_ticketType == null)
                {
                    _ticketType = new TicketTypeRepository(_context);
                }
                return _ticketType;
            }
        }
        public ITicketStatusRepository TicketStatus
        {
            get
            {
                if (_ticketStatus == null)
                {
                    _ticketStatus = new TicketStatusRepository(_context);
                }
                return _ticketStatus;
            }
        }
        public ITicketFollowUpRepository TicketFollowUp
        {
            get
            {
                if (_ticketFollowUp == null)
                {
                    _ticketFollowUp = new TicketFollowUpRepository(_context);
                }
                return _ticketFollowUp;
            }
        }
        
        #endregion
        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
 