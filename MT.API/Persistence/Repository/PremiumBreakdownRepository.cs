using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IPremiumBreakdownRepository : IBaseRepository<PremiumBreakdown>
    {
        /// Add other interface here
    }

    #region Implementation
    public class PremiumBreakdownRepository: BaseRepository<PremiumBreakdown>, IPremiumBreakdownRepository
    {
        public PremiumBreakdownRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
