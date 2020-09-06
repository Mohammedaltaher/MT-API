using AggriPortal.API.Persistence.Configuration;
using AggriPortal.API.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using AggriPortal.API.Domain.Dtos;

namespace  AggriPortal.API.Persistence
{

    public class AppDbContext : IdentityDbContext<
       ApplicationUser, ApplicationRole, string,
       ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
       ApplicationRoleClaim, ApplicationUserToken>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(IHttpContextAccessor httpContextAccessor, DbContextOptions<AppDbContext> options)
            : base((DbContextOptions)options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<APILogHistory> APILogHistory { get; set; }
        public DbSet<ApplicationUserLoginHistory> ApplicationUserLoginsHistory { get; set; }
        public DbSet<SMSLog> SMSLogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientVehicle> ClientVehicles { get; set; }
        public DbSet<ClientQuotationMotor> ClientQuotationsMotor { get; set; }
        public DbSet<ClientQuotationMotorBenefit> ClientQuotationMotorBenefits { get; set; }
        public DbSet<ClientQuotationMotorPremiumBreakdown> ClientQuotationMotorPremiumBreakdowns { get; set; }
        public DbSet<ClientQuotationMotorDiscount> ClientQuotationMotorDiscounts { get; set; }
        public DbSet<ClientPayment> ClientPayments { get; set; }
        public DbSet<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public DbSet<QuotationsMotorResponse> QuotationsMotorResponses { get; set; }
        public DbSet<QuotationsMotorResponseProduct> QuotationsMotorResponseProducts { get; set; }
        public DbSet<QuotationsMotorResponseProductBenefit> QuotationsMotorResponseProductBenefits { get; set; }
        public DbSet<QuotationsMotorResponseProductDeductible> ProductsDeductibles { get; set; }
        public DbSet<ProductPremiumBreakdown> ProductPremiumBreakdowns { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
        public DbSet<QuotationsMotorRequestVehicleDriverAccident> QuotationsMotorRequestVehicleDriverAccidents { get; set; }
        public DbSet<QuotationsMotorRequestVehicleDriverLicense> QuotationsMotorRequestVehicleDriverLicenses { get; set; }
        public DbSet<PolicyRequest> PolicyRequests { get; set; }
        public DbSet<PoliciesMotor> PoliciesMotors { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<PremiumBreakdown> PremiumBreakdowns { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<NCDFreeYear> NCDFreeYears { get; set; }
        public DbSet<IdentityType> IdentityTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<SocialStatus> SocialStatus { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<OccupationMale> OccupationMales { get; set; }
        public DbSet<OccupationFemale> OccupationFemales { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<DriverType> DriverTypes { get; set; }
        public DbSet<DrivingPercentage> DrivingPercentages { get; set; }
        public DbSet<MedicalCondition> MedicalConditions { get; set; }
        public DbSet<Mileage> Mileages { get; set; }
        public DbSet<VehicleIdType> VehicleIdTypes { get; set; }
        public DbSet<VehiclePlateType> VehiclePlateTypes { get; set; }
        public DbSet<VehiclePlateLetter> VehiclePlateText { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<VehicleBodyType> VehicleBodyTypes { get; set; }
        public DbSet<VehicleAxlesWeight> VehicleAxlesWeight { get; set; } 
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleEngineSize> VehicleEngineSizes { get; set; }
        public DbSet<VehicleSpecification> VehicleSpecifications { get; set; }
        public DbSet<VehicleUse> VehicleUses { get; set; }
        public DbSet<VehicleRepairMethod> VehicleRepairMethods { get; set; }
        public DbSet<ParkingLocation> ParkingLocations { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ChartDto> PoliciesChart { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<TicketFollowUp> TicketFollowUp { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();
            var userId = _httpContextAccessor?.HttpContext.User.Claims.SingleOrDefault(s => s.Type == JwtRegisteredClaimNames.Jti)?.Value;
            AddedEntities.ForEach(E =>
            {
                try
                {
                    E.Property("CreatedBy").CurrentValue = userId;
                }
                catch (Exception)
                {
                }
            });

            //var EditedEntities = ChangeTracker.Entries()
            //    .Where(E => E.State == EntityState.Modified)
            //    .ToList();

            //EditedEntities.ForEach(E =>
            //{
            //    E.Property("ModifiedDate").CurrentValue = DateTime.Now;
            //});

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #region UDF Funcs
        public static string GenerateQuotationRequetId()
        {
            throw new Exception();
        }
        public static string GeneratePolicyRequetId()
        {
            throw new Exception();
        }

        [DbFunction("GetActiveSavedQuoteByIdentityNumberAndVehicleId", "dbo")]
        public static int GetActiveSavedQuoteByIdentityNumberAndVehicleId(long identityNumber, long vehicleId, int defQuoteExpiryHour, string createdBy)
        {
            throw new Exception();
        }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDbFunction(() => GenerateQuotationRequetId());
            builder.HasDbFunction(() => GeneratePolicyRequetId());
            builder.ApplyConfigurationsFromAssembly(typeof(ProductTypeConfiguration).Assembly);
        }
    }
}
