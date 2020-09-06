using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IDriverTypeRepository : IBaseRepository<DriverType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class DriverTypeRepository: BaseRepository<DriverType>, IDriverTypeRepository
    {
        public DriverTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
