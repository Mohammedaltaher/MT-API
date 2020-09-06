using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        /// Add other interface here
    }

    #region Implementation
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {

        public ApplicationUserRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
