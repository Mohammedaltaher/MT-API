using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IPoliciesMotorRequestRepository : IBaseRepository<PolicyRequest>
    {
        /// Add other interface here
        
    }

    #region Implementation
    public class PoliciesMotorRequestRepository : BaseRepository<PolicyRequest>, IPoliciesMotorRequestRepository
    {
        public PoliciesMotorRequestRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
