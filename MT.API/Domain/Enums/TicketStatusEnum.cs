namespace  AggriPortal.API.Domain.Enums
{
    /// <summary>
    /// Payment Status enum based on Checkout.com Payment Gateway Service.
    /// </summary>
    public enum TicketStatusEnum
    {
        Pending = 1,
        WorkInProgress,
        Resolved,
        Cancelled
    }
}
