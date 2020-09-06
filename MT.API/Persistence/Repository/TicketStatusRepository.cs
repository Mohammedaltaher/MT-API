using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ITicketStatusRepository : IBaseRepository<TicketStatus>
    {
        /// Add other interface here
    }

    #region Implementation
    public class TicketStatusRepository : BaseRepository<TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
