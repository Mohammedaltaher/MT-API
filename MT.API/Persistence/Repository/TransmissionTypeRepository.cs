using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ITransmissionTypeRepository : IBaseRepository<TransmissionType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class TransmissionTypeRepository: BaseRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
