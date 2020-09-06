using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IParkingLocationRepository : IBaseRepository<ParkingLocation>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ParkingLocationRepository: BaseRepository<ParkingLocation>, IParkingLocationRepository
    {
        public ParkingLocationRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
