namespace  AggriPortal.API.Contracts.Request
{
    public class VerifyPhoneNumberRequest
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
