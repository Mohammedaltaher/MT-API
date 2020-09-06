using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string TicketReferenceId { get; set; }
        public Guid? ClientId { get; set; }
        public int TicketTypeId { get; set; }
        public string Body { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string ClosedBy { get; set; }
        public Client Client { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public TicketType TicketType { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public ICollection<TicketFollowUp> TicketFollowUps { get; set; }

    }

    public class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }



    public class TicketStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string BgColor { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }



    public class TicketFollowUp
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// Indicate who submit the message.
        /// 0: Client.
        /// 1: Support Team
        /// </summary>
        public string Sender { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Ticket Ticket { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }

    }
}
