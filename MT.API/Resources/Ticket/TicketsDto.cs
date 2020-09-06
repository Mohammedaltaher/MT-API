
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class TicketsRequestDto
    {
        public string ClientName  { get; set; }
        public int? TicketType { get; set; }
        public int? TicketStatus { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class TicketFollowUpRequestDto
    {
        public Guid TicketId { get; set; }
        public string Message { get; set; }
    }
    public class UpdateTicketStatusRequestDto
    {
        public Guid TicketId { get; set; }
        public string Message { get; set; }
        public int TicketStatusId { get; set; }
    }
    public  class TicketsResponseDto : BaseResponse
    {
        public IEnumerable<TicketsDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class TicketsDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ClientNameAr { get; set; }

        public string Type { get; set; }
        public string TypeAr { get; set; }

        public string Status { get; set; }
        public string StatusAr { get; set; }

        public string TicketReferenceId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string ClosedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
    public class TicketFollowUpResponseDto : BaseResponse
    {
        public IEnumerable<TicketFollowUpDto> Data { get; set; }

    }
    public class TicketFollowUpDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// Indicate who submit the message.
        /// 0: Client.
        /// 1: Support Team
        /// </summary>
        public string Sender { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
