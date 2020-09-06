using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleModelRepository : IBaseRepository<VehicleModel>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleModelRepository : BaseRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
