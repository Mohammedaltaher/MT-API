using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IAttachmentRepository : IBaseRepository<Attachment>
    {
        /// Add other interface here
    }

    #region Implementation
    public class AttachmentRepository: BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
