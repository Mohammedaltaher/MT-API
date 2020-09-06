using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.ServiceModels
{

    public class HyperpayBaseResponse
    {
        public HyperPayRequestResult Result { get; set; }
        public string BuildNumber { get; set; }
        public DateTime Timestamp { get; set; }
        public string Ndc { get; set; }
    }
    public class HyperpayCheckoutResponse : HyperpayBaseResponse
    {
        public string Id { get; set; }
    }

    public class HyperpayPaymentStatusResponse : HyperpayBaseResponse
    {
        public string Id { get; set; }
        public string PaymentBrand { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public HyperpayCardDetails Cards { get; set; }
    }
    public class HyperpayCardDetails
    {
        public string Bin { get; set; }
        public string Last4Digits { get; set; }
        public string Holder { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }
    public class HyperPayRequestResult
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<ParameterError> ParameterErrors { get; set; }
        public HyperPayRequestResult()
        {
            ParameterErrors = new List<ParameterError>();
        }
    }
    public class ParameterError
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
    }
}
