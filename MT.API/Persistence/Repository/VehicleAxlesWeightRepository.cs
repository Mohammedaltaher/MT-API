using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleAxlesWeightRepository : IBaseRepository<VehicleAxlesWeight>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleAxlesWeightRepository: BaseRepository<VehicleAxlesWeight>, IVehicleAxlesWeightRepository
    {
        public VehicleAxlesWeightRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
