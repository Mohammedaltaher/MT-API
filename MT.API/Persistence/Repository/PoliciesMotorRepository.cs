using AggriPortal.API.Domain.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using AggriPortal.API.Resources;
using AggriPortal.API.Domain.Dtos;
using System.Linq.Expressions;
using LinqKit;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IPoliciesMotorRepository : IBaseRepository<PoliciesMotor>
    {
        /// Add other interface here
        Task<IEnumerable<PoliciesMotor>> GetPoliciesInclude(string applicationUserId);
        Task<IEnumerable<PoliciesMotor>> GetActivePoliciesInclude(string applicationUserId);
        Task<IEnumerable<PoliciesMotor>> GetExpiredPoliciesInclude(string applicationUserId);
        Task<IEnumerable<PoliciesMotor>> GetExpiredPoliciesInclude(int year );
        Task<IEnumerable<PoliciesMotor>> GetAlmostExpiredPoliciesInclude(string applicationUserId, int days);
        Task<IEnumerable<PoliciesMotor>> GetPendingNajmPoliciesInclude(string applicationUserId);
        Task<IEnumerable<ChartDto>> GetPoliciesChart(int year);
        PoliciesMotor GetPoliciesDetails(Guid id);
        Task<PoliciesMotor> PrintInvoice(Guid id);
        Task<IEnumerable<ChartDto>> GetQuotitionRequestChart(int year);
        IEnumerable<PoliciesMotor> GetClientPolicies(Guid id);
        IEnumerable<PoliciesMotor> GetPolicies(PolicyRequestDto req);
    }

    #region Implementation
    public class PoliciesMotorRepository : BaseRepository<PoliciesMotor>, IPoliciesMotorRepository
    {
        public PoliciesMotorRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<PoliciesMotor>> GetPoliciesInclude(string applicationUserId)
        {
            return await this.GetMany(p => p.CreatedBy == applicationUserId).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }
        public async Task<IEnumerable<PoliciesMotor>> GetActivePoliciesInclude(string applicationUserId)
        {
            string sql = "SELECT * FROM [dbo].[PoliciesMotor] WHERE CreatedBy = @applicationUserId AND PolicyExpiryDate > GETDATE()";
            SqlParameter[] sqlParams = { new SqlParameter("@applicationUserId", applicationUserId) };
            return await this.context.PoliciesMotors.FromSqlRaw(sql, sqlParams).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }
        public async Task<IEnumerable<PoliciesMotor>> GetExpiredPoliciesInclude(string applicationUserId)
        {
            string sql = "SELECT * FROM [dbo].[PoliciesMotor] WHERE CreatedBy = @applicationUserId AND PolicyExpiryDate < GETDATE()";
            SqlParameter[] sqlParams = { new SqlParameter("@applicationUserId", applicationUserId) };
            return await this.context.PoliciesMotors.FromSqlRaw(sql, sqlParams).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }
        public async Task<IEnumerable<PoliciesMotor>> GetExpiredPoliciesInclude(int year)
        {
            string sql = "SELECT * FROM [dbo].[PoliciesMotor] WHERE PolicyExpiryDate < GETDATE() and year(CreatedDate) = " + year;
            return await this.context.PoliciesMotors.FromSqlRaw(sql).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }
        public async Task<IEnumerable<PoliciesMotor>> GetAlmostExpiredPoliciesInclude(string applicationUserId, int days)
        {
            string sql = "SELECT * FROM [dbo].[PoliciesMotor] WHERE CreatedBy = @applicationUserId AND DATEDIFF(DAY,GETDATE(),PolicyExpiryDate) BETWEEN -31 AND @days";
            SqlParameter[] sqlParams = { new SqlParameter("@applicationUserId", applicationUserId), new SqlParameter("@days", days) };
            return await this.context.PoliciesMotors.FromSqlRaw(sql, sqlParams).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }
        public async Task<IEnumerable<PoliciesMotor>> GetPendingNajmPoliciesInclude(string applicationUserId)
        {
            return await this.GetMany(p => p.CreatedBy == applicationUserId && !p.IsNajmUpdated).Include("InsuranceCompany").Include("ProductType").ToListAsync();
        }


        public async Task<IEnumerable<ChartDto>> GetPoliciesChart(int year)
        {
            string sql = "SELECT [Name] ,NameAr ,(select count(Id) from [dbo].[PoliciesMotor] where Month(CreatedDate) = m.Code and YEAR(CreatedDate) = @year) as [Value] from [dbo].[SettingsMonth] m";
            SqlParameter[] sqlParams = { new SqlParameter("@year", year) };
            var data = await context.PoliciesChart.FromSqlRaw(sql, sqlParams).ToListAsync();
            return data;
        }
        public async Task<IEnumerable<ChartDto>> GetQuotitionRequestChart(int year)
        {
            string sql = "SELECT [Name] ,NameAr ,(select count(Id) from [dbo].[ClientQuotationMotor] where Month(CreatedDate) = m.Code and YEAR(CreatedDate) = @year) as [Value] from [dbo].[SettingsMonth] m";
            SqlParameter[] sqlParams = { new SqlParameter("@year", year) };
            var data = await context.PoliciesChart.FromSqlRaw(sql, sqlParams).ToListAsync();
            return data;
        }
        public PoliciesMotor GetPoliciesDetails(Guid id)
        {

            var data = this.GetMany(p => p.Id == id)
                           .Include("Client")
                           .Include("InsuranceCompany")
                           .Include("ProductType")
                           .Include("ClientQuotation.QuotationsMotorRequest")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateFirstLetter")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateSecondLetter")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateThirsdLetter")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehicleMaker")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehicleModel")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehicleMajorColor")
                           .Include("ClientQuotation.QuotationsMotorRequest.VehicleRepairMethod")
                           .Include("ClientQuotation.QuotationsMotorRequest.DrivingCity")
                           .Include("ClientQuotation.QuotationsMotorRequest.QuotationsMotorRequestVehicleDrivers")
                           .Include("ClientQuotation.QuotationsMotorResponseProduct")
                           .Include("ClientQuotation.QuotationsMotorResponseProduct.ProductType")
                           .Include("ClientQuotation.ClientQuotationMotorBenefits")
                           .Include("ClientQuotation.ClientQuotationMotorBenefits.Benefit")
                           .Include("ClientQuotation.ClientQuotationMotorPremiumBreakdowns")
                           .Include("ClientQuotation.ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                           .Include("ClientQuotation.ClientQuotationMotorDiscounts")
                           .Include("ClientQuotation.ClientQuotationMotorDiscounts.DiscountType").FirstOrDefault();
            return data;
        }
        public async Task<PoliciesMotor> PrintInvoice(Guid id)
        {

            return await this.GetMany(p => p.Id == id)
                .Include("Client")
                .Include("InsuranceCompany")
                .Include("ProductType")
                .Include("ClientQuotation")
                .Include("ClientQuotation.QuotationsMotorRequest")
                .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateFirstLetter")
                .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateSecondLetter")
                .Include("ClientQuotation.QuotationsMotorRequest.VehiclePlateThirsdLetter")
                .Include("ClientQuotation.ClientQuotationMotorBenefits")
                .Include("ClientQuotation.ClientQuotationMotorBenefits.Benefit")
                .Include("ClientQuotation.ClientQuotationMotorPremiumBreakdowns")
                .Include("ClientQuotation.ClientQuotationMotorPremiumBreakdowns.PremiumBreakdown")
                .Include("ClientQuotation.ClientQuotationMotorDiscounts")
                .Include("ClientQuotation.ClientQuotationMotorDiscounts.DiscountType")
                .Include("ClientQuotation.QuotationsMotorRequest.VehicleMaker")
                .Include("ClientQuotation.QuotationsMotorRequest.VehicleModel")
                .Include("ClientQuotation.QuotationsMotorRequest.VehicleMajorColor")
                .FirstOrDefaultAsync();
        }
        public IEnumerable<PoliciesMotor> GetClientPolicies(Guid id)
        {

            var data = this.GetMany(p => p.ClientId == id)
                .Include("Client")
                .Include("Client.ApplicationUser")
                .Include("InsuranceCompany")
                .Include("ProductType");
            return data;
        }
        public IEnumerable<PoliciesMotor> GetPolicies(PolicyRequestDto req)
        {

            Expression<Func<PoliciesMotor, bool>> predicate = c => true;

            if (!string.IsNullOrEmpty(req.ClientName))
            {
                predicate = predicate.And(p => p.Client.FirstName.Contains(req.ClientName) || p.Client.FirstNameAr.Contains(req.ClientName));
            }
            if (!string.IsNullOrEmpty(req.PolicyRequestRefId))
            {
                predicate = predicate.And(p => p.PolicyRequestRefId == req.PolicyRequestRefId);
            }
            if (!string.IsNullOrEmpty(req.QuotationRequestRefId))
            {
                predicate = predicate.And(p => p.QuotationRequestRefId == req.QuotationRequestRefId);
            }
            if (!string.IsNullOrEmpty(req.InsuranceQuotationId))
            {
                predicate = predicate.And(p => p.InsuranceQuotationId == req.InsuranceQuotationId);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateTo.Value.Date);
            }
            if (req.InsuranceCompanyId != null)
            {
                predicate = predicate.And(p => p.InsuranceCompanyId == req.InsuranceCompanyId);
            }
            if (req.VehicleId != null)
            {
                predicate = predicate.And(p => p.VehicleId == req.VehicleId);
            }
            if (req.ProductTypeId != null)
            {
                predicate = predicate.And(p => p.ProductTypeId == req.ProductTypeId);
            }
            if (req.InsuredId != null)
            {
                predicate = predicate.And(p => p.InsuredId == req.InsuredId);
            }
            var data = this.GetMany(predicate)
                .Include("InsuranceCompany")
                .Include("Client.ApplicationUser")
                .Include("Client")
                .Include("ProductType");
            return data;
        }

    }
    #endregion
}
