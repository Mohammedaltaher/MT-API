using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IMedicalConditionRepository : IBaseRepository<MedicalCondition>
    {
        /// Add other interface here
    }

    #region Implementation
    public class MedicalConditionRepository: BaseRepository<MedicalCondition>, IMedicalConditionRepository
    {
        public MedicalConditionRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
