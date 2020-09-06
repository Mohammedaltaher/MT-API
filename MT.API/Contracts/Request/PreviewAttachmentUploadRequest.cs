using Microsoft.AspNetCore.Http;


namespace  AggriPortal.API.Contracts.Request
{
    public class PreviewAttachmentUploadRequest
    {
        public string UserId { get; set; }
        public string ReferenceId { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
