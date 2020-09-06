namespace  AggriPortal.API.Domain.Enums
{
    /// <summary>
    /// Payment Status enum based on Checkout.com Payment Gateway Service.
    /// </summary>
    public enum PaymentStatusEnum
    {
        Pending=0,
        Approved,
        Rejected,
        Refund
    }
}
