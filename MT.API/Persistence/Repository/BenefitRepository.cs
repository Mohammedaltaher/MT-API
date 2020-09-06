using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IBenefitRepository : IBaseRepository<Benefit>
    {
        /// Add other interface here
    }

    #region Implementation
    public class BenefitRepository : BaseRepository<Benefit>, IBenefitRepository
    {
        public BenefitRepository(AppDbContext context) : base(context)
        {

        }
    }

    #endregion
}
