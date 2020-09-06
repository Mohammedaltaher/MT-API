using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleBodyTypeRepository : IBaseRepository<VehicleBodyType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleBodyTypeRepository: BaseRepository<VehicleBodyType>, IVehicleBodyTypeRepository
    {
        public VehicleBodyTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
