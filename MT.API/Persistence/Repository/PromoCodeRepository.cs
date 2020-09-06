using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IPromoCodeRepository : IBaseRepository<PromoCode>
    {
        /// Add other interface here
    }

    #region Implementation
    public class PromoCodeRepository: BaseRepository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
