using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ITicketTypeRepository : IBaseRepository<TicketType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class TicketTypeRepository : BaseRepository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
