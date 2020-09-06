using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IEducationLevelRepository : IBaseRepository<EducationLevel>
    {
        /// Add other interface here
    }

    #region Implementation
    public class EducationLevelRepository: BaseRepository<EducationLevel>, IEducationLevelRepository
    {
        public EducationLevelRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
