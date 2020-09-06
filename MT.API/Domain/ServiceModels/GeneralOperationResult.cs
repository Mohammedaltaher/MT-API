namespace  AggriPortal.API.Domain.ServiceModels
{
    public class GeneralOperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public GeneralOperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
