using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IApplicationUserLoginHistoryRepository : IBaseRepository<ApplicationUserLoginHistory>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ApplicationUserLoginHistoryRepository: BaseRepository<ApplicationUserLoginHistory>, IApplicationUserLoginHistoryRepository
    {
        public ApplicationUserLoginHistoryRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
