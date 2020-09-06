using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleMakerRepository : IBaseRepository<VehicleMaker>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleMakerRepository: BaseRepository<VehicleMaker>, IVehicleMakerRepository
    {
        public VehicleMakerRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
