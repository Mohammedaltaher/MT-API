using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IMileageRepository : IBaseRepository<Mileage>
    {
        /// Add other interface here
    }

    #region Implementation
    public class MileageRepository: BaseRepository<Mileage>, IMileageRepository
    {
        public MileageRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
