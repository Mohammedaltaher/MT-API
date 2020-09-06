using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface INCDFreeYearRepository : IBaseRepository<NCDFreeYear>
    {
        /// Add other interface here
    }

    #region Implementation
    public class NCDFreeYearRepository: BaseRepository<NCDFreeYear>, INCDFreeYearRepository
    {
        public NCDFreeYearRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
