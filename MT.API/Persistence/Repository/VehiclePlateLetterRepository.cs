using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IVehiclePlateLetterRepository : IBaseRepository<VehiclePlateLetter>
    {
        /// Add other interface here
    }

    #region Implementation
    public class VehiclePlateLetterRepository: BaseRepository<VehiclePlateLetter>, IVehiclePlateLetterRepository
    {
        public VehiclePlateLetterRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
