using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface ILicenseTypeRepository : IBaseRepository<LicenseType>
    {
        /// Add other interface here
    }

    #region Implementation
    public class LicenseTypeRepository: BaseRepository<LicenseType>, ILicenseTypeRepository
    {
        public LicenseTypeRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
