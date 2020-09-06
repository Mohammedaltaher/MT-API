using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleEngineSizeRepository : IBaseRepository<VehicleEngineSize>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleEngineSizeRepository: BaseRepository<VehicleEngineSize>, IVehicleEngineSizeRepository
    {
        public VehicleEngineSizeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
