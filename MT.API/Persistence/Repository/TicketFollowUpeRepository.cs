using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ITicketFollowUpRepository : IBaseRepository<TicketFollowUp>
    {
        /// Add other interface here
        IEnumerable<TicketFollowUp> GetTicketFollowUp(Guid TickedId);
    }

    #region Implementation
    public class TicketFollowUpRepository : BaseRepository<TicketFollowUp>, ITicketFollowUpRepository
    {
        public TicketFollowUpRepository(AppDbContext context)
            : base(context)
        {

        }

        public IEnumerable<TicketFollowUp> GetTicketFollowUp(Guid TickedId)
        {

            var data = this.GetMany(p => p.TicketId == TickedId).OrderByDescending(p => p.CreatedDate)
                .Include("Ticket") 
                .Include("Ticket.ApplicationUser"); 
            return data;
        }
    }
    #endregion
}
