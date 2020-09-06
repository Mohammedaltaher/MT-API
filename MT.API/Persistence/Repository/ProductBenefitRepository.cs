using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IProductBenefitRepository : IBaseRepository<QuotationsMotorResponseProductBenefit>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ProductBenefitRepository : BaseRepository<QuotationsMotorResponseProductBenefit>, IProductBenefitRepository
    {
        public ProductBenefitRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
