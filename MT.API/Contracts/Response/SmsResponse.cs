namespace  AggriPortal.API.Contracts.Response
{
    public class SmsResponse
    {
        public string MessageID { get; set; }
        public string Status { get; set; }
        public string NumberOfUnits { get; set; }
        public string Cost { get; set; }
        public string Balance { get; set; }
        public string Recipient { get; set; }
        public string DateCreated { get; set; }
    }
}
