using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleColorRepository : IBaseRepository<VehicleColor>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleColorRepository: BaseRepository<VehicleColor>, IVehicleColorRepository
    {
        public VehicleColorRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
