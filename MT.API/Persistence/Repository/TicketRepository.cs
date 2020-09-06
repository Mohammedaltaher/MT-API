using AggriPortal.API.Domain.Models;
using AggriPortal.API.Resources;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        /// Add other interface here
        IEnumerable<Ticket> GetTickets(TicketsRequestDto req);
    }

    #region Implementation
    public class TicketRepository: BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Ticket> GetTickets(TicketsRequestDto req)
        {

            Expression<Func<Ticket, bool>> predicate = c => true;
            if (!string.IsNullOrEmpty(req.ClientName))
            {
                predicate = predicate.And(p => p.Client.FirstName.Contains(req.ClientName) || p.Client.MiddleName.Contains(req.ClientName) || p.Client.LastName.Contains(req.ClientName) || p.Client.FirstNameAr.Contains(req.ClientName) || p.Client.MiddleNameAr.Contains(req.ClientName) || p.Client.LastNameAr.Contains(req.ClientName));
            }
            if (req.TicketType != null)
            {
                predicate = predicate.And(p => p.TicketTypeId == req.TicketType);
            }
            if (req.TicketStatus != null)
            {
                predicate = predicate.And(p => p.TicketStatusId == req.TicketStatus);
            }
            if (req.DateFrom != null && req.DateTo != null)
            {
                predicate = predicate.And(p => p.CreatedDate.Date >= req.DateFrom.Value.Date && p.CreatedDate.Date <= req.DateTo.Value.Date);
            }
            var data = this.GetMany(predicate).OrderByDescending(p => p.CreatedDate)
                .Include("TicketStatus")
                .Include("TicketType")
                .Include("Client")
                .Include("ApplicationUser")
                ;

            return data;
        }
        
    }
    #endregion
}
