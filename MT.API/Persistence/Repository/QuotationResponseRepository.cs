using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IQuotationsMotorResponseRepository : IBaseRepository<QuotationsMotorResponse>
    {
        /// Add other interface here
        /// 
        Task<QuotationsMotorResponse> GetQuotationResponseInclude(Guid responseId);
    }

    #region Implementation
    public class QuotationResponseRepository: BaseRepository<QuotationsMotorResponse>, IQuotationsMotorResponseRepository
    {
        public QuotationResponseRepository(AppDbContext context)
            : base(context)
        {
            
        }
        public async Task<QuotationsMotorResponse> GetQuotationResponseInclude(Guid responseId)
        {

            return await this.GetMany(x => x.Id == responseId)
                .Include(p => p.QuotationsMotorResponseProducts)
                .Include("QuotationsMotorResponseProducts.ProductType")
                .Include("QuotationsMotorResponseProducts.QuotationsMotorResponseProductBenefits.Benefit")
                .Include("QuotationsMotorResponseProducts.PremiumBreakdowns.PremiumBreakdown")
                .Include("QuotationsMotorResponseProducts.Discounts.DiscountType").FirstOrDefaultAsync();

        }
    }
    #endregion
}
