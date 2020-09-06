using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        /// Add other interface here
    }

    #region Implementation
    public class GenderRepository: BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(AppDbContext context)
            : base(context)
        {

        }

        /// Interface implemenation
    }
    #endregion
}
