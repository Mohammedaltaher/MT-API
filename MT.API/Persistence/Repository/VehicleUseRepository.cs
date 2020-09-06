using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleUseRepository : IBaseRepository<VehicleUse>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleUseRepository: BaseRepository<VehicleUse>, IVehicleUseRepository
    {
        public VehicleUseRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
