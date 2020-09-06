using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IDrivingPercentageRepository : IBaseRepository<DrivingPercentage>
    {
        /// Add other interface here
    }

    #region Implementation
    public class DrivingPercentageRepository: BaseRepository<DrivingPercentage>, IDrivingPercentageRepository
    {
        public DrivingPercentageRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
