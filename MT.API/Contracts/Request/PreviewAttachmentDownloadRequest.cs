namespace  AggriPortal.API.Contracts.Request
{
    public class PreviewAttachmentDownloadRequest
    {
        public string UserId { get; set; }
        public string ReferenceId { get; set; }
        public string AttachmentFileName { get; set; }
    }
}
