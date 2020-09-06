using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IIdentityTypeRepository : IBaseRepository<IdentityType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class IdentityTypeRepository: BaseRepository<IdentityType>, IIdentityTypeRepository
    {
        public IdentityTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
