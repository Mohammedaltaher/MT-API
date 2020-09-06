using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehicleSpecificationRepository : IBaseRepository<VehicleSpecification>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehicleSpecificationRepository: BaseRepository<VehicleSpecification>, IVehicleSpecificationRepository
    {
        public VehicleSpecificationRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
