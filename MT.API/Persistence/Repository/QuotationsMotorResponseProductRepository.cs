using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IQuotationsMotorResponseProductRepository : IBaseRepository<QuotationsMotorResponseProduct>
    {
        /// Add other interface here
        /// 
        //Task<QuotationsMotorResponseProduct> GetQuotationProductInclude(Guid quotationProductId);
    }

    #region Implementation
    public class QuotationsMotorResponseProductRepository: BaseRepository<QuotationsMotorResponseProduct>, IQuotationsMotorResponseProductRepository
    {
        public QuotationsMotorResponseProductRepository(AppDbContext context)
            : base(context)
        {

        }

        //public Task<QuotationsMotorResponseProduct> GetQuotationProductInclude(Guid quotationProductId)
        //{
        //    //quotationProductId = "7DD90676-1CF3-4332-AC1F-3FEFD9A66805"
        //    var data = this.GetMany(x => x.Id == quotationProductId)
        //        .Include(p => p.ProductType)
        //        .Include(p => p.PremiumBreakdowns)
        //        .Include(p => p.Discounts)
        //        .Include("Discounts.DiscountType").FirstOrDefaultAsync();
        //    return data;
        //}
    }
    #endregion
}
