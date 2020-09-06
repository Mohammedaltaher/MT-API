using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        /// Add other interface here
    }

    #region Implementation
    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
