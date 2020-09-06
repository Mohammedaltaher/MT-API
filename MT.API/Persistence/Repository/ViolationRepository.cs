using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IViolationRepository : IBaseRepository<Violation>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ViolationRepository: BaseRepository<Violation>, IViolationRepository
    {
        public ViolationRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
