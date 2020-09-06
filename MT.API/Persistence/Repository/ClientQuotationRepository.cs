using AggriPortal.API.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using AggriPortal.API.Resources;
using System.Linq.Expressions;
using LinqKit;
using AggriPortal.API.Domain.Enums;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IClientQuotationRepository : IBaseRepository<ClientQuotationMotor>
    {
        /// Add other interface here
        /// 

        Task<ClientQuotationMotor> GetClientQuotationInclude(Guid id);
        Task<ClientQuotationMotor> GetClientQuotationForPolicyInclude(Guid id);
        Task<ClientQuotationMotor> GetClientQuotationInclude(Guid quotationRequestId, Guid quotationProductId, int insuranceCompanyId, string createdBy);
        Task<ClientQuotationMotor> GetClientQuotationIncludeClientOnly(Guid id);
        Task<IEnumerable<ClientQuotationMotor>> GetClientQuoteByStatusInclude(string applicationUserId, int statusId);
        Task<IEnumerable<ClientQuotationMotor>> IsActiveSavedQuoteExists(long identityNumber, long vehicleId, int defQuoteExpiryHour, string createdBy);
        Task<IEnumerable<ClientQuotationMotor>> GetlatestQuotation(int year);
        IEnumerable<ClientQuotationMotor> GetClientQuotations(ClientQuotationRequestDto req);
        ClientQuotationMotor GetQoutationDetails(Guid Id);
        ClientQuotationMotor GetClientQuotation(Guid Id);
        IEnumerable<ClientQuotationMotor> GetQuotations(QuotationRequestDto req);

    }

    #region Implementation
    public class ClientQuotationRepository : BaseRepository<ClientQuotationMotor>, IClientQuotationRepository
    {
        public ClientQuotationRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<ClientQuotationMotor> GetClientQuotationInclude(Guid id)
        {
            return await this.GetMany(x => x.Id == id)
                           .Include("Client")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorRequest.VehicleRepairMethod")
                           .Include("QuotationsMotorRequest.DrivingCity")
                           .Include("QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotationMotorBenefits")
                           .Include("ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotationMotorDiscounts")
                           .Include("ClientQuotationMotorDiscounts.DiscountType").FirstOrDefaultAsync();
        }

        // Use this method to get quote data including benefits for policy requset.
        public async Task<ClientQuotationMotor> GetClientQuotationForPolicyInclude(Guid id)
        {
            return await this.GetMany(x => x.Id == id)
                           .Include("Client")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotationMotorBenefits")
                           .Include("ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotationMotorDiscounts")
                           .Include("ClientQuotationMotorDiscounts.DiscountType").FirstOrDefaultAsync();
        }

        public async Task<ClientQuotationMotor> GetClientQuotationInclude(Guid quotationRequestId, Guid quotationProductId, int insuranceCompanyId, string createdBy)
        {
            return await this.GetMany(p => p.QuotationRequestId == quotationRequestId &&
                                                                      p.QuotationProductId == quotationProductId &&
                                                                      p.InsuranceCompanyId == insuranceCompanyId &&
                                                                      p.CreatedBy == createdBy)
                           .Include("Client")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorRequest.VehicleRepairMethod")
                           .Include("QuotationsMotorRequest.DrivingCity")
                           .Include("QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotationMotorBenefits")
                           .Include("ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotationMotorDiscounts")
                           .Include("ClientQuotationMotorDiscounts.DiscountType").FirstOrDefaultAsync();
        }

        public async Task<ClientQuotationMotor> GetClientQuotationIncludeClientOnly(Guid id)
        {
            return await this.GetMany(x => x.Id == id)
                           .Include("Client")
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClientQuotationMotor>> GetClientQuoteByStatusInclude(string applicationUserId, int statusId)
        {
            return await this.GetMany(x => x.StatusId == statusId && x.CreatedBy == applicationUserId)
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType").ToListAsync();
        }

        public async Task<IEnumerable<ClientQuotationMotor>> IsActiveSavedQuoteExists(long identityNumber, long vehicleId, int defQuoteExpiryHour, string createdBy)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@identityNumber", identityNumber));
            parameters.Add(new SqlParameter("@vehicleId", vehicleId));
            parameters.Add(new SqlParameter("@defQuoteExpiryHour", defQuoteExpiryHour));
            parameters.Add(new SqlParameter("@createdBy", createdBy));
            var result = await this.ExcuteQuerys("EXEC dbo.GetActiveSavedQuoteByIdentityNumberAndVehicleId @identityNumber,@vehicleId,@defQuoteExpiryHour,@createdBy", parameters.ToArray());
            return result;
        }
        public async Task<IEnumerable<ClientQuotationMotor>> GetlatestQuotation(int year)
        {

            var data = await this.GetMany(p => p.StatusId != (int)ClientQuotationStatusEnum.Purchased && p.CreatedDate.Date.Year == year).OrderByDescending(p => p.CreatedDate)
                .Include("InsuranceCompany")
                .Include("QuotationsMotorRequest")
                .Include("Client")
                .Include("Client.ApplicationUser")
                .ToListAsync();
            return data;
        }
        public ClientQuotationMotor GetQoutationDetails(Guid Id)
        {

            var data = this.GetMany(p => p.Id == Id)
            .Include("Client")
            .Include("QuotationsMotorRequest")
            .Include("QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
            .Include("QuotationsMotorResponseProduct.QuotationsMotorResponseProductBenefits")
            .Include("QuotationsMotorResponseProduct.QuotationsMotorResponseProductBenefits.Benefit")
            .Include("QuotationsMotorResponseProduct")
            .Include("QuotationsMotorRequest.VehicleModel")
            .Include("QuotationsMotorRequest.VehicleMajorColor")
            .Include("QuotationsMotorRequest.VehicleRepairMethod")
             .Include("QuotationsMotorRequest.DrivingCity")
             .Include("InsuranceCompany")
             .Include("QuotationsMotorResponseProduct.ProductType").FirstOrDefault();
            return data;
        }
        public IEnumerable<ClientQuotationMotor> GetClientQuotations(ClientQuotationRequestDto req)
        {
            return this.GetMany(x => x.ClientId == req.ClientId)
                           .Include("Client")
                           .Include("Client.ApplicationUser")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorRequest.VehicleRepairMethod")
                           .Include("QuotationsMotorRequest.DrivingCity")
                           .Include("QuotationsMotorRequest.VehicleRegistrationCity")
                           .Include("QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotationMotorBenefits")
                           .Include("ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotationMotorDiscounts")
                           .Include("ClientQuotationMotorDiscounts.DiscountType");
        }
        public IEnumerable<ClientQuotationMotor> GetClienstQuotations(Guid clientId)
        {
            return this.GetMany(x => x.ClientId == clientId)
                           .Include("Client")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType");
        }
        public ClientQuotationMotor GetClientQuotation(Guid id)
        {
            return this.GetMany(x => x.Id == id)
                           .Include("Client")
                           .Include("Client.ApplicationUser")
                           .Include("InsuranceCompany")
                           .Include("QuotationsMotorRequest")
                           .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("QuotationsMotorRequest.VehicleMaker")
                           .Include("QuotationsMotorRequest.VehicleModel")
                           .Include("QuotationsMotorRequest.VehicleMajorColor")
                           .Include("QuotationsMotorRequest.VehicleRepairMethod")
                           .Include("QuotationsMotorRequest.DrivingCity")
                           .Include("QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
                           .Include("QuotationsMotorResponseProduct")
                           .Include("QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotationMotorBenefits")
                           .Include("ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotationMotorDiscounts")
                           .Include("ClientQuotationMotorDiscounts.DiscountType").FirstOrDefault();
        }

        public IEnumerable<ClientQuotationMotor> GetQuotations(QuotationRequestDto req)
        {

            Expression<Func<ClientQuotationMotor, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(req.InsuredFirstName))
            {
                predicate = predicate.And(p => p.QuotationsMotorRequest.InsuredFirstName == req.InsuredFirstName);
            }
            if (!string.IsNullOrEmpty(req.InsuredFirstNameAr))
            {
                predicate = predicate.And(p => p.QuotationsMotorRequest.InsuredFirstNameAr == req.InsuredFirstNameAr);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.QuotationsMotorRequest.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateFrom.Value.Date);
            }
            if (req.StatusId != null)
            {
                predicate = predicate.And(p => p.StatusId == req.StatusId);
            }
            if (req.InsuredIdentityNumber != null)
            {
                predicate = predicate.And(p => p.QuotationsMotorRequest.InsuredIdentityNumber == req.InsuredIdentityNumber);
            }
            if (req.InsuredNationalityId != null)
            {
                predicate = predicate.And(p => p.QuotationsMotorRequest.InsuredNationalityId == req.InsuredNationalityId);
            }
            var data = this.GetMany(predicate)
                .Include("Client")
                .Include("Client.ApplicationUser")
                .Include("InsuranceCompany")
                .Include("QuotationsMotorRequest")
                .Include("QuotationsMotorRequest.VehicleIdType")
                .Include("QuotationsMotorRequest.VehiclePlateFirstLetter")
                .Include("QuotationsMotorRequest.VehiclePlateSecondLetter")
                .Include("QuotationsMotorRequest.VehiclePlateThirsdLetter")
                .Include("QuotationsMotorRequest.VehiclePlateType")
                .Include("QuotationsMotorRequest.VehicleMaker")
                .Include("QuotationsMotorRequest.VehicleModel")
                .Include("QuotationsMotorRequest.VehicleMajorColor")
                .Include("QuotationsMotorRequest.VehicleBodyType")
                .Include("QuotationsMotorRequest.VehicleRegistrationCity")
                .Include("QuotationsMotorRequest.VehicleRepairMethod")
                .Include("QuotationsMotorRequest.VehicleUse")
                .Include("QuotationsMotorRequest.VehicleTransmissionType")
                .Include("QuotationsMotorRequest.VehicleAxleWeight");
            return data;
        }
    }
    #endregion
}
