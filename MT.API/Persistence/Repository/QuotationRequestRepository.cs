using AggriPortal.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AggriPortal.API.Resources;
using LinqKit;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IQuotationsMotorRequestRepository : IBaseRepository<QuotationsMotorRequest>
    {
        /// Add other interface here
        Task<QuotationsMotorRequest> GetQuotationRequestInclude(Guid Id);
        Task<QuotationsMotorRequest> GetQuotationRequestByIdentityAndVehicleId(long identityNumber, long vehicleId, string createdBy);
        Task<QuotationsMotorRequest> GetActiveQuotationRequestInclude(long identityNumber, long vehicleId, string createdBy);
        IEnumerable<QuotationsMotorRequest> GetQuotations(QuotationRequestDto req);
        QuotationsMotorRequest GetQuotationDetails(Guid id);
       IEnumerable<QuotationsMotorRequest> GetClientQuotations(Guid id);
    }

    #region Implementation
    public class QuotationsMotorRequestRepository: BaseRepository<QuotationsMotorRequest>, IQuotationsMotorRequestRepository
    {
        public QuotationsMotorRequestRepository(AppDbContext context)
            : base(context)
        {

        }
        public async Task<QuotationsMotorRequest> GetQuotationRequestInclude(Guid Id)
        {
          return await this.GetMany(x => x.Id == Id)
                .Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter")
                .Include("VehiclePlateThirsdLetter")
                .Include("VehicleMaker")
                .Include("VehicleModel")
                .Include("VehicleMajorColor")
                .Include("VehiclePlateThirsdLetter")
                .Include("QuotationsMotorResponses")
                .Include("QuotationsMotorResponses.InsuranceCompany")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.ProductType")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductBenefits")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductBenefits.Benefit")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.PremiumBreakdowns")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.PremiumBreakdowns.PremiumBreakdown")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.Discounts")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.Discounts.DiscountType").FirstOrDefaultAsync();
        }
        public async Task<QuotationsMotorRequest> GetQuotationRequestByIdentityAndVehicleId(long identityNumber, long vehicleId, string createdBy)
        {
          return await this.GetMany(q => q.InsuredIdentityNumber == identityNumber && q.VehicleId == vehicleId && q.CreatedBy == createdBy)
                .Include("QuotationsMotorRequestVehicleDrivers").Include("QuotationsMotorRequestVehicleDrivers.QuotationsMotorRequestVehicleDriverLicenses").OrderByDescending(x=>x.CreatedDate).Take(1).FirstOrDefaultAsync();
        }
        public async Task<QuotationsMotorRequest> GetActiveQuotationRequestInclude(long identityNumber, long vehicleId, string createdBy)
        {
            return await this.GetMany(p => p.InsuredIdentityNumber == identityNumber && p.VehicleId == vehicleId && p.CreatedBy == createdBy).OrderByDescending(x=>x.CreatedDate).Take(1)
                .Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter")
                .Include("VehiclePlateThirsdLetter")
                .Include("VehicleMaker")
                .Include("VehicleModel")
                .Include("VehicleMajorColor")
                .Include("VehiclePlateThirsdLetter")
                .Include("QuotationsMotorResponses")
                .Include("QuotationsMotorResponses.InsuranceCompany")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.ProductType")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductBenefits")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductBenefits.Benefit")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.PremiumBreakdowns")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.PremiumBreakdowns.PremiumBreakdown")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.Discounts")
                .Include("QuotationsMotorResponses.QuotationsMotorResponseProducts.QuotationsMotorResponseProductDeductibles.Discounts.DiscountType").FirstOrDefaultAsync();
        }

        #region Api Portal 
        public IEnumerable<QuotationsMotorRequest> GetQuotations(QuotationRequestDto req)
        {

            Expression<Func<QuotationsMotorRequest, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(req.InsuredFirstName))
            {
                predicate = predicate.And(p => p.InsuredFirstName == req.InsuredFirstName);
            }
            if (!string.IsNullOrEmpty(req.InsuredFirstNameAr))
            {
                predicate = predicate.And(p => p.InsuredFirstNameAr == req.InsuredFirstNameAr);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateFrom.Value.Date);
            }
            if (req.InsuredIdentityNumber != null)
            {
                predicate = predicate.And(p => p.InsuredIdentityNumber == req.InsuredIdentityNumber);
            }
            
            if (req.InsuredNationalityId != null)
            {
                predicate = predicate.And(p => p.InsuredNationalityId == req.InsuredNationalityId);
            }
           
            var data = this.GetMany(predicate)
                .Include("VehicleIdType").Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter").Include("VehiclePlateThirsdLetter")
                .Include("VehiclePlateType").Include("VehicleMaker").Include("VehicleModel").Include("VehicleMajorColor")
                .Include("VehicleBodyType").Include("VehicleRegistrationCity").Include("VehicleRepairMethod").Include("VehicleUse")
                .Include("VehicleTransmissionType").Include("VehicleAxleWeight");
            return data;
        }
        public QuotationsMotorRequest GetQuotationDetails(Guid id)
        {

            var data = this.GetMany(p => p.Id == id)
                .Include("VehicleIdType").Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter").Include("VehiclePlateThirsdLetter")
                .Include("VehiclePlateType").Include("VehicleMaker").Include("VehicleModel").Include("VehicleMajorColor")
                .Include("VehicleBodyType").Include("VehicleRegistrationCity").Include("VehicleRepairMethod").Include("VehicleUse")
                .Include("VehicleTransmissionType").Include("VehicleAxleWeight").FirstOrDefault();
            return data;
        }
        public IEnumerable<QuotationsMotorRequest> GetClientQuotations(Guid id)
        {
            var data = this.GetMany(p => p.ClientId == id)
                .Include("Client")
                .Include("Client.ApplicationUser")
                .Include("VehicleIdType")
                .Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter")
                .Include("VehiclePlateThirsdLetter")
                .Include("VehiclePlateType")
                .Include("VehicleMaker")
                .Include("VehicleModel")
                .Include("VehicleMajorColor")
                .Include("VehicleBodyType")
                .Include("VehicleRegistrationCity")
                .Include("VehicleRepairMethod")
                .Include("VehicleUse")
                .Include("VehicleTransmissionType")
                .Include("VehicleAxleWeight");
            return data;
        }
        #endregion
    }
    #endregion
}
