using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleIdTypeRepository : IBaseRepository<VehicleIdType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleIdTypeRepository: BaseRepository<VehicleIdType>, IVehicleIdTypeRepository
    {
        public VehicleIdTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
