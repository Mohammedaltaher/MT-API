using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleRepairMethodRepository : IBaseRepository<VehicleRepairMethod>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleRepairMethodRepository: BaseRepository<VehicleRepairMethod>, IVehicleRepairMethodRepository
    {
        public VehicleRepairMethodRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
