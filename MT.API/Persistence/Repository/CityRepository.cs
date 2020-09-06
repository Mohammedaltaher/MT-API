using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ICityRepository : IBaseRepository<City>
    {
        /// Add other interface here
    }

    #region Implementation
    public class CityRepository: BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
