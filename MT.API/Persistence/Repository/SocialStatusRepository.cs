using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ISocialStatusRepository : IBaseRepository<SocialStatus>
    {
        /// Add other interface here
    }

    #region Implementation
    public class SocialStatusRepository: BaseRepository<SocialStatus>, ISocialStatusRepository
    {
        public SocialStatusRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
