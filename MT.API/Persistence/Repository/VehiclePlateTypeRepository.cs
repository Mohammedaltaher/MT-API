using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehiclePlateTypeRepository : IBaseRepository<VehiclePlateType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehiclePlateTypeRepository: BaseRepository<VehiclePlateType>, IVehiclePlateTypeRepository
    {
        public VehiclePlateTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
