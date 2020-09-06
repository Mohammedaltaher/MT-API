using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        /// Add other interface here
    }

    #region Implementation
    public class RegionRepository: BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
