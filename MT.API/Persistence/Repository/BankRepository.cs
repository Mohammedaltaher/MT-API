using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IBankRepository : IBaseRepository<Bank>
    {
        /// Add other interface here
    }

    #region Implementation
    public class BankRepository: BaseRepository<Bank>, IBankRepository
    {
        public BankRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
